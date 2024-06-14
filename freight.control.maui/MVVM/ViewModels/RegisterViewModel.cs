using freight.control.maui.MVVM.Base.ViewModels;
using freight.control.maui.Services.Authentication;

namespace freight.control.maui.MVVM.ViewModels
{
    public class RegisterViewModel : BaseViewModel
	{
        #region Properties

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

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        private string _secondPassword;
        public string SecondPassword
        {
            get => _secondPassword;
            set
            {
                _secondPassword = value;
                OnPropertyChanged();
            }
        }
        
        #endregion

        public RegisterViewModel()
		{
		}

        public async Task RegisterNewUser()
        {
            IsBusy = true;

            try
            {
                var instanceAuthenticationRegisterNewUser = MyInterfaceFactoryAuthenticationService.CreateInstance();

                await instanceAuthenticationRegisterNewUser.RegisterNewUser(Name, Email, Password);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                await Application.Current.MainPage.DisplayAlert("Ops", "Ocorreu um erro inesperado. Tente novamente em alguns instantes.", "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}

