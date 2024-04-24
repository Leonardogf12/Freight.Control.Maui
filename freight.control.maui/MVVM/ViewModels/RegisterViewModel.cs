using Firebase.Auth;
using freight.control.maui.Constants;
using freight.control.maui.MVVM.Base.ViewModels;

namespace freight.control.maui.MVVM.ViewModels
{
    public class RegisterViewModel : BaseViewModel
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

        public async Task RegisterNewLogin()
        {
            try
            {               
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(StringConstants.webApiFirebaseAuthKey));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(Email, Password);

                var tokenResult = auth.FirebaseToken;

                await App.Current.MainPage.DisplayAlert("Sucesso", "Usuário registrado com sucesso!", "Voltar");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Ops", ex.Message, "Ok");
            }
        }
    }
}

