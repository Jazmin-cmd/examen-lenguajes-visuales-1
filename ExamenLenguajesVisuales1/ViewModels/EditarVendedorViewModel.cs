using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using ExamenLenguajesVisuales1.Commands;
using ExamenLenguajesVisuales1.Models;
using ExamenLenguajesVisuales1.Views;

namespace ExamenLenguajesVisuales1.ViewModels
{
    public class EditarVendedorViewModel : BaseViewModel
    {
        public Vendedor Vendedor { get; set; }

        private ObservableCollection<Venta> _ventas;
        public ObservableCollection<Venta> Ventas
        {
            get => _ventas;
            set => SetProperty(ref _ventas, value);
        }

        public ICommand AgregarVentaCommand { get; }
        public ICommand GuardarCommand { get; }
        public ICommand CancelarCommand { get; }

        public EditarVendedorViewModel(Vendedor vendedor)
        {
            Vendedor = vendedor;
            CargarVentas();

            AgregarVentaCommand = new RelayCommand(AbrirAgregarVenta);
            GuardarCommand = new RelayCommand(Guardar);
            CancelarCommand = new RelayCommand(Cancelar);
        }

        private void CargarVentas()
        {
            using (var context = new VendedoreDBContext())
            {
                var ventasDB = context.Ventas.Where(v => v.VendedorId == Vendedor.VendedorId).ToList();
                Ventas = new ObservableCollection<Venta>(ventasDB);
            }
        }

        private void AbrirAgregarVenta()
        {
            var ventanaAgregarVenta = new AgregarVentaWindow(Vendedor.VendedorId);
            ventanaAgregarVenta.ShowDialog();

            // Después de cerrar ventana agregar venta, recargamos las ventas
            CargarVentas();
        }

        private void Guardar()
        {
            try
            {
                using (var context = new VendedoreDBContext())
                {
                    context.Vendedores.Update(Vendedor);
                    context.SaveChanges();

                }

                MessageBox.Show("Vendedor guardado correctamente.");

                CerrarVentana();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar vendedor: " + ex.Message);
            }
        }

        private void Cancelar()
        {
            CerrarVentana();
        }

        private void CerrarVentana()
        {
            // Cierra la ventana asociada a este ViewModel
            foreach (Window window in Application.Current.Windows)
            {
                if (window.DataContext == this)
                {
                    window.Close();
                    break;
                }
            }
        }
    }
}

