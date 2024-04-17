using freight.control.maui.Components;
using freight.control.maui.MVVM.Base.Views;
using freight.control.maui.MVVM.ViewModels;

namespace freight.control.maui.MVVM.Views
{
    public class RegisterView : BaseContentPage
	{
		public RegisterViewModel ViewModel = new();

        public RegisterView()
		{
            BackgroundColor = Colors.White;

            Content = BuildRegisterView();

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

                },
                RowSpacing = 10,
                VerticalOptions = LayoutOptions.Center
            };
        }

        private View BuildRegisterView()
        {
            var mainGrid = CreateMainGrid();

            CreateEmailField(mainGrid);
            CreatePasswordField(mainGrid);
            CreateLoginButton(mainGrid);
            CreateBackButton(mainGrid);


            return mainGrid;
        }
       
        private void CreateEmailField(Grid mainGrid)
        {
            var email = new TextEditCustom(icon: "", placeholder: "Email", keyboard: Keyboard.Email)
            {
                Margin = 10
            };

            mainGrid.Add(email, 0, 0);
        }

        private void CreatePasswordField(Grid mainGrid)
        {
            var password = new TextEditCustom(icon: "", placeholder: "Senha", keyboard: Keyboard.Email)
            {
                Margin = 10
            };

            mainGrid.Add(password, 0, 1);
        }

        private void CreateLoginButton(Grid mainGrid)
        {
            var button = new Button
            {
                Text = "Registrar",
                Style = (Style)App.Current.Resources["buttonDarkPrimary"]
            };

            mainGrid.Add(button, 0, 2);
        }

        private void CreateBackButton(Grid mainGrid)
        {
            var buttonBack = new Button
            {
                Text = "Voltar",
                Style = (Style)App.Current.Resources["buttonDarkPrimary"],               

            };

            buttonBack.Clicked += ButtonBack_Clicked;

            mainGrid.Add(buttonBack, 0, 3);
        }

        private async void ButtonBack_Clicked(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }
    }
}

