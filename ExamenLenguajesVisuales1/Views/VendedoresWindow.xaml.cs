using ExamenLenguajesVisuales1.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace ExamenLenguajesVisuales1.Views
{
    public partial class VendedoresWindow : Window
    {
        private List<Vendedor> listaVendedores;

        public VendedoresWindow()
        { 
            InitializeComponent();
            CargarVendedores();
        }

        private void CargarVendedores()
        {
            using (var context = new VendedoreDBContext())
            {
                listaVendedores = context.Vendedores.ToList();
                dgVendedores.ItemsSource = listaVendedores;
            }
        }

        private void txtBuscar_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            string filtro = txtBuscar.Text.ToLower();
            var listaFiltrada = listaVendedores
                .Where(v => v.Nombre.ToLower().Contains(filtro)
                         || v.Telefono.ToLower().Contains(filtro)
                         || v.Email.ToLower().Contains(filtro))
                .ToList();
            dgVendedores.ItemsSource = listaFiltrada;
        }

        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            var ventana = new VendedorDetalleWindow();
            if (ventana.ShowDialog() == true)
            {
                CargarVendedores();
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
