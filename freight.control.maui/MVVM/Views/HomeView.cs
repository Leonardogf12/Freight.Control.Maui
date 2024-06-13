using DevExpress.Maui.Controls;
using freight.control.maui.Components.UI;
using freight.control.maui.Constants;
using freight.control.maui.Controls;
using freight.control.maui.Controls.Animations;
using freight.control.maui.MVVM.Base.Views;
using freight.control.maui.MVVM.ViewModels;

namespace freight.control.maui.MVVM.Views
{
    public class HomeView : BaseContentPage
    {
        #region Properties

        public HomeViewModel ViewModel = new();

        ClickAnimation ClickAnimation = new();

        public DXPopup SettingsDxPopup = new();

        public Image SettingsButton = new();

        #endregion

        public HomeView()
        {
            BackgroundColor = App.GetResource<Color>("PrimaryDark");

            Content = BuildHomeView();

            BindingContext = ViewModel;
        }

        #region UI

        private View BuildHomeView()
        {
            var mainGrid = CreateMainGrid();

            CreateSettingsButton(mainGrid);

            CreateDxPopupSettings(mainGrid);

            CreateButtonsHomeMenu(mainGrid);

            return mainGrid;
        }

        private Grid CreateMainGrid()
        {
            return new Grid
            {
                RowDefinitions = new RowDefinitionCollection
            {
                new () {Height = 50},
                new () {Height = GridLength.Star},
            },
                RowSpacing = 5,
                Margin = 20
            };
        }

        private void CreateButtonsHomeMenu(Grid mainGrid)
        {
            var stack = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Orientation = StackOrientation.Vertical,
                Spacing = 30
            };

            var freightButton = new ButtonHomeMenu(iconName: "truck", eventTap: TapGestureRecognizer_Tapped_GoToFreightView);
            stack.Children.Add(freightButton);

            var chartsButton = new ButtonHomeMenu(iconName: "charts_256", eventTap: TapGestureRecognizer_Tapped_GoToChartsView);
            stack.Children.Add(chartsButton);

            mainGrid.Add(stack, 0, 1);
        }

        private void CreateSettingsButton(Grid mainGrid)
        {
            var icon = new Image
            {
                Source = ImageSource.FromFile("settings_white_24"),
                HorizontalOptions = LayoutOptions.End,
            };

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += TapGestureRecognizer_Tapped_OpenPopup;
            icon.GestureRecognizers.Add(tapGestureRecognizer);

            mainGrid.Add(icon, 0, 0);
        }

        private void CreateDxPopupSettings(Grid mainGrid)
        {
            SettingsDxPopup = new DXPopup
            {
                Content = CreateContentDxPopupSettings(),
                Placement = DevExpress.Maui.Core.Placement.Bottom,
                HorizontalAlignment = PopupHorizontalAlignment.Left,
                CornerRadius = 8,
                BackgroundColor = App.GetResource<Color>("White"),               
            };

            mainGrid.Add(SettingsDxPopup, 0, 0);
        }

        private View CreateContentDxPopupSettings()
        {
            var items = new StackLayout
            {
                WidthRequest = 130,
                HeightRequest = 100,
                Orientation = StackOrientation.Vertical,
                Spacing = 5
            };

            CreateUserButton(items);

            CreateLogoffButton(items);

            return items;
        }

        private void CreateUserButton(StackLayout items)
        {
            var content = new StackLayout
            {
                Spacing = 10,
                Orientation = StackOrientation.Horizontal,
                Margin = new Thickness(10, 10, 0, 0),
            };

            var icon = new Image
            {
                VerticalOptions = LayoutOptions.Start,
                Source = ImageSource.FromFile("user_24"),
                HeightRequest = 20
            };

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += TapGestureRecognizer_Tapped_UserLogged;
            content.GestureRecognizers.Add(tapGestureRecognizer);

            var text = new Label
            {
                VerticalOptions = LayoutOptions.Start,
                TextColor = App.GetResource<Color>("PrimaryDark"),
                FontFamily = "MontserratSemibold",
                FontSize = 16,
            };
            text.SetBinding(Label.TextProperty, nameof(ViewModel.NameUserLogged));

            content.Children.Add(icon);
            content.Children.Add(text);
            items.Children.Add(content);
        }

        private void CreateLogoffButton(StackLayout items)
        {
            var content = new StackLayout
            {
                Spacing = 10,
                Orientation = StackOrientation.Horizontal,
                Margin = new Thickness(10, 10, 0, 0),
            };

            var icon = new Image
            {
                VerticalOptions = LayoutOptions.Start,
                Source = ImageSource.FromFile("logoff_24"),
                HeightRequest = 20
            };

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += TapGestureRecognizer_Tapped_Logoff;
            content.GestureRecognizers.Add(tapGestureRecognizer);

            var text = new Label
            {
                VerticalOptions = LayoutOptions.Start,
                TextColor = App.GetResource<Color>("PrimaryDark"),
                FontFamily = "MontserratSemibold",
                FontSize = 16,
                Text = "Sair",
            };

            content.Children.Add(icon);
            content.Children.Add(text);
            items.Children.Add(content);
        }

        #endregion

        #region Events

        private async void TapGestureRecognizer_Tapped_OpenPopup(object sender, TappedEventArgs e)
        {
            if (sender is Image element)
            {
                SettingsDxPopup.PlacementTarget = (View)sender;

                await ClickAnimation.SetFadeOnElement(element);

                SettingsDxPopup.IsOpen = !SettingsDxPopup.IsOpen;
            }
        }

        private async void TapGestureRecognizer_Tapped_GoToFreightView(object sender, TappedEventArgs e)
        {
            if (sender is Border element)
            {
                await ClickAnimation.SetFadeOnElement(element);

                await Shell.Current.GoToAsync("FreightView");
            }
        }

        private async void TapGestureRecognizer_Tapped_GoToChartsView(object sender, TappedEventArgs e)
        {
            if (sender is Border element)
            {
                await ClickAnimation.SetFadeOnElement(element);

                var result = await ViewModel.CheckIfExistRecordsToNavigate();

                if (result == 0)
                {
                    await App.Current.MainPage.DisplayAlert("Ops", "Nenhum registro encontrado.", "Ok");
                    return;
                }

                await Shell.Current.GoToAsync("ChartsView");
            }
        }

        private async void TapGestureRecognizer_Tapped_Logoff(object sender, TappedEventArgs e)
        {
            if (sender is StackLayout element)
            {
                await ClickAnimation.SetFadeOnElement(element);

                var result = await App.Current.MainPage.DisplayAlert("Sair", "Deseja realmente deslogar sua conta?", "Sim", "Cancelar");

                SettingsDxPopup.IsOpen = false;

                if (!result) return;

                ControlPreferences.RemoveKeyFromPreferences(StringConstants.firebaseAuthTokenKey);
                ControlPreferences.RemoveKeyFromPreferences(StringConstants.firebaseUserLocalIdKey);

                await Shell.Current.GoToAsync("//login");
            }
        }

        private async void TapGestureRecognizer_Tapped_UserLogged(object sender, TappedEventArgs e)
        {
            if (sender is StackLayout element)
            {
                await ClickAnimation.SetFadeOnElement(element);

                SettingsDxPopup.IsOpen = false;

                await Shell.Current.GoToAsync("/EditUserView");
            }
        }

        #endregion

        #region Actions

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ViewModel.LoadInfoByUserLogged();
        }

        #endregion
    }
}
