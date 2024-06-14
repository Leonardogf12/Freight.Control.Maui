using freight.control.maui.Components.UI;
using freight.control.maui.MVVM.Base.Views;
using freight.control.maui.MVVM.ViewModels;

namespace freight.control.maui.MVVM.Views
{
    public class EditUserView : BaseContentPage
    {
        public EditUserViewModel ViewModel = new();

        public EditUserView()
        {
            BackgroundColor = Colors.White;

            Content = BuildEditUserView();

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

        private View BuildEditUserView()
        {
            var mainGrid = CreateMainGrid();

            CreateImageLogin(mainGrid);

            CreateInputAndButtons(mainGrid);

            return mainGrid;
        }

        private void CreateImageLogin(Grid mainGrid)
        {
            var iconUser = new Image
            {
                Source = ImageSource.FromFile("login_256"),
                HeightRequest = 100
            };

            mainGrid.Add(iconUser, 0, 0);
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

            CreateNameField(grid);
            CreateSaveButton(grid);
            CreateBackButton(grid);

            mainGrid.Add(grid, 0, 1);
        }

        private void CreateNameField(Grid mainGrid)
        {
            var name = new TextEditCustom(icon: "", placeholder: "Nome", keyboard: Keyboard.Email)
            {
                Margin = new Thickness(10, 0, 10, 0)
            };
            name.SetBinding(TextEditCustom.TextProperty, nameof(ViewModel.Name));

            name.TextChanged += Name_TextChanged;

            mainGrid.Add(name, 0, 0);
        }

        private void CreateSaveButton(Grid mainGrid)
        {
            var buttonSave = new Button
            {
                Text = "Salvar",
                Style = (Style)Application.Current.Resources["buttonLoginDarkPrimary"]
            };

            buttonSave.Clicked += ButtonReset_Clicked; ;

            mainGrid.Add(buttonSave, 0, 1);
        }

        private void CreateBackButton(Grid mainGrid)
        {
            var buttonBack = new Button
            {
                Text = "Voltar",
                Style = (Style)Application.Current.Resources["buttonLoginSecondaryDarkPrimary"],
            };

            buttonBack.Clicked += ButtonBack_Clicked;

            mainGrid.Add(buttonBack, 0, 2);
        }

        #endregion

        #region Events

        private async void ButtonBack_Clicked(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        private void Name_TextChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private async void ButtonReset_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ViewModel.Name))
            {
                await DisplayAlert("Ops", "Preencha corretamente o campo Nome. Favor verificar.", "Ok");
                return;
            }

            await ViewModel.SetNameForUser();
        }

        #endregion
    }
}