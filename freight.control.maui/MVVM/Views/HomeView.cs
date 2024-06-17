using DevExpress.Maui.Controls;
using freight.control.maui.Components.UI;
using freight.control.maui.Constants;
using freight.control.maui.Controls;
using freight.control.maui.Controls.Animations;
using freight.control.maui.Controls.Resources;
using freight.control.maui.MVVM.Base.Views;
using freight.control.maui.MVVM.ViewModels;
using freight.control.maui.Services.Navigation;

namespace freight.control.maui.MVVM.Views
{
    public class HomeView : BaseContentPage
    {
        #region Properties

        private readonly INavigationService _navigationService;

        public HomeViewModel ViewModel = new();

        readonly ClickAnimation ClickAnimation = new();

        public DXPopup SettingsDxPopup = new();

        public Image SettingsButton = new();

        #endregion

        public HomeView(INavigationService navigationService)
        {
            _navigationService = navigationService;

            BackgroundColor = ControlResources.GetResource<Color>("PrimaryDark");

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

        private static Grid CreateMainGrid()
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
                Spacing = 60
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
                MaximumWidthRequest = 200, 
                BackgroundColor = ControlResources.GetResource<Color>("White"),               
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
            var content = new Grid
            {                
                ColumnDefinitions = new ColumnDefinitionCollection
                {
                    new () { Width = GridLength.Auto },
                    new () { Width = GridLength.Star },
                },
                ColumnSpacing = 5,
                Margin = 10
            };

            var icon = new Image
            {
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Start,
                Source = ImageSource.FromFile("user_24"),
                HeightRequest = 20
            };

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += TapGestureRecognizer_Tapped_UserLogged;
            content.GestureRecognizers.Add(tapGestureRecognizer);

            var text = new Label
            {
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Start,
                TextColor = ControlResources.GetResource<Color>("PrimaryDark"),
                FontFamily = "MontserratSemibold",
                FontSize = 16,
                MaxLines = 1,
                LineBreakMode = LineBreakMode.TailTruncation
            };
            text.SetBinding(Label.TextProperty, nameof(ViewModel.NameUserLogged));
            
            content.Add(icon, 0, 0);
            content.Add(text, 1, 0);

            items.Children.Add(content);
        }

        private void CreateLogoffButton(StackLayout items)
        {
            var content = new Grid
            {
                ColumnDefinitions = new ColumnDefinitionCollection
                {
                    new () { Width = GridLength.Auto },
                    new () { Width = GridLength.Star },
                },
                ColumnSpacing = 5,
                Margin = 10
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
                TextColor = ControlResources.GetResource<Color>("PrimaryDark"),
                FontFamily = "MontserratSemibold",
                FontSize = 16,
                Text = "Sair",
            };

            content.Add(icon, 0, 0);
            content.Add(text, 1, 0);

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
               
                await _navigationService.NavigationToPageAsync<FreightView>();
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
                    await DisplayAlert("Ops", "Nenhum registro encontrado.", "Ok");
                    return;
                }

                await _navigationService.NavigationToPageAsync<ChartsView>();              
            }
        }

        private async void TapGestureRecognizer_Tapped_Logoff(object sender, TappedEventArgs e)
        {
            if (sender is Grid element)
            {
                await ClickAnimation.SetFadeOnElement(element);

                var result = await DisplayAlert("Sair", "Deseja realmente deslogar sua conta?", "Sim", "Cancelar");

                SettingsDxPopup.IsOpen = false;

                if (!result) return;

                ControlPreferences.RemoveKeyFromPreferences(StringConstants.firebaseAuthTokenKey);
                ControlPreferences.RemoveKeyFromPreferences(StringConstants.firebaseUserLocalIdKey);

                await _navigationService.NavigationToPageAsync<LoginView>();               
            }
        }

        private async void TapGestureRecognizer_Tapped_UserLogged(object sender, TappedEventArgs e)
        {
            if (sender is Grid element)
            {
                await ClickAnimation.SetFadeOnElement(element);

                SettingsDxPopup.IsOpen = false;

                await _navigationService.NavigationToPageAsync<EditUserView>();               
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
