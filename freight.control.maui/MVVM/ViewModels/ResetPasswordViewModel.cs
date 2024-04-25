using Firebase.Auth;
using freight.control.maui.Constants;
using freight.control.maui.MVVM.Base.ViewModels;

namespace freight.control.maui.MVVM.ViewModels
{
    public class ResetPasswordViewModel : BaseViewModel
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

		#endregion

        public ResetPasswordViewModel()
		{
		}

		public async Task ResetPassword()
		{
			try
			{
				IsBusy = true;

                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(StringConstants.webApiFirebaseAuthKey));
                await authProvider.SendPasswordResetEmailAsync(Email);

                await App.Current.MainPage.DisplayAlert("Sucesso", $"Enviamos um email para que possa redefinir sua senha da conta: {Email}.", "Ok");
            }
			catch (Exception ex)
			{
                await App.Current.MainPage.DisplayAlert("Ops", "Parece que ocorreu um erro com o email informado. Por favor, tente novamente em alguns minutos.", "Ok");
            }
			finally
			{
                IsBusy = false;
            }   
        }
	}
}

