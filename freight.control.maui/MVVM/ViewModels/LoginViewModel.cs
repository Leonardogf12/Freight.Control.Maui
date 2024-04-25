using Firebase.Auth;
using freight.control.maui.Constants;
using freight.control.maui.MVVM.Base.ViewModels;
using Newtonsoft.Json;

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
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(StringConstants.webApiFirebaseAuthKey));
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(Email, Password);              
                var content = await auth.GetFreshAuthAsync();

                var serializeContent = JsonConvert.SerializeObject(content);

                Preferences.Set("FirebaseAuthToken", serializeContent);

                await NavigateToHomeView();
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Ops", "Email ou senha inválidos. Favor verificar.", "Ok");
            }
            finally
            {
                IsBusy = false;
            }                 
        }

        private async Task NavigateToHomeView()
        {      
            await Shell.Current.GoToAsync("//home");           
        }
    }
}

