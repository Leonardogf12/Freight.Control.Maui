using System.Windows.Input;
using freight.control.maui.MVVM.Base.ViewModels;
using freight.control.maui.MVVM.Models;
using freight.control.maui.Repositories;
using static Android.Graphics.ColorSpace;

namespace freight.control.maui.MVVM.ViewModels;

[QueryProperty(nameof(SelectedFreightToEdit), "SelectedFreightToEdit")]
public class AddFreightViewModel : BaseViewModel
{
    private readonly FreightRepository _freightRepository;

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


    private string _textTitlePage = "Frete";
    public string TextTitlePage
    {
        get => _textTitlePage;
        set
        {
            _textTitlePage = value;
            OnPropertyChanged();
        }
    }


    private FreightModel _selectedFreightToEdit;
    public FreightModel SelectedFreightToEdit
    {
        get => _selectedFreightToEdit;
        set
        {
            _selectedFreightToEdit = value;
            OnPropertyChanged(); 

            SetValuesToEdit();
        }
    }

    #endregion

    public ICommand SaveCommand { get; set; }

    public AddFreightViewModel()
    {
        _freightRepository = new FreightRepository();
        SaveCommand = new Command(OnSave);       
    }

    #region Private Methods

    private void SetValuesToEdit()
    {
        if (SelectedFreightToEdit != null)
        {
            TextTitlePage = "Editar Frete";
            TravelDate = SelectedFreightToEdit.TravelDate;
            Origin = SelectedFreightToEdit.Origin;
            Destination = SelectedFreightToEdit.Destination;
            Kilometer = SelectedFreightToEdit.Kilometer.ToString();
            FreightValue = SelectedFreightToEdit.FreightValue.ToString();
            Observation = SelectedFreightToEdit.Observation;
        }
    }

    #endregion

    #region Public Methods

    public async void OnSave()
    {
        if (SelectedFreightToEdit != null)
        {
            await EditFreight();
            return;
        }

        var model = new FreightModel();
        model.TravelDate = TravelDate;
        model.Origin = Origin;
        model.Destination = Destination;
        model.Kilometer = Convert.ToDouble(Kilometer.Replace(".",","));
        model.FreightValue = Convert.ToDecimal(FreightValue.Replace(".", ","));
        model.Observation = Observation;

        var result = await _freightRepository.SaveAsync(model);

        if(result > 0)
        {
            await App.Current.MainPage.DisplayAlert("Sucesso", "Frete criado com sucesso!", "Ok");
            return;
        }

        await App.Current.MainPage.DisplayAlert("Ops", "Parece que houve um erro durante a criação do Frete. Por favor, tente novamente.", "Ok");
    }

    private async Task EditFreight()
    {
        var item = new FreightModel
        {
            Id = SelectedFreightToEdit.Id,
            TravelDate = TravelDate,
            Origin = Origin,
            Destination = Destination,
            Kilometer = Convert.ToDouble(Kilometer),
            FreightValue = Convert.ToDecimal(FreightValue),
            Observation = Observation
        };

        var result = await _freightRepository.UpdateAsync(item);

        if (result > 0)
        {
            await App.Current.MainPage.DisplayAlert("Sucesso", "Frete editado com sucesso!", "Ok");
            return;
        }

        await App.Current.MainPage.DisplayAlert("Ops", "Parece que houve um erro durante a edição do Frete. Por favor, tente novamente.", "Ok");
    }

    #endregion
}
