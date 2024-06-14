using freight.control.maui.MVVM.Base.ViewModels;
using freight.control.maui.Services.Authentication;

namespace freight.control.maui.MVVM.ViewModels
{
    public class ResetPasswordViewModel : BaseViewModel
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

        public ResetPasswordViewModel()
		{
		}

		public async Task ResetPassword()
		{
            IsBusy = true;

            try
            {               
                var instanceAuthenticationResetPassword = MyInterfaceFactoryAuthenticationService.CreateInstance();

                await instanceAuthenticationResetPassword.ResetPassword(Email);
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

