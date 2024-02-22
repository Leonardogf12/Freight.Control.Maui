using System.Collections.ObjectModel;
using System.Windows.Input;
using freight.control.maui.MVVM.Base.ViewModels;
using freight.control.maui.MVVM.Models;
using freight.control.maui.Repositories;

namespace freight.control.maui.MVVM.ViewModels;

public class FreightViewModel : BaseViewModel
{

    #region Properties
   
    private readonly FreightRepository _freightRepository;
    private readonly ToFuelRepository _toFuelRepository;
    
    private ObservableCollection<FreightModel> _freightCollection = new();
    public ObservableCollection<FreightModel> FreightCollection
	{
		get => _freightCollection;
		set
		{
			_freightCollection = value;
			OnPropertyChanged();            
		}
	}

    private bool _isVisibleTextAddNewFreight = false;
    public bool IsVisibleTextAddNewFreight
    {
        get => _isVisibleTextAddNewFreight;
        set
        {
            _isVisibleTextAddNewFreight = value;
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
        }
    }

    private DateTime _initialDate = DateTime.Now;
    public DateTime InitialDate
    {

        get => _initialDate;
        set
        {
            _initialDate = value;
            OnPropertyChanged();
        }
    }

    private DateTime _finalDate = DateTime.Now;
    public DateTime FinalDate
    {

        get => _finalDate;
        set
        {
            _finalDate = value;
            OnPropertyChanged();
        }
    }

    private bool _isRefreshingView;
    public bool IsRefreshingView
    {
        get => _isRefreshingView;
        set
        {
            _isRefreshingView = value;
            OnPropertyChanged();
        }
    }

    public ICommand RefreshingCommand;

    #endregion

    public FreightViewModel()
    {
        _freightRepository = new();
        _toFuelRepository = new();        

        RefreshingCommand = new Command(OnRefreshingCommand);
    }

    #region Methods Privates
    
    private async void OnRefreshingCommand()
    {
        await LoadFreigths();

        IsRefreshingView = false;
    }

    private void CheckIfThereAreFreightItemsInCollection()
    {
        IsVisibleTextAddNewFreight = FreightCollection.Count == 0;
    }

    private async Task LoadFreigths()
    {
        FreightCollection.Clear();

        var list = await _freightRepository.GetAllAsync();

        FreightCollection = new ObservableCollection<FreightModel>(list.OrderByDescending(x=>x.TravelDate));

        CheckIfThereAreFreightItemsInCollection();
    }

    private bool CheckDatesToFilterData()
    {
        if (FinalDate < InitialDate) return false;

        if (InitialDate > FinalDate) return false;

        return true;
    }

    #endregion

    #region Methods Publics
    
    public async Task DeleteFreight(FreightModel model)
    {
        var result = await _freightRepository.DeleteAsync(model);

        var isDeletedAll = await _toFuelRepository.DeleteByIdFreightAsync(model.Id);

        if(result > 0 && isDeletedAll)
        {
            FreightCollection.Remove(model);

            await App.Current.MainPage.DisplayAlert("Sucesso", "Item excluido com sucesso!","Ok");
        }
        else
        {
            await App.Current.MainPage.DisplayAlert("Ops", "Parece que ocorreu um problema ao tentar excluir os abastecimentos deste Frete. Favor conferir.", "Ok");
        }

        CheckIfThereAreFreightItemsInCollection();
    }

    public async void OnAppearing()
    {
        await LoadFreigths();        
    }

    public async Task FilterFreights()
    {
        if (!CheckDatesToFilterData())
        {
            await App.Current.MainPage.DisplayAlert("Ops", "A data final deve ser maior ou igual a data inicial. Favor verificar.", "Ok");
            return;
        }
       
        var dataFiltered = await _freightRepository.GetByDateInitialAndFinal(initial: InitialDate, final: FinalDate);

        if (!dataFiltered.Any())
        {
            await App.Current.MainPage.DisplayAlert("Filtro", "Nenhum registro foi encontrado para o período informado.", "Ok");
            return;
        }

        FreightCollection.Clear();

        FreightCollection = new ObservableCollection<FreightModel>(dataFiltered);
    }
   
    public async Task<List<FreightModel>> GetFreightsToExport()
    {       
        if (!CheckDatesToFilterData())
        {
            await App.Current.MainPage.DisplayAlert("Ops", "A data final deve ser maior ou igual a data inicial. Favor verificar.", "Ok");
            return null;
        }

        var dataFiltered = await _freightRepository.GetByDateInitialAndFinal(initial: InitialDate, final: FinalDate);

        if (!dataFiltered.Any())
        {
            await App.Current.MainPage.DisplayAlert("Filtro", "Nenhum registro foi encontrado para o período informado.", "Ok");
            return null;
        }

        return dataFiltered;       
    }

    public async Task<List<ToFuelModel>> GetFreightSupplies(FreightModel item)
    {
        var list =  await _toFuelRepository.GetAllById(item.Id);

        return list.ToList();
    }
    #endregion
}
