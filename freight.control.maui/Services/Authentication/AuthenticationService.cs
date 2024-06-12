using Firebase.Auth;
using freight.control.maui.Constants;
using freight.control.maui.Controls;

namespace freight.control.maui.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
	{
		public AuthenticationService()
		{
		}

        public async Task LoginAsync(string email, string password)
        {           
            try
            {
                if (!ToastFailConectionService.CheckIfConnectionIsSuccessful())
                {
                    ToastFailConectionService.ShowToastMessageFailConnection();
                    return;
                }

                var authProvider = GetFirebaseAuthProvider();
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(email, password);
                var content = await auth.GetFreshAuthAsync();

                SaveKeysOnPreferences(content);
                App.SetLocalIdByUserLogged();

                await Shell.Current.GoToAsync("//home");
            }
            catch (FirebaseAuthException f)
            {
                if (f.ResponseData.Contains("INVALID_LOGIN_CREDENTIALS"))
                {
                    await App.Current.MainPage.DisplayAlert("Ops", "Email ou senha inválidos. Favor verificar.", "Ok");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace.ToString());
                await App.Current.MainPage.DisplayAlert("Ops", "Ocorreu um erro inesperado ao tentar realizar login. Tente novamente em alguns instantes.", "Ok");
            }            
        }

        private void SaveKeysOnPreferences(FirebaseAuthLink content)
        {
            ControlPreferences.AddKeyOnPreferences(key: StringConstants.firebaseAuthTokenKey, contentOfObject: content);
            ControlPreferences.AddKeyOnPreferences(key: StringConstants.firebaseUserLocalIdKey, contentOfObject: content.User.LocalId);
        }

        public async Task ResetPassword(string email)
        {
            try
            {
                if (!ToastFailConectionService.CheckIfConnectionIsSuccessful())
                {
                    ToastFailConectionService.ShowToastMessageFailConnection();
                    return;
                }

                var authProvider = GetFirebaseAuthProvider();
                await authProvider.SendPasswordResetEmailAsync(email);

                await App.Current.MainPage.DisplayAlert("Sucesso", $"Enviamos um email para ({email}) com as instruções para redefinir a senha.", "Ok");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace.ToString());                
                await App.Current.MainPage.DisplayAlert("Ops", "Ocorreu um erro inesperado ao tentar redefinir nova senha. Tente novamente em alguns instantes.", "Ok");
            }
        }

        public async Task RegisterNewUser(string name, string email, string password)
        {           
            try
            {
                var authProvider = GetFirebaseAuthProvider();
                
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(email, password);

                await auth.UpdateProfileAsync(name, string.Empty);
                
                await App.Current.MainPage.DisplayAlert("Sucesso", "Usuário registrado com sucesso!", "Voltar");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace.ToString());
                await App.Current.MainPage.DisplayAlert("Ops", "Ocorreu um erro inesperado ao tentar registrar um novo usuário. Tente novamente em alguns instantes.", "Ok");
            }           
        }

        private FirebaseAuthProvider GetFirebaseAuthProvider()
        {
            return new FirebaseAuthProvider(new FirebaseConfig(StringConstants.webApiFirebaseAuthKey));
        }       
    }

    public class MyInterfaceFactoryAuthenticationService
    {
        public static IAuthenticationService CreateInstance()
        {
            return new AuthenticationService();
        }
    }
}

