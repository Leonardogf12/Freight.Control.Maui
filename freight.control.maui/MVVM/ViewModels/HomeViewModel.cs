using freight.control.maui.Constants;
using freight.control.maui.MVVM.Base.ViewModels;
using freight.control.maui.MVVM.Models;
using freight.control.maui.Repositories;

namespace freight.control.maui.MVVM.ViewModels;

public class HomeViewModel : BaseViewModel
{
    private readonly UserRepository _userRepository;

    private readonly FreightRepository _freightRepository;

    private UserModel _userLogged;
	public UserModel UserLogged
	{
		get => _userLogged;
		set
		{
			_userLogged = value;
			OnPropertyChanged();
		}
	}

    private string _nameUserLogged = StringConstants.Usuario;
    public string NameUserLogged
    {
        get => _nameUserLogged;
        set
        {
            _nameUserLogged = value;
            OnPropertyChanged();
        }
    }

    public HomeViewModel()
	{
        _userRepository = new();
        _freightRepository = new();
    }

    public async void LoadInfoByUserLogged()
    {
        var user = await _userRepository.GetUserByFirebaseLocalId(App.UserLocalIdLogged);

        if(user != null)
        {
            NameUserLogged = user.Name;
        }
        else
        {
            NameUserLogged = StringConstants.Usuario;
        }
    }

    public async Task<int> CheckIfExistRecordsToNavigate()
    {
        var result = await _freightRepository.GetByDateInitialAndFinal(initial: new DateTime(DateTime.Now.Year, 01, 01),
                                                                        final: new DateTime(DateTime.Now.Year, 12, 31));

        return result.Count();
    }
}
