using freight.control.maui.MVVM.Base.ViewModels;

namespace freight.control.maui.MVVM.ViewModels;

public class ExportViewModel : BaseViewModel
{

	private DateTime _initialDate = DateTime.Now;
	public DateTime InitialDate {

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



    public ExportViewModel()
	{		
	}

    public void OnSave()
    {

    }
}
