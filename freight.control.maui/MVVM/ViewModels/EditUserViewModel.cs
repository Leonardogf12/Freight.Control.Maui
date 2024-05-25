using freight.control.maui.Constants;
using freight.control.maui.MVVM.Base.ViewModels;
using freight.control.maui.MVVM.Models;
using freight.control.maui.Repositories;

namespace freight.control.maui.MVVM.ViewModels;

public class EditUserViewModel : BaseViewModel
{
    private readonly UserRepository _userRepository;

    private string _name;
    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged();
        }
    }

    public EditUserViewModel()
	{
        _userRepository = new();
    }

    public async Task SetNameForUser()
    {
        IsBusy = true;

        try
        {
            var user = await _userRepository.GetUserByFirebaseLocalId(App.UserLocalIdLogged);

            if (user != null && user.Name != StringConstants.Usuario)
            {
                await _userRepository.UpdateAsync(CreateModelToEdit(user));
                await App.Current.MainPage.DisplayAlert("Sucesso", "Nome de Usuário editado com sucesso!", "Ok");
                return;
            }

            await _userRepository.SaveAsync(CreateModelToSave());

            await App.Current.MainPage.DisplayAlert("Sucesso", "Nome Usuário definido com sucesso!", "Ok");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            IsBusy = false;
        }
    }

    private UserModel CreateModelToEdit(UserModel oldModel)
    {
        var newModel = oldModel;
        newModel.Name = Name;

        return newModel;       
    }

    private UserModel CreateModelToSave()
    {
        return new UserModel
        {
            Name = Name,
            FirebaseLocalId = App.UserLocalIdLogged
        };
    }
}
