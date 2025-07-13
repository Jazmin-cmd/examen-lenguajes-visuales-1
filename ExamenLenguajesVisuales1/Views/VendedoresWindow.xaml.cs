using ExamenLenguajesVisuales1.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace ExamenLenguajesVisuales1.Views
{
    public partial class VendedoresWindow : Window
    {
        private ObservableCollection<Vendedor> listaVendedores = new ObservableCollection<Vendedor>();

        public VendedoresWindow()
        {
            InitializeComponent();
            dgVendedores.ItemsSource = listaVendedores; // Importante: hacer esto solo una vez aquí
            CargarVendedores();
        }

        private void CargarVendedores()
        {
            using (var context = new VendedoreDBContext())
            {
                var vendedores = context.Vendedores.ToList();

                listaVendedores.Clear(); // No reemplazamos la colección
                foreach (var vendedor in vendedores)
                {
                    listaVendedores.Add(vendedor);
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            string filtro = txtBuscar.Text.ToLower();

            if (string.IsNullOrWhiteSpace(filtro))
            {
                dgVendedores.ItemsSource = listaVendedores;
            }
            else
            {
                var listaFiltrada = listaVendedores
                    .Where(v => (v.Nombre != null && v.Nombre.ToLower().Contains(filtro))
                             || (v.Telefono != null && v.Telefono.ToLower().Contains(filtro))
                             || (v.Email != null && v.Email.ToLower().Contains(filtro)))
                    .ToList();
                dgVendedores.ItemsSource = listaFiltrada;
            }
        }

        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            var ventana = new AddVendedorWindow();
            bool? resultado = ventana.ShowDialog(); // abre como modal y espera cierre
            if (resultado == true)
            {
                CargarVendedores(); // recarga la lista para que se vea el nuevo vendedor
            }
        }


        private void Editar_Click(object sender, RoutedEventArgs e)
        {
            var seleccionado = dgVendedores.SelectedItem as Vendedor;
            if (seleccionado == null)
            {
                MessageBox.Show("Seleccione un vendedor para editar.", "Atención", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var ventana = new VendedorDetalleWindow(seleccionado);
            if (ventana.ShowDialog() == true)
            {
                CargarVendedores();
            }
        }

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            var seleccionado = dgVendedores.SelectedItem as Vendedor;
            if (seleccionado == null)
            {
                MessageBox.Show("Seleccione un vendedor para eliminar.", "Atención", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var resultado = MessageBox.Show($"¿Está seguro de eliminar al vendedor {seleccionado.Nombre}?", "Confirmar", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resultado == MessageBoxResult.Yes)
            {
                using (var context = new VendedoreDBContext())
                {
                    context.Vendedores.Remove(seleccionado);
                    context.SaveChanges();
                }
                CargarVendedores();
            }
        }
    }
}
