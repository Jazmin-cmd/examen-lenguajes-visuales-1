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
using ExamenLenguajesVisuales1.ViewModels;

namespace ExamenLenguajesVisuales1.Views
{
    /// <summary>
    /// Lógica de interacción para AddVendedorWindow.xaml
    /// </summary>
    public partial class AddVendedorWindow : Window
    {
        public AddVendedorWindow()
        {
            InitializeComponent();
            this.DataContext = new AddVendedorViewModel();
        }   
    }
}
