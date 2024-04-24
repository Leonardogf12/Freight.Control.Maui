using freight.control.maui.Components;
using freight.control.maui.MVVM.Base.Views;
using freight.control.maui.MVVM.ViewModels;

namespace freight.control.maui.MVVM.Views
{
    public class LoginView : BaseContentPage
	{        
		public LoginViewModel ViewModel = new();

        public LoginView()
		{           
            BackgroundColor = Colors.White;

            Content = BuildLoginView();

			BindingContext = ViewModel;
        }

        #region UI

        private Grid CreateMainGrid()
        {
            return new Grid
            {
                RowDefinitions = new RowDefinitionCollection
                {
                    new() {Height = GridLength.Auto},
                    new() {Height = GridLength.Auto},
                    new() {Height = GridLength.Auto},
                    new() {Height = GridLength.Auto},
                    new() {Height = GridLength.Auto},
                },
                RowSpacing = 10,
                VerticalOptions = LayoutOptions.Center
            };
        }

        private View BuildLoginView()
        {
            var mainGrid = CreateMainGrid();

            CreateEmailField(mainGrid);
            CreatePasswordField(mainGrid);
            CreateLoginButton(mainGrid);
            CreateRegisterButton(mainGrid);
            CreateForgetPasswordButton(mainGrid);

            return mainGrid;
        }

        private void CreateEmailField(Grid mainGrid)
        {
            var email = new TextEditCustom(icon: "", placeholder: "Email", keyboard: Keyboard.Email)
            {
                Margin = 10
            };
            email.SetBinding(TextEditCustom.TextProperty, nameof(ViewModel.Email));

            mainGrid.Add(email, 0, 0);
        }

        private void CreatePasswordField(Grid mainGrid)
        {
            var password = new PasswordEditCustom(icon: "", placeholder: "Senha")
            {
                Margin = 10
            };
            password.SetBinding(TextEditCustom.TextProperty, nameof(ViewModel.Password));

            mainGrid.Add(password, 0, 1);
        }

        private void CreateLoginButton(Grid mainGrid)
        {
            var buttonLogin = new Button
            {
                Text = "Login",
                Style = (Style)App.Current.Resources["buttonDarkPrimary"]
            };

            buttonLogin.Clicked += ButtonLogin_Clicked;

            mainGrid.Add(buttonLogin, 0, 2);
        }

        private void CreateRegisterButton(Grid mainGrid)
        {
            var buttonRegister = new Button
            {
                Text = "Registrar",
                Style = (Style)App.Current.Resources["buttonDarkPrimary"]
            };

            buttonRegister.Clicked += ButtonRegister_Clicked;

            mainGrid.Add(buttonRegister, 0, 3);
        }

        private void CreateForgetPasswordButton(Grid mainGrid)
        {
            var button = new Button
            {
                Text = "Esqueceu a Senha?",
                Style = (Style)App.Current.Resources["buttonDarkPrimary"]
            };

            mainGrid.Add(button, 0, 4);
        }

        #endregion

        #region Events

        private async void ButtonLogin_Clicked(object sender, EventArgs e)
        {
            await ViewModel.Login();
        }

        private async void ButtonRegister_Clicked(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PushAsync(new RegisterView());
        }

        #endregion
    }
}

