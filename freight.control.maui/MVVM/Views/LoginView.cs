using DevExpress.Maui.Editors;
using freight.control.maui.Components;
using freight.control.maui.MVVM.Base.Views;
using freight.control.maui.MVVM.ViewModels;
using freight.control.maui.Services;

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
            var email = new TextEditCustom(icon:"",placeholder: "Email",keyboard: Keyboard.Email)
            {
                Margin = 10
            };

            mainGrid.Add(email, 0, 0);
        }

        private void CreatePasswordField(Grid mainGrid)
        {
            var password = new PasswordEdit()
            {
                Margin = 10
            };

            mainGrid.Add(password, 0, 1);
        }

        private void CreateLoginButton(Grid mainGrid)
        {
            var button = new Button
            {
                Text = "Login",
                Style = (Style)App.Current.Resources["buttonDarkPrimary"]
            };

            mainGrid.Add(button, 0, 2);
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

        private async void ButtonRegister_Clicked(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PushAsync(new RegisterView());
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
    }
}

