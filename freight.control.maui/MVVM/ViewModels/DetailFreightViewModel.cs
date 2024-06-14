using System.Collections.ObjectModel;
using System.Windows.Input;
using freight.control.maui.MVVM.Base.ViewModels;
using freight.control.maui.MVVM.Models;
using freight.control.maui.Repositories;

namespace freight.control.maui.MVVM.ViewModels
{
    [QueryProperty(nameof(SelectedFreightToDetail), "SelectedFreightToDetail")]
    public class DetailFreightViewModel : BaseViewModel
    {

        #region Properties

        private readonly ToFuelRepository _toFuelRepository;

        private ObservableCollection<ToFuelModel> _toFuelCollection = new();
        public ObservableCollection<ToFuelModel> ToFuelCollection
        {
            get => _toFuelCollection;
            set
            {
                _toFuelCollection = value;
                OnPropertyChanged();
            }
        }

        //FreightListRemainingItems
        private List<ToFuelModel> _toFuelListRemainingItems = new();
        public List<ToFuelModel> ToFuelListRemainingItems
        {
            get => _toFuelListRemainingItems;
            set
            {
                _toFuelListRemainingItems = value;
                OnPropertyChanged();
            }
        }

        private FreightModel _detailFreightModel = new();
        public FreightModel DetailFreightModel
        {
            get => _detailFreightModel;
            set
            {
                _detailFreightModel = value;
                OnPropertyChanged();
            }
        }

        private FreightModel _selectedFreightToDetail;
        public FreightModel SelectedFreightToDetail
        {
            get => _selectedFreightToDetail;
            set
            {
                _selectedFreightToDetail = value;
                OnPropertyChanged();

                SetValuesToDetails();
            }
        }

        private bool _isVisibleTextPhraseToFuelEmpty = false;
        public bool IsVisibleTextPhraseToFuelEmpty
        {
            get => _isVisibleTextPhraseToFuelEmpty;
            set
            {
                _isVisibleTextPhraseToFuelEmpty = value;
                OnPropertyChanged();
            }
        }

        private bool _isLoadingMoreToFuelItems;
        public bool IsLoadingMoreToFuelItems
        {
            get => _isLoadingMoreToFuelItems;
            set
            {
                _isLoadingMoreToFuelItems = value;
                OnPropertyChanged();
            }
        }

        #region DetailFreight

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

        private string _detailKm = string.Empty;
        public string DetailKm
        {
            get => _detailKm;
            set
            {
                _detailKm = value;
                OnPropertyChanged();
            }
        }

        private string _detailTotalFreight = string.Empty;
        public string DetailTotalFreight
        {
            get => _detailTotalFreight;
            set
            {
                _detailTotalFreight = value;
                OnPropertyChanged();
            }
        }

        private string _detailTotalLiters = string.Empty;
        public string DetailTotalLiters
        {
            get => _detailTotalLiters;
            set
            {
                _detailTotalLiters = value;
                OnPropertyChanged();
            }
        }

        private string _detailTotalSpendInLiters = string.Empty;
        public string DetailTotalSpendInLiters
        {
            get => _detailTotalSpendInLiters;
            set
            {
                _detailTotalSpendInLiters = value;
                OnPropertyChanged();
            }
        }

        private string _totalFuel = string.Empty;
        public string TotalFuel
        {
            get => _totalFuel;
            set
            {
                _totalFuel = value;
                OnPropertyChanged();
            }
        }

        private string _totalSpentLiters;
        public string TotalSpentLiters
        {
            get => _totalSpentLiters;
            set
            {
                _totalSpentLiters = value;
                OnPropertyChanged();
            }
        }

        #endregion

        private readonly int _toFuelQtyItemsPage = 3;

        public ICommand LoadMoreItemToFuelCommand;

        #endregion

        public DetailFreightViewModel()
        {
            _toFuelRepository = new();

            LoadMoreItemToFuelCommand = new Command(OnLoadMoreItemToFuelCommand);
        }
       
        #region Private Methods

        private void SetValuesToDetails()
        {
            DetailTravelDate = SelectedFreightToDetail.TravelDate.ToShortDateString();
            DetailOrigin = $"{SelectedFreightToDetail.Origin} - {SelectedFreightToDetail.OriginUf}";
            DetailDestination = $"{SelectedFreightToDetail.Destination} - {SelectedFreightToDetail.DestinationUf}";
            DetailKm = SelectedFreightToDetail.Kilometer.ToString();
            DetailTotalFreight = SelectedFreightToDetail.FreightValue.ToString("c");
        }

        private void CheckForItemsInCollection()
        {
            IsVisibleTextPhraseToFuelEmpty = ToFuelCollection.Count == 0;
        }

        private async Task LoadCollection()
        {           
            ToFuelCollection.Clear();

            ToFuelListRemainingItems = await _toFuelRepository.GetAllById(SelectedFreightToDetail.Id);

            App.Current.Dispatcher.Dispatch(() => {

                var toBeAdded = ToFuelListRemainingItems.Take(_toFuelQtyItemsPage).ToList();

                toBeAdded.ForEach(ToFuelCollection.Add);
            });
        }

        private async void OnLoadMoreItemToFuelCommand()
        {
            if (IsLoadingMoreToFuelItems) return;

            try
            {
                if (ToFuelListRemainingItems?.Count > 0 && ToFuelCollection.Count < ToFuelListRemainingItems?.Count)
                {
                    IsLoadingMoreToFuelItems = true;

                    await Task.Delay(700);

                    var remaningItems = ToFuelListRemainingItems.Skip(ToFuelCollection.Count).Take(_toFuelQtyItemsPage).ToList();

                    remaningItems.ForEach(ToFuelCollection.Add);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                IsLoadingMoreToFuelItems = false;               
            }
        }

        private void CalcTotalFuelAndSpent()
        {
            TotalFuel = ToFuelCollection.Select(x => x.Liters).Sum().ToString();
            TotalSpentLiters = ToFuelCollection.Select(x => x.AmountSpentFuel).Sum().ToString("c");
        }

        #endregion

        #region Public Methods

        public async Task DeleteSupply(ToFuelModel model)
        {
            var result = await _toFuelRepository.DeleteAsync(model);

            if (result > 0)
            {
                ToFuelCollection.Remove(model);

                await Application.Current.MainPage.DisplayAlert("Sucesso", "Item excluido com sucesso!", "Ok");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Ops", "Parece que ocorreu um problema. Favor tentar novamente.", "Ok");
            }

            CheckForItemsInCollection();
            CalcTotalFuelAndSpent();
        }

        public async Task OnAppearing()
        {
            await LoadCollection();
        }

        #endregion
    }
}