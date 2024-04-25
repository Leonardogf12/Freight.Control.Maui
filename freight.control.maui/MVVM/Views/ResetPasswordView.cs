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

            BindingContext = ViewModel;
        }

        private View BuildResetPasswordView()
        {
            var mainGrid = CreateMainGrid();

            CreateEmailField(mainGrid);      
            CreateResetButton(mainGrid);
            CreateBackButton(mainGrid);

            return mainGrid;
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
                },
                RowSpacing = 10,
                VerticalOptions = LayoutOptions.Center
            };
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
                Style = (Style)App.Current.Resources["buttonDarkPrimary"]
            };

            buttonReset.Clicked += ButtonReset_Clicked; ;

            mainGrid.Add(buttonReset, 0, 1);
        }

        private void CreateBackButton(Grid mainGrid)
        {
            var buttonBack = new Button
            {
                Text = "Voltar",
                Style = (Style)App.Current.Resources["buttonDarkPrimary"],
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

            await ViewModel.ResetPassword();
        }

        #endregion
    }
}

