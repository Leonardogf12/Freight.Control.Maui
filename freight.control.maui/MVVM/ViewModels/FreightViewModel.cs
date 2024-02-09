using System.Collections.ObjectModel;
using freight.control.maui.MVVM.Base.ViewModels;
using freight.control.maui.MVVM.Models;

namespace freight.control.maui.MVVM.ViewModels;

public class FreightViewModel : BaseViewModel
{

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



    public FreightViewModel()
    {        
    }

    private void LoadFreigthsMock()
    {
        FreightCollection.Clear();

        var list = new List<FreightModel> {
			new FreightModel
			{
				TravelDate = DateTime.Now,
                Origin = "Linhares - ES",
				Destination = "São Paulo - SP",
				Kilometer = 1500.00,
				FreightValue = 7500.00M,
				Observation = "Frete 01 - apenas um teste"		
			},
            new FreightModel
            {
                TravelDate = DateTime.Now.AddDays(1),
                Origin = "Linhares - ES",
                Destination = "Vitoria - ES",
                Kilometer = 145,
                FreightValue = 2000,
                Observation = "Frete 02 - apenas um teste, segundo frete"
            },
            new FreightModel
            {
                TravelDate = DateTime.Now.AddDays(2),
                Origin = "Linhares - ES",
                Destination = "Sao Jose dos Campos - SP",
                Kilometer = 1620,
                FreightValue = 8500.60M,
                Observation = "Frete 03 - apenas um teste, segundo frete"
            },
            new FreightModel
            {
                TravelDate = DateTime.Now.AddDays(4),
                Origin = "Linhares - ES",
                Destination = "São Paulo - SP",
                Kilometer = 1500.00,
                FreightValue = 7500.00M,
                Observation = "Frete 01 - apenas um teste"
            },
            new FreightModel
            {
                TravelDate = DateTime.Now.AddDays(6),
                Origin = "Linhares - ES",
                Destination = "Vitoria - ES",
                Kilometer = 145,
                FreightValue = 2000,
                Observation = "Frete 02 - apenas um teste, segundo frete"
            },
            new FreightModel
            {
                TravelDate = DateTime.Now.AddDays(10),
                Origin = "Linhares - ES",
                Destination = "Sao Jose dos Campos - SP",
                Kilometer = 1620,
                FreightValue = 8500.60M,
                Observation = "Frete 03 - apenas um teste, segundo frete"
            }
        };

		FreightCollection = new ObservableCollection<FreightModel>(list);
                
    }

    public void OnAppearing()
    {
        LoadFreigthsMock();       
    }
}
