using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using freight.control.maui.Controls;
using freight.control.maui.MVVM.Base.ViewModels;
using freight.control.maui.MVVM.Models;
using freight.control.maui.Repositories;
using freight.control.maui.Services;

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

    private Color _borderColorFreightValue = Colors.LightGray;
    public Color BorderColorFreightValue
    {
        get => _borderColorFreightValue;
        set
        {
            _borderColorFreightValue = value;
            OnPropertyChanged();
        }
    }

    private Color _borderColorFocusedFreightValue = Colors.Gray;
    public Color BorderColorFocusedFreightValue
    {
        get => _borderColorFocusedFreightValue;
        set
        {
            _borderColorFocusedFreightValue = value;
            OnPropertyChanged();
        }
    }

    private Color _borderColorKm = Colors.LightGray;
    public Color BorderColorKm
    {
        get => _borderColorKm;
        set
        {
            _borderColorKm = value;
            OnPropertyChanged();
        }
    }

    private Color _borderColorFocusedKm = Colors.Gray;
    public Color BorderColorFocusedKm
    {
        get => _borderColorFocusedKm;
        set
        {
            _borderColorFocusedKm = value;
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
   
    private ObservableCollection<string> _originCollection = new();
    public ObservableCollection<string> OriginCollection
    {
        get => _originCollection;
        set
        {
            _originCollection = value;
            OnPropertyChanged();
        }
    }

    private ObservableCollection<string> _originUfCollection = new();
    public ObservableCollection<string> OriginUfCollection
    {
        get => _originUfCollection;
        set
        {
            _originUfCollection = value;
            OnPropertyChanged();
        }
    }

    private string _selectedItemOriginUf;
    public string SelectedItemOriginUf
    {
        get => _selectedItemOriginUf;
        set
        {
            _selectedItemOriginUf = value;
            OnPropertyChanged();
        }
    }

    private string _selectedItemOrigin;
    public string SelectedItemOrigin
    {
        get => _selectedItemOrigin;
        set
        {
            _selectedItemOrigin = value;
            OnPropertyChanged();
        }
    }
   
    private ObservableCollection<string> _destinationCollection = new();
    public ObservableCollection<string> DestinationCollection
    {
        get => _destinationCollection;
        set
        {
            _destinationCollection = value;
            OnPropertyChanged();
        }
    }

    private ObservableCollection<string> _destinationUfCollection = new();
    public ObservableCollection<string> DestinationUfCollection
    {
        get => _destinationUfCollection;
        set
        {
            _destinationUfCollection = value;
            OnPropertyChanged();
        }
    }
    
    private string _selectedItemDestinationUf;
    public string SelectedItemDestinationUf
    {
        get => _selectedItemDestinationUf;
        set
        {
            _selectedItemDestinationUf = value;
            OnPropertyChanged();
        }
    }

    private string _selectedItemDestination;
    public string SelectedItemDestination
    {
        get => _selectedItemDestination;
        set
        {
            _selectedItemDestination = value;
            OnPropertyChanged();
        }
    }

    private Color _borderColorFocusedOriginUf = Colors.Gray;
    public Color BorderColorFocusedOriginUf
    {
        get => _borderColorFocusedOriginUf;
        set
        {
            _borderColorFocusedOriginUf = value;
            OnPropertyChanged();
        }
    }

    private Color _borderColorOriginUf = Colors.LightGray;
    public Color BorderColorOriginUf
    {
        get => _borderColorOriginUf;
        set
        {
            _borderColorOriginUf = value;
            OnPropertyChanged();
        }
    }

    private Color _borderColorFocusedOrigin = Colors.Gray;
    public Color BorderColorFocusedOrigin
    {
        get => _borderColorFocusedOrigin;
        set
        {
            _borderColorFocusedOrigin = value;
            OnPropertyChanged();
        }
    }

    private Color _borderColorOrigin = Colors.LightGray;
    public Color BorderColorOrigin
    {
        get => _borderColorOrigin;
        set
        {
            _borderColorOrigin = value;
            OnPropertyChanged();
        }
    }

    private Color _borderColorFocusedDestinationUf = Colors.Gray;
    public Color BorderColorFocusedDestinationUf
    {
        get => _borderColorFocusedDestinationUf;
        set
        {
            _borderColorFocusedDestinationUf = value;
            OnPropertyChanged();
        }
    }

    private Color _borderColorDestinationUf = Colors.LightGray;
    public Color BorderColorDestinationUf
    {
        get => _borderColorDestinationUf;
        set
        {
            _borderColorDestinationUf = value;
            OnPropertyChanged();
        }
    }

    private Color _borderColorFocusedDestination = Colors.Gray;
    public Color BorderColorFocusedDestination
    {
        get => _borderColorFocusedDestination;
        set
        {
            _borderColorFocusedDestination = value;
            OnPropertyChanged();
        }
    }

    private Color _borderColorDestination = Colors.LightGray;
    public Color BorderColorDestination
    {
        get => _borderColorDestination;
        set
        {
            _borderColorDestination = value;
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

    #endregion

    public ICommand SaveCommand { get; set; }

    public AddFreightViewModel()
    {
        _freightRepository = new FreightRepository();
        SaveCommand = new Command(OnSave);
    }
  
    #region Private Methods

    private async Task EditFreight()
    {
        try
        {
            var item = new FreightModel
            {
                Id = SelectedFreightToEdit.Id,
                TravelDate = TravelDate.Date,
                OriginUf = SelectedItemOriginUf,
                Origin = SelectedItemOrigin,
                DestinationUf = SelectedItemDestinationUf,
                Destination = SelectedItemDestination,
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
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }

    private Task SetValuesToEdit()
    {
        if (SelectedFreightToEdit != null)
        {
            TextTitlePage = "Editar Frete";
            TravelDate = SelectedFreightToEdit.TravelDate;
            SelectedItemOriginUf = SelectedFreightToEdit.OriginUf;
            SelectedItemOrigin = SelectedFreightToEdit.Origin;            
            Kilometer = SelectedFreightToEdit.Kilometer.ToString();
            FreightValue = SelectedFreightToEdit.FreightValue.ToString();
            Observation = SelectedFreightToEdit.Observation;
            SelectedItemDestinationUf = SelectedFreightToEdit.DestinationUf;
            SelectedItemDestination = SelectedFreightToEdit.Destination;
        }

        return Task.CompletedTask;
    }
   
    private async Task<List<string>> LoadCitiesByState(string state)
    {
        IsBusy = true;

        try
        {           
            var list = await DataIbgeService.GetCitiesByCodeState(state);

            if(list == null)
            {              
                ToastFailConectionService.ShowToastMessageFailConnection();
            }

            return list.Select(x => x.Nome).ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new List<string>();
        }
        finally
        {
            IsBusy = false;
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
        model.TravelDate = TravelDate.Date;
        model.OriginUf = SelectedItemOriginUf;
        model.Origin = SelectedItemOrigin;
        model.DestinationUf = SelectedItemDestinationUf;
        model.Destination = SelectedItemDestination;
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
      
    private void LoadStateAcronyms()
    {
        OriginUfCollection = new ObservableCollection<string>(StateAcronymsStr.GetAll());
        DestinationUfCollection = new ObservableCollection<string>(StateAcronymsStr.GetAll());
    }

    public async void ChangedItemOriginUf(string state)
    {
        OriginCollection = new ObservableCollection<string>(await LoadCitiesByState(state));
    }

    public async void ChangedItemDestinationUf(string state)
    {
        DestinationCollection = new ObservableCollection<string>(await LoadCitiesByState(state));
    }

    public void OnAppearing()
    {
        LoadStateAcronyms();
    }

    #endregion   
}
