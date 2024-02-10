using freight.control.maui.MVVM.Base.ViewModels;
using freight.control.maui.MVVM.Models;

namespace freight.control.maui.MVVM.ViewModels;

public class ToFuelViewModel : BaseViewModel
{

    #region Properties

    private FreightModel _freightModel = new();
    public FreightModel FreightModel
    {
        get => _freightModel;
        set
        {
            _freightModel = value;
            OnPropertyChanged();
        }
    }


    private ToFuelModel _toFuelModel = new();
    public ToFuelModel ToFuelModel
    {
        get => _toFuelModel;
        set
        {
            _toFuelModel = value;
            OnPropertyChanged();
        }
    }


    private string _litersToFuel;
    public string LitersToFuel
    {
        get => _litersToFuel;
        set
        {
            _litersToFuel = value;
            OnPropertyChanged();
        }
    }


    private string _valueOfToFuel;
    public string ValueOfToFuel
    {
        get => _valueOfToFuel;
        set
        {
            _valueOfToFuel = value;
            OnPropertyChanged();
        }
    }


    public string FreightTravelDate => FreightModel.TravelDate.ToShortDateString();
    
    #endregion

    public ToFuelViewModel()
	{		
	}

    public void OnSave()
    {

    }
}
