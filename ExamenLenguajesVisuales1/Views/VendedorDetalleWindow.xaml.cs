using ExamenLenguajesVisuales1.Models;
using System.Windows;

namespace ExamenLenguajesVisuales1.Views
{
    public partial class VendedorDetalleWindow : Window
    {
        private Vendedor vendedor;
        private bool esEdicion;

        public VendedorDetalleWindow()
        {
            InitializeComponent();
            vendedor = new Vendedor();
            esEdicion = false;
        }

        public VendedorDetalleWindow(Vendedor vendedorExistente)
        {
            InitializeComponent();
            vendedor = vendedorExistente;
            esEdicion = true;

            txtNombre.Text = vendedor.Nombre;
            txtTelefono.Text = vendedor.Telefono;
            txtEmail.Text = vendedor.Email;
        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            // Validaciones simples
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            vendedor.Nombre = txtNombre.Text;
            vendedor.Telefono = txtTelefono.Text;
            vendedor.Email = txtEmail.Text;

            using (var context = new VendedoreDBContext())
            {
                if (esEdicion)
                {
                    context.Vendedores.Update(vendedor);
                }
                else
                {
                    context.Vendedores.Add(vendedor);
                }
                context.SaveChanges();
            }

            this.DialogResult = true;
            this.Close();
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
