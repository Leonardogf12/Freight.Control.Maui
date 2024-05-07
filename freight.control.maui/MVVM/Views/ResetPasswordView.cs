using freight.control.maui.Components;
using freight.control.maui.MVVM.Base.Views;
using freight.control.maui.MVVM.ViewModels;

namespace freight.control.maui.MVVM.Views
{
    public class ResetPasswordView  : BaseContentPage
	{
        public ResetPasswordViewModel ViewModel = new();


        public ResetPasswordView()
		{
			BackgroundColor = Colors.White;

			Content = BuildResetPasswordView();

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

        private View BuildResetPasswordView()
        {
            var mainGrid = CreateMainGrid();

            CreatePhrases(mainGrid);

            CreateInputAndButtons(mainGrid);

            return mainGrid;
        }

        private void CreatePhrases(Grid mainGrid)
        {
            var stack = new StackLayout
            {
                Spacing = 5,
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.Center
            };

            var title = new Label
            {
                Text = "Esqueceu a Senha?",
                Style = (Style)App.Current.Resources["labelTitleForgotPassword"]
            };

            var phrase = new Label
            {
                Text = "Sem problemas, nós enviaremos um email com as instruções para redefinição.",
                Style = (Style)App.Current.Resources["labelPhraseForgotPassword"]
            };

            stack.Children.Add(title);
            stack.Children.Add(phrase);

            mainGrid.Add(stack, 0, 0);
        }

        private void CreateInputAndButtons(Grid mainGrid)
        {
            var grid = new Grid
            {
                RowDefinitions = new RowDefinitionCollection
                {
                    new() {Height = GridLength.Auto},
                    new() {Height = GridLength.Auto},
                    new() {Height = GridLength.Auto},
                },
                RowSpacing = 8,
                VerticalOptions = LayoutOptions.Start
            };

            CreateEmailField(grid);
            CreateResetButton(grid);
            CreateBackButton(grid);

            mainGrid.Add(grid, 0, 1);
        }       

        private void CreateEmailField(Grid mainGrid)
        {
            var email = new TextEditCustom(icon: "", placeholder: "Email da conta", keyboard: Keyboard.Email)
            {
                Margin = new Thickness(10, 0, 10, 0)
            };
            email.SetBinding(TextEditCustom.TextProperty, nameof(ViewModel.Email));

            email.TextChanged += Email_TextChanged;

            mainGrid.Add(email, 0, 0);
        }

        private void CreateResetButton(Grid mainGrid)
        {
            var buttonReset = new Button
            {
                Text = "Redefinir Senha",
                Style = (Style)App.Current.Resources["buttonLoginDarkPrimary"]
            };

            buttonReset.Clicked += ButtonReset_Clicked; ;

            mainGrid.Add(buttonReset, 0, 1);
        }

        private void CreateBackButton(Grid mainGrid)
        {
            var buttonBack = new Button
            {
                Text = "Voltar",
                Style = (Style)App.Current.Resources["buttonLoginSecondaryDarkPrimary"],                
            };

            buttonBack.Clicked += ButtonBack_Clicked;

            mainGrid.Add(buttonBack, 0, 2);
        }

        #endregion

        #region Events

        private async void ButtonBack_Clicked(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }

        private void Email_TextChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private async void ButtonReset_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ViewModel.Email)) return;

            if (!ViewModel.Email.Contains("@"))
            {
                await DisplayAlert("Ops", "Parece que este não é um email válido. Favor verificar.", "Ok");
                return;
            }

            await ViewModel.ResetPassword();
        }

        #endregion
    }
}

