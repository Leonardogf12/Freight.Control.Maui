using System.Collections.ObjectModel;
using freight.control.maui.MVVM.Base.ViewModels;
using freight.control.maui.MVVM.Models;

namespace freight.control.maui.MVVM.ViewModels;

public class DetailFreightViewModel : BaseViewModel
{
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

    public DetailFreightViewModel()
    {
    }

    private void LoadToFuelsMock()
    {
        ToFuelCollection.Clear();

        var list = new List<ToFuelModel> {
            new ToFuelModel
            {
                Date = DateTime.Now,
                Liters = 150.50,
                AmountSpentFuel = 580.65M,
                ValuePerLiter = 5.65M,
                Expenses = 75M,
                Observation = "Observacao de numero 1"
            },
            new ToFuelModel
            {
                Date = DateTime.Now.AddDays(2),
                Liters = 320.00,
                AmountSpentFuel = 754.45M,
                ValuePerLiter = 6.55M,
                Expenses = 90M,
                Observation = "Outra observacao"
            },
            new ToFuelModel
            {
                Date = DateTime.Now.AddDays(4),
                Liters = 360.00,
                AmountSpentFuel = 640.78M,
                ValuePerLiter = 5.55M,
                Expenses = 15M,
                Observation = "Terceira observacao, e dessa vez é maior que as outras."
            },

        };

        ToFuelCollection = new ObservableCollection<ToFuelModel>(list);

    }

    private void LoadDetailFreightMock()
    {
       
        DetailFreightModel = new FreightModel
        {
            Destination = "Sao PAulo SP",
            Origin = "Linhares ES",
            Kilometer = 1500.00,
            FreightValue = 6500M,
            TravelDate = DateTime.Now,
            Observation = "observacao teste para ver como ficou",            
        };

        DetailTravelDate = DetailFreightModel.TravelDate.ToShortDateString();
        DetailOrigin = DetailFreightModel.Origin;
        DetailDestination = DetailFreightModel.Destination;
        DetailKm = DetailFreightModel.Kilometer.ToString();
        DetailTotalFreight = DetailFreightModel.FreightValue.ToString("c");
        TotalFuel = ToFuelCollection.Select(x=>x.Liters).Sum().ToString();
        TotalSpentLiters = ToFuelCollection.Select(x => x.AmountSpentFuel).Sum().ToString("c");
    }

    public void OnAppearing()
    {
        LoadToFuelsMock();
        LoadDetailFreightMock();
    }
}