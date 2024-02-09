using System.Windows.Input;
using freight.control.maui.MVVM.Base.ViewModels;

namespace freight.control.maui.MVVM.ViewModels;

public class AddFreightViewModel : BaseViewModel
{
    #region Properties

    private DateTime _travelDate = DateTime.Now;
    public DateTime TravelDate
    {
        get => _travelDate;
        set
        {
            _travelDate = value;
            OnPropertyChanged();
        }
    }


    private string _origin;
    public string Origin
    {
        get => _origin;
        set
        {
            _origin = value;
            OnPropertyChanged();
        }
    }


    private string _destination;
    public string Destination
    {
        get => _destination;
        set
        {
            _destination = value;
            OnPropertyChanged();
        }
    }


    private string _kilometer;
    public string Kilometer
    {
        get => _kilometer;
        set
        {
            _kilometer = value;
            OnPropertyChanged();
        }
    }


    private string _freightValue;
    public string FreightValue
    {
        get => _freightValue;
        set
        {
            _freightValue = value;
            OnPropertyChanged();
        }
    }


    private string _observation;
    public string Observation
    {
        get => _observation;
        set
        {
            _observation = value;
            OnPropertyChanged();
        }
    }


    private Color _strokeFreight = Colors.LightGray;
    public Color StrokeFreight
    {
        get => _strokeFreight;
        set
        {
            _strokeFreight = value;
            OnPropertyChanged();
        }
    }


    private Color _strokeKm = Colors.LightGray;
    public Color StrokeKm
    {
        get => _strokeKm;
        set
        {
            _strokeKm = value;
            OnPropertyChanged();
        }
    }

    #endregion

    public ICommand SaveCommand { get; set; }

    public AddFreightViewModel()
    {
        SaveCommand = new Command(OnSave);
    }

    #region Private Methods


    #endregion

    #region Public Methods

    public void OnSave()
    {
    }

    #endregion
}
