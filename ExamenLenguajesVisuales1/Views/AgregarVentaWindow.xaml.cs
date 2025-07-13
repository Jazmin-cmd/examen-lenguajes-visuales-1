using System.Windows;
using ExamenLenguajesVisuales1.ViewModels;

namespace ExamenLenguajesVisuales1.Views
{
    public partial class AgregarVentaWindow : Window
    {
        public AgregarVentaWindow(int vendedorId)
        {
            InitializeComponent();
            DataContext = new AgregarVentaViewModel(vendedorId);
        }
    }
}

