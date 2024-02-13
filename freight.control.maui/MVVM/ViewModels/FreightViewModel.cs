using System.Collections.ObjectModel;
using freight.control.maui.MVVM.Base.ViewModels;
using freight.control.maui.MVVM.Models;
using freight.control.maui.Repositories;

namespace freight.control.maui.MVVM.ViewModels;

public class FreightViewModel : BaseViewModel
{
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


    public FreightViewModel()
    {
        _freightRepository = new();
        _toFuelRepository = new();
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
}
