using ExamenLenguajesVisuales1.Models;
using ExamenLenguajesVisuales1.ViewModels;
using System.Windows;

namespace ExamenLenguajesVisuales1.Views
{
    public partial class VendedorDetalleWindow : Window
    {
        // Constructor para crear un nuevo vendedor
        public VendedorDetalleWindow()
        {
            InitializeComponent();
            // Le asignamos un ViewModel nuevo con un vendedor vacío para agregar
            this.DataContext = new EditarVendedorViewModel(new Vendedor());
        }

        // Constructor para editar un vendedor existente
        public VendedorDetalleWindow(Vendedor vendedorExistente)
        {
            InitializeComponent();
            // Le asignamos un ViewModel con el vendedor que queremos editar
            this.DataContext = new EditarVendedorViewModel(vendedorExistente);
        }
    }
}
