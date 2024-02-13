using freight.control.maui.MVVM.Base.ViewModels;
using freight.control.maui.MVVM.Models;
using freight.control.maui.Repositories;

namespace freight.control.maui.MVVM.ViewModels;

[QueryProperty(nameof(DetailsFreight), "DetailsFreight")]
public class ToFuelViewModel : BaseViewModel
{
    private readonly ToFuelRepository _toFuelRepository;

    #region Properties
        
    private DateTime _date = DateTime.Now;
    public DateTime Date
    {
        get => _date;
        set
        {
            _date = value;
            OnPropertyChanged();
        }
    }


    private string _liters;
    public string Liters
    {
        get => _liters;
        set
        {
            _liters = value;
            OnPropertyChanged();
        }
    }


    private Color _strokeLiters = Colors.LightGray;
    public Color StrokeLiters
    {
        get => _strokeLiters;
        set
        {
            _strokeLiters = value;
            OnPropertyChanged();
        }
    }


    private string _amountSpentFuel;
    public string AmountSpentFuel
    {
        get => _amountSpentFuel;
        set
        {
            _amountSpentFuel = value;
            OnPropertyChanged();
        }
    }


    private Color _strokeAmountSpentFuel = Colors.LightGray;
    public Color StrokeAmountSpentFuel
    {
        get => _strokeAmountSpentFuel;
        set
        {
            _strokeAmountSpentFuel = value;
            OnPropertyChanged();
        }
    }


    private string _valuePerLiter;
    public string ValuePerLiter
    {
        get => _valuePerLiter;
        set
        {
            _valuePerLiter = value;
            OnPropertyChanged();
        }
    }


    private string _expenses;
    public string Expenses
    {
        get => _expenses;
        set
        {
            _expenses = value;
            OnPropertyChanged();
        }
    }


    private Color _strokeExpenses = Colors.LightGray;
    public Color StrokeExpenses
    {
        get => _strokeExpenses;
        set
        {
            _strokeExpenses = value;
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


    private FreightModel _detailsFreight = new();
    public FreightModel DetailsFreight
    {
        get => _detailsFreight;
        set
        {
            _detailsFreight = value;
            OnPropertyChanged();

            SetValuesToDetail();
        }
    }


    private string _detailTravelDate = string.Empty;
    public string DetailTravelDate
    {
        get => _detailTravelDate;
        set
        {
            _detailTravelDate = value;
            OnPropertyChanged();
        }
    }


    private string _detailOrigin = string.Empty;
    public string DetailOrigin
    {
        get => _detailOrigin;
        set
        {
            _detailOrigin = value;
            OnPropertyChanged();
        }
    }


    private string _detailDestination = string.Empty;
    public string DetailDestination
    {
        get => _detailDestination;
        set
        {
            _detailDestination = value;
            OnPropertyChanged();
        }
    }
    
    #endregion

    public ToFuelViewModel()
	{
        _toFuelRepository = new ToFuelRepository();

    }

    public async void OnSave()
    {
        var model = new ToFuelModel();
        model.FreightModelId = DetailsFreight.Id;
        model.Date = Date;
        model.Liters = double.Parse(Liters);     
        model.AmountSpentFuel = Convert.ToDecimal(AmountSpentFuel);
        model.ValuePerLiter = Convert.ToDecimal(AmountSpentFuel) / Convert.ToDecimal(Liters);
        model.Expenses = Convert.ToDecimal(Expenses);
        model.Observation = Observation;

        var result = await _toFuelRepository.SaveAsync(model);

        if (result > 0)
        {
            await App.Current.MainPage.DisplayAlert("Sucesso", "Abastecimento criado com sucesso!", "Ok");
            return;
        }

        await App.Current.MainPage.DisplayAlert("Ops", "Parece que houve um erro durante a criação do abastecimento. Por favor, tente novamente.", "Ok");
    }


    #region Private Methods

    private void SetValuesToDetail()
    {
        DetailTravelDate = DetailsFreight.TravelDateCustom;
        DetailOrigin = DetailsFreight.Origin;
        DetailDestination = DetailsFreight.Destination;
    }

    #endregion
}
