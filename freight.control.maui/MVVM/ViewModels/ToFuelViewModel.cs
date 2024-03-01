using System.Globalization;
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


    private Color _borderColorLiters = Colors.LightGray;
    public Color BorderColorLiters
    {
        get => _borderColorLiters;
        set
        {
            _borderColorLiters = value;
            OnPropertyChanged();
        }
    }

    private Color _borderColorFocusedLiters = Colors.Gray;
    public Color BorderColorFocusedLiters
    {
        get => _borderColorFocusedLiters;
        set
        {
            _borderColorFocusedLiters = value;
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


    private Color _borderColorAmountSpentFuel = Colors.LightGray;
    public Color BorderColorAmountSpentFuel
    {
        get => _borderColorAmountSpentFuel;
        set
        {
            _borderColorAmountSpentFuel = value;
            OnPropertyChanged();
        }
    }


    private Color _borderColorFocusedAmountSpentFuel = Colors.Gray;
    public Color BorderColorFocusedAmountSpentFuel
    {
        get => _borderColorFocusedAmountSpentFuel;
        set
        {
            _borderColorFocusedAmountSpentFuel = value;
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


    private Color _borderColorExpenses = Colors.LightGray;
    public Color BorderColorExpenses
    {
        get => _borderColorExpenses;
        set
        {
            _borderColorExpenses = value;
            OnPropertyChanged();
        }
    }


    private Color _borderColorFocusedExpenses = Colors.Gray;
    public Color BorderColorFocusedExpenses
    {
        get => _borderColorFocusedExpenses;
        set
        {
            _borderColorFocusedExpenses = value;
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

    private Color _strokeDate = Colors.LightGray;
    public Color StrokeDate
    {
        get => _strokeDate;
        set
        {
            _strokeDate = value;
            OnPropertyChanged();
        }
    }

    private bool _isValidToSave = true;
    public bool IsValidToSave
    {
        get => _isValidToSave;
        set
        {
            _isValidToSave = value;
            OnPropertyChanged();
        }
    }


    private bool _isEnabledSaveButton = true;
    public bool IsEnabledSaveButton
    {
        get => _isEnabledSaveButton;
        set
        {
            _isEnabledSaveButton = value;
            OnPropertyChanged();
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
          
            var edited = await _toFuelRepository.UpdateAsync(await CreateModelToAddOrEdit());

            if (edited > 0)
            {
                await App.Current.MainPage.DisplayAlert("Sucesso", "Abastecimento editado com sucesso!", "Ok");
                return;
            }

            await App.Current.MainPage.DisplayAlert("Ops", "Parece que houve um erro durante a edição do abastecimento. Por favor, tente novamente.", "Ok");

            return;
        }
       
        var result = await _toFuelRepository.SaveAsync(await CreateModelToAddOrEdit());

        if (result > 0)
        {
            await App.Current.MainPage.DisplayAlert("Sucesso", "Abastecimento criado com sucesso!", "Ok");
            return;
        }

        await App.Current.MainPage.DisplayAlert("Ops", "Parece que houve um erro durante a criação do abastecimento. Por favor, tente novamente.", "Ok");
    }

    #region Private Methods

    private async Task<ToFuelModel> CreateModelToAddOrEdit()
    {
        var model = new ToFuelModel();
        model.Id = SelectedToFuelToEdit.Id > 0 ? SelectedToFuelToEdit.Id : DetailsFreight.Id;
        model.FreightModelId = SelectedToFuelToEdit.FreightModelId > 0 ? SelectedToFuelToEdit.FreightModelId : DetailsFreight.Id;        
        model.Date = Date;              
        model.Liters = Liters.Contains(".") ? double.Parse(Liters.Replace(".", ",")) : double.Parse(Liters.Replace(",", "."));
        //model.AmountSpentFuel = Convert.ToDecimal(AmountSpentFuel);
        model.AmountSpentFuel = await CalcDecimalPriceInput(AmountSpentFuel);
        model.ValuePerLiter = Convert.ToDecimal(AmountSpentFuel) / Convert.ToDecimal(Liters);
        //model.Expenses = Convert.ToDecimal(Expenses);
        model.Expenses = await CalcDecimalPriceInput(Expenses);
        model.Observation = Observation;

        return model;
    }

    private async Task<decimal> CalcDecimalPriceInput(string val)
    {
        decimal preco;

        CultureInfo cultureInfo = CultureInfo.InvariantCulture;

        if (decimal.TryParse(val, NumberStyles.Number, cultureInfo, out preco))
        {
            return preco;
        }
        else
        {
            await App.Current.MainPage.DisplayAlert("Ops","O valor informado não está no formato correto. Favor corrigir","Ok");
        }
        return preco;
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

    public void CalculatePriceOfFuel()
    {
        
        decimal calc = 0;

        if (string.IsNullOrEmpty(AmountSpentFuel) || string.IsNullOrEmpty(Liters))
        {
            ValuePerLiter = calc.ToString("c");
            return;
        }        

        calc = Convert.ToDecimal(AmountSpentFuel.Replace(".",",")) / Convert.ToDecimal(Liters.Replace(".", ","));               
        
        ValuePerLiter = calc.ToString("c");
    }

    #endregion
}
