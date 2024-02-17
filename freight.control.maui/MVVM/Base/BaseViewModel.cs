using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace freight.control.maui.MVVM.Base.ViewModels;

public class BaseViewModel : INotifyPropertyChanged
{
    private bool _isBusy;
    public bool IsBusy
    {
        get => _isBusy;
        set
        {
            _isBusy = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public void OnPropertyChanged([CallerMemberName] string name = null)
    {       
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));        
    }
}
