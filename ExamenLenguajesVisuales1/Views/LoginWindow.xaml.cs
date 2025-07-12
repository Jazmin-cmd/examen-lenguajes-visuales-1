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
    /// Lógica de interacción para LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            this.DataContext = new LoginViewModel();
        }

        private void Registrarse_Click(object sender, RoutedEventArgs e)
        {
            var registro = new RegisterWindow();
            registro.ShowDialog();
        }

        private void IniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as LoginViewModel;
            if (vm == null)
                return;

            // Tomamos la contraseña del PasswordBox
            string contraseñaIngresada = PasswordBox.Password;

            try
            {
                using (var context = new VendedoreDBContext())
                {
                    var usuario = context.Usuarios
                        .FirstOrDefault(u => u.NombreUsuario == vm.NombreUsuario && u.Contraseña == contraseñaIngresada);

                    if (usuario != null)
                    {
                        MessageBox.Show("Inicio de sesión exitoso.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);

                        // **Aquí abrimos la ventana de vendedores**
                        var vendedoresWindow = new VendedoresWindow();
                        vendedoresWindow.Show();

                        // Cerramos la ventana de login
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar sesión: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


    }
}
