using freight.control.maui.MVVM.Base.ViewModels;
using freight.control.maui.MVVM.Models;
using freight.control.maui.Repositories;

namespace freight.control.maui.MVVM.ViewModels;

[QueryProperty(nameof(DetailsFreight), "DetailsFreight")]
[QueryProperty(nameof(SelectedToFuelToEdit), "SelectedToFuelToEdit")]
public class ToFuelViewModel : BaseViewModel
{
    private readonly ToFuelRepository _toFuelRepository;

    private readonly FreightRepository _freightRepository;

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

            SetValuesToDetail(isCreating: true);
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


    private ToFuelModel _selectedToFuelToEdit = new();
    public ToFuelModel SelectedToFuelToEdit
    {
        get => _selectedToFuelToEdit;
        set
        {
            _selectedToFuelToEdit = value;
            OnPropertyChanged();

            SetValuesToDetail(isCreating: false);
        }
    }

    #endregion

    public ToFuelViewModel()
	{
        _toFuelRepository = new();
        _freightRepository = new();
    }

    public async void OnSave()
    {
        if(SelectedToFuelToEdit.Id > 0) {
          
            var edited = await _toFuelRepository.UpdateAsync(CreateModelToAddOrEdit());

            if (edited > 0)
            {
                await App.Current.MainPage.DisplayAlert("Sucesso", "Abastecimento editado com sucesso!", "Ok");
                return;
            }

            await App.Current.MainPage.DisplayAlert("Ops", "Parece que houve um erro durante a edição do abastecimento. Por favor, tente novamente.", "Ok");

            return;
        }
       
        var result = await _toFuelRepository.SaveAsync(CreateModelToAddOrEdit());

        if (result > 0)
        {
            await App.Current.MainPage.DisplayAlert("Sucesso", "Abastecimento criado com sucesso!", "Ok");
            return;
        }

        await App.Current.MainPage.DisplayAlert("Ops", "Parece que houve um erro durante a criação do abastecimento. Por favor, tente novamente.", "Ok");
    }

    #region Private Methods

    private ToFuelModel CreateModelToAddOrEdit()
    {
        var model = new ToFuelModel();
        model.FreightModelId = SelectedToFuelToEdit.Id > 0 ? SelectedToFuelToEdit.Id : DetailsFreight.Id;
        model.Date = Date;
        model.Liters = double.Parse(Liters);
        model.AmountSpentFuel = Convert.ToDecimal(AmountSpentFuel);
        model.ValuePerLiter = Convert.ToDecimal(AmountSpentFuel) / Convert.ToDecimal(Liters);
        model.Expenses = Convert.ToDecimal(Expenses);
        model.Observation = Observation;

        return model;
    }

    private async void SetValuesToDetail(bool isCreating)
    {
        if (isCreating)
        {
            DetailTravelDate = DetailsFreight.TravelDateCustom;
            DetailOrigin = DetailsFreight.Origin;
            DetailDestination = DetailsFreight.Destination;
            return;
        }
        else
        {
            var item = await _freightRepository.GetById(SelectedToFuelToEdit.FreightModelId);

            if (item == null) return;

            DetailTravelDate = item.TravelDate.ToShortDateString();
            DetailOrigin = item.Origin;
            DetailDestination = item.Destination;
            Date = SelectedToFuelToEdit.Date;
            Liters = SelectedToFuelToEdit.Liters.ToString();
            AmountSpentFuel = SelectedToFuelToEdit.AmountSpentFuel.ToString();

            ValuePerLiter = SelectedToFuelToEdit.ValuePerLiter.ToString("c");
            Expenses = SelectedToFuelToEdit.Expenses.ToString();
            Observation = SelectedToFuelToEdit.Observation?? "";
        }
    }

    #endregion
}
