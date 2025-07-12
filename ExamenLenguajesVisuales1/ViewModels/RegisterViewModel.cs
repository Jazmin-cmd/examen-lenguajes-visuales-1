using System.ComponentModel;

public class RegisterViewModel : INotifyPropertyChanged
{
    private string _nombreUsuario;
    public string NombreUsuario
    {
        get { return _nombreUsuario; }
        set
        {
            _nombreUsuario = value;
            OnPropertyChanged(nameof(NombreUsuario));
        }
    }

    private string _contraseña;
    public string Contraseña
    {
        get { return _contraseña; }
        set
        {
            _contraseña = value;
            OnPropertyChanged(nameof(Contraseña));
        }
    }

    private string _email;
    public string Email
    {
        get { return _email; }
        set
        {
            _email = value;
            OnPropertyChanged(nameof(Email));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string name)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
