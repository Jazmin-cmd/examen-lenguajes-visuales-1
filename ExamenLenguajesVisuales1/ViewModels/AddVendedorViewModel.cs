using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using ExamenLenguajesVisuales1.Models;
using ExamenLenguajesVisuales1.Commands;

namespace ExamenLenguajesVisuales1.ViewModels
{
    public class AddVendedorViewModel : INotifyPropertyChanged
    {
        private string nombre;
        public string Nombre
        {
            get => nombre;
            set { nombre = value; OnPropertyChanged(); }
        }

        private string apellido;
        public string Apellido
        {
            get => apellido;
            set { apellido = value; OnPropertyChanged(); }
        }

        private string email;
        public string Email
        {
            get => email;
            set { email = value; OnPropertyChanged(); }
        }

        private string telefono;
        public string Telefono
        {
            get => telefono;
            set { telefono = value; OnPropertyChanged(); }
        }

        public ICommand GuardarCommand { get; }

        public AddVendedorViewModel()
        {
            GuardarCommand = new RelayCommand(Guardar, PuedeGuardar);
        }

        private bool PuedeGuardar()
        {
            // Validar que los campos mínimos estén llenos.
            return !string.IsNullOrWhiteSpace(Nombre) && !string.IsNullOrWhiteSpace(Apellido);
        }

        private void Guardar()
        {
            try
            {
                using (var context = new VendedoreDBContext())
                {
                    var vendedor = new Vendedor
                    {
                        Nombre = this.Nombre,
                        Apellido = this.Apellido,
                        Email = this.Email,
                        Telefono = this.Telefono
                    };

                    context.Vendedores.Add(vendedor);
                    context.SaveChanges();
                }

                MessageBox.Show("Vendedor agregado correctamente.");

                Application.Current.Windows[Application.Current.Windows.Count - 1].Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Error al guardar vendedor: " + ex.Message);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

