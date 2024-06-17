using freight.control.maui.Components.UI;
using freight.control.maui.Controls.Resources;
using freight.control.maui.MVVM.Base.Views;
using freight.control.maui.MVVM.ViewModels;
using Microsoft.Maui.Controls.Shapes;

namespace freight.control.maui.MVVM.Views
{
    public class LoginView : BaseContentPage
	{
        public LoginViewModel ViewModel = new();

        public LoginView()
		{           
            BackgroundColor = ControlResources.GetResource<Color>("PrimaryDark");

            Content = BuildLoginView();

            CreateLoadingPopupView(this, ViewModel);

            BindingContext = ViewModel;
        }

        #region UI

        private Grid CreateMainGrid()
        {
            return new Grid
            {
                RowDefinitions = new RowDefinitionCollection
                {
                    new() {Height = 200},
                    new() {Height = GridLength.Star},                  
                },                              
            };
        }
      
        private View BuildLoginView()
        {
            var mainGrid = CreateMainGrid();

            CreateImageLogin(mainGrid);

            CreateContentOfWhiteFrame(mainGrid);
           
            return mainGrid;
        }

        private void CreateContentOfWhiteFrame(Grid mainGrid)
        {
            var whiteFrame = new Border
            {
                BackgroundColor = Colors.White,                
                StrokeShape = new RoundRectangle
                {
                    CornerRadius = new CornerRadius(20,20,0,0)
                },
                StrokeThickness = 0                                
            };

            var contentGrid = new Grid
            {
                RowDefinitions = new RowDefinitionCollection
                {
                    new() {Height = GridLength.Auto},
                    new() {Height = GridLength.Auto},
                    new() {Height = GridLength.Auto},
                    new() {Height = GridLength.Auto},         
                },
                RowSpacing = 10,
                VerticalOptions = LayoutOptions.Start,
                Margin = new Thickness(0,30,0,0)
            };

            CreateEmailField(contentGrid);
            CreatePasswordField(contentGrid);
            CreateLoginButton(contentGrid);
            CreateForgetPasswordButton(contentGrid);

            whiteFrame.Content = contentGrid;

            mainGrid.Add(whiteFrame,0,1);
        }

        private void CreateImageLogin(Grid mainGrid)
        {
            var iconUser = new Image
            {
                Source = ImageSource.FromFile("login_gray_256"),
                HeightRequest = 100
            };

            mainGrid.Add(iconUser, 0, 0);
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
                Style = (Style)Application.Current.Resources["buttonLoginDarkPrimary"]
            };

            buttonLogin.Clicked += ButtonLogin_Clicked;

            mainGrid.Add(buttonLogin, 0, 2);
        }

        private void CreateRegisterButton(Grid mainGrid)
        {
            var buttonRegister = new Button
            {
                Text = "Registrar",
                Style = (Style)Application.Current.Resources["buttonDarkPrimary"]
            };

            buttonRegister.Clicked += ButtonRegister_Clicked;

            mainGrid.Add(buttonRegister, 0, 4);
        }

        private void CreateForgetPasswordButton(Grid mainGrid)
        {
            var buttonForgotPassword = new Label
            {
                Text = "Esqueceu a Senha?",
                Style = (Style)Application.Current.Resources["labelForgotPassword"]
            };

            var tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += ButtonForgotPassword_Clicked;
            buttonForgotPassword.GestureRecognizers.Add(tapGesture);

            mainGrid.Add(buttonForgotPassword, 0, 3);
        }

        #endregion

        #region Events

        private async void ButtonForgotPassword_Clicked(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ResetPasswordView());
        }

        private async void ButtonLogin_Clicked(object sender, EventArgs e)
        {            
            if (string.IsNullOrEmpty(ViewModel.Email) || string.IsNullOrEmpty(ViewModel.Password)) return;
            
            await ViewModel.Login();
        }

        private async void ButtonRegister_Clicked(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new RegisterView());
        }

        #endregion       
    }
}

