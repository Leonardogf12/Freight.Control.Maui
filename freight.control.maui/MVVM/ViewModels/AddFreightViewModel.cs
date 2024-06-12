using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;
using freight.control.maui.Controls;
using freight.control.maui.MVVM.Base.ViewModels;
using freight.control.maui.MVVM.Models;
using freight.control.maui.Repositories;
using freight.control.maui.Services;

namespace freight.control.maui.MVVM.ViewModels
{
    [QueryProperty(nameof(SelectedFreightToEdit), "SelectedFreightToEdit")]
    public class AddFreightViewModel : BaseViewModel
    {
        #region Properties

        private readonly FreightRepository _freightRepository;

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

        private Color _borderColorFreightValue = App.GetLightGrayColor();
        public Color BorderColorFreightValue
        {
            get => _borderColorFreightValue;
            set
            {
                _borderColorFreightValue = value;
                OnPropertyChanged();
            }
        }

        private Color _borderColorFocusedFreightValue = App.GetGrayColor();
        public Color BorderColorFocusedFreightValue
        {
            get => _borderColorFocusedFreightValue;
            set
            {
                _borderColorFocusedFreightValue = value;
                OnPropertyChanged();
            }
        }

        private Color _borderColorKm = App.GetLightGrayColor();
        public Color BorderColorKm
        {
            get => _borderColorKm;
            set
            {
                _borderColorKm = value;
                OnPropertyChanged();
            }
        }

        private Color _borderColorFocusedKm = App.GetGrayColor();
        public Color BorderColorFocusedKm
        {
            get => _borderColorFocusedKm;
            set
            {
                _borderColorFocusedKm = value;
                OnPropertyChanged();
            }
        }

        private Color _borderColorFocusedOriginUf = App.GetGrayColor();
        public Color BorderColorFocusedOriginUf
        {
            get => _borderColorFocusedOriginUf;
            set
            {
                _borderColorFocusedOriginUf = value;
                OnPropertyChanged();
            }
        }

        private Color _borderColorOriginUf = App.GetLightGrayColor();
        public Color BorderColorOriginUf
        {
            get => _borderColorOriginUf;
            set
            {
                _borderColorOriginUf = value;
                OnPropertyChanged();
            }
        }

        private Color _borderColorFocusedOrigin = App.GetGrayColor();
        public Color BorderColorFocusedOrigin
        {
            get => _borderColorFocusedOrigin;
            set
            {
                _borderColorFocusedOrigin = value;
                OnPropertyChanged();
            }
        }

        private Color _borderColorOrigin = App.GetLightGrayColor();
        public Color BorderColorOrigin
        {
            get => _borderColorOrigin;
            set
            {
                _borderColorOrigin = value;
                OnPropertyChanged();
            }
        }

        private Color _borderColorFocusedDestinationUf = App.GetGrayColor();
        public Color BorderColorFocusedDestinationUf
        {
            get => _borderColorFocusedDestinationUf;
            set
            {
                _borderColorFocusedDestinationUf = value;
                OnPropertyChanged();
            }
        }

        private Color _borderColorDestinationUf = App.GetLightGrayColor();
        public Color BorderColorDestinationUf
        {
            get => _borderColorDestinationUf;
            set
            {
                _borderColorDestinationUf = value;
                OnPropertyChanged();
            }
        }

        private Color _borderColorFocusedDestination = App.GetGrayColor();
        public Color BorderColorFocusedDestination
        {
            get => _borderColorFocusedDestination;
            set
            {
                _borderColorFocusedDestination = value;
                OnPropertyChanged();
            }
        }

        private Color _borderColorDestination = App.GetLightGrayColor();
        public Color BorderColorDestination
        {
            get => _borderColorDestination;
            set
            {
                _borderColorDestination = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; set; }

        #endregion

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
                    UserLocalId = SelectedFreightToEdit.UserLocalId,
                    TravelDate = TravelDate.Date,
                    OriginUf = SelectedItemOriginUf,
                    Origin = SelectedItemOrigin,
                    DestinationUf = SelectedItemDestinationUf,
                    Destination = SelectedItemDestination,
                    Kilometer = await ConvertEntrysStringToDouble.ConvertValue(Kilometer),
                    FreightValue = await ConvertEntrysStringToDecimal.ConvertValue(FreightValue),
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
                Kilometer = SelectedFreightToEdit.Kilometer.ToString(CultureInfo.InvariantCulture);
                FreightValue = SelectedFreightToEdit.FreightValue.ToString(CultureInfo.InvariantCulture);
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

                if (list == null)
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

        private async Task<FreightModel> CreateObjectFreightModelToSave()
        {
            var model = new FreightModel()
            {
                UserLocalId = App.UserLocalIdLogged,
                TravelDate = TravelDate.Date,
                OriginUf = SelectedItemOriginUf,
                Origin = SelectedItemOrigin,
                DestinationUf = SelectedItemDestinationUf,
                Destination = SelectedItemDestination,
                Kilometer = await ConvertEntrysStringToDouble.ConvertValue(Kilometer),
                FreightValue = await ConvertEntrysStringToDecimal.ConvertValue(FreightValue),
                Observation = Observation,
            };

            return model;
        }

        private void LoadStateAcronyms()
        {
            var list = new ObservableCollection<string>(StateAcronymsStr.GetAll());

            OriginUfCollection = list;
            DestinationUfCollection = list;
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

            var result = await _freightRepository.SaveAsync(await CreateObjectFreightModelToSave());

            if (result > 0)
            {
                await App.Current.MainPage.DisplayAlert("Sucesso", "Frete criado com sucesso!", "Ok");
                return;
            }

            await App.Current.MainPage.DisplayAlert("Ops", "Parece que houve um erro durante a criação do Frete. Por favor, tente novamente.", "Ok");
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
}