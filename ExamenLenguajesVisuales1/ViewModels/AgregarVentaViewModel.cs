using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using ExamenLenguajesVisuales1.Commands;
using ExamenLenguajesVisuales1.Models;

namespace ExamenLenguajesVisuales1.ViewModels
{
    public class AgregarVentaViewModel : INotifyPropertyChanged
    {
        private DateTime fecha = DateTime.Now;
        public DateTime Fecha
        {
            get => fecha;
            set { fecha = value; OnPropertyChanged(); }
        }

        private decimal monto;
        public decimal Monto
        {
            get => monto;
            set { monto = value; OnPropertyChanged(); }
        }

        private int vendedorId;

        public ICommand GuardarCommand { get; }

        public AgregarVentaViewModel(int vendedorId)
        {
            this.vendedorId = vendedorId;
            GuardarCommand = new RelayCommand(GuardarVenta, PuedeGuardar);
        }

        private bool PuedeGuardar()
        {
            return Monto > 0;
        }

        private void GuardarVenta()
        {
            try
            {
                using (var context = new VendedoreDBContext())
                {
                    var venta = new Venta
                    {
                        Fecha = this.Fecha,
                        Monto = this.Monto,
                        VendedorId = this.vendedorId
                    };

                    context.Ventas.Add(venta);
                    context.SaveChanges();
                }

                MessageBox.Show("Venta agregada correctamente.");
                // Cerramos la ventana actual
                Application.Current.Windows[Application.Current.Windows.Count - 1].Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar venta: " + ex.Message);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
