using Firebase.Auth;
using freight.control.maui.Constants;
using freight.control.maui.MVVM.Base.ViewModels;
using freight.control.maui.MVVM.Views;
using Newtonsoft.Json;

namespace freight.control.maui.MVVM.ViewModels
{
	public class LoginViewModel : BaseViewModel
	{

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


        public LoginViewModel()
		{
		}

        public async Task Login()
        {
            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(StringConstants.webApiFirebaseAuthKey));
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(Email, Password);
                var content = await auth.GetFreshAuthAsync();

                var serializeContent = JsonConvert.SerializeObject(content);

                Preferences.Set("FirebaseAuthToken", serializeContent);

                await App.Current.MainPage.Navigation.PushAsync(new HomeView());
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Ops", ex.Message, "Ok");                
            }                 
        }
    }
}

