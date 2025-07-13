using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ExamenLenguajesVisuales1.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string nombrePropiedad = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombrePropiedad));
        }

        // Método auxiliar para asignar valor y notificar el cambio
        protected bool SetProperty<T>(ref T campo, T valor, [CallerMemberName] string nombrePropiedad = null)
        {
            if (Equals(campo, valor))
                return false;

            campo = valor;
            OnPropertyChanged(nombrePropiedad);
            return true;
        }
    }
}

