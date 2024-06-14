using freight.control.maui.MVVM.Base.ViewModels;
using freight.control.maui.Services.Authentication;

namespace freight.control.maui.MVVM.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region Properties

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

        #endregion

        public LoginViewModel()
        {           
        }

        public async Task Login()
        {
            IsBusy = true;

            try
            {               
                var instanceAuthenticationLogin = MyInterfaceFactoryAuthenticationService.CreateInstance();

                await instanceAuthenticationLogin.LoginAsync(Email, Password);                
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

