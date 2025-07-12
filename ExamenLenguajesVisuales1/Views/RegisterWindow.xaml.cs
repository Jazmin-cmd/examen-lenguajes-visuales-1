using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ExamenLenguajesVisuales1.Models;


namespace ExamenLenguajesVisuales1.Views
{
    /// <summary>
    /// Lógica de interacción para RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
            this.DataContext = new RegisterViewModel();
        }

        private void RegistrarUsuario_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as RegisterViewModel;
            if (vm == null)
                return;

            // Tomar la contraseña del PasswordBox
            vm.Contraseña = PasswordBox.Password;

            // Validar campos (ejemplo simple)
            if (string.IsNullOrWhiteSpace(vm.NombreUsuario) ||
                string.IsNullOrWhiteSpace(vm.Contraseña) ||
                string.IsNullOrWhiteSpace(vm.Email))
            {
                MessageBox.Show("Por favor, completá todos los campos.", "Validación", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Guardar en la base de datos
            try
            {
                using (var context = new VendedoreDBContext())
                {
                    var nuevoUsuario = new Usuario
                    {
                        NombreUsuario = vm.NombreUsuario,
                        Contraseña = vm.Contraseña,
                        Email = vm.Email
                    };

                    context.Usuarios.Add(nuevoUsuario);
                    context.SaveChanges();
                }

                MessageBox.Show("Usuario registrado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close(); // Cerrar la ventana de registro
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar usuario: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



    }
}
