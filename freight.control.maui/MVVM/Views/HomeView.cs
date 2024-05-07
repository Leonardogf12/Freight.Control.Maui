using DevExpress.Maui.Controls;
using freight.control.maui.Constants;
using freight.control.maui.Controls;
using freight.control.maui.Controls.Animations;
using freight.control.maui.MVVM.Base.Views;
using Microsoft.Maui.Controls.Shapes;

namespace freight.control.maui.MVVM.Views;

public class HomeView : BaseContentPage
{
    #region Properties

    ClickAnimation ClickAnimation = new();

    public DXPopup SettingsDxPopup = new();

    public Image SettingsButton = new();

    #endregion

    public HomeView()
    {
        BackgroundColor = App.GetResource<Color>("PrimaryDark");
        
        Content = BuildHomeView();
    }

    #region UI

    private View BuildHomeView()
    {
        var mainGrid = CreateMainGrid();
       
        CreateSettingsButton(mainGrid);

        CreateDxPopupSettings(mainGrid);
       
        CreateFreightButton(mainGrid);

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

    private void CreateFreightButton(Grid mainGrid)
    {
        var stack = new StackLayout
        {
            VerticalOptions = LayoutOptions.Center
        };

        var border = new Border
        {
            HeightRequest = 150,
            WidthRequest = 150,
            BackgroundColor = App.GetResource<Color>("SecondaryGreen"),
            StrokeThickness = 0,
            StrokeShape = new RoundRectangle
            {
                CornerRadius = 20,
            }
        };

        var tapGestureRecognizer = new TapGestureRecognizer();
        tapGestureRecognizer.Tapped += TapGestureRecognizer_Tapped_GoToFreightView;
        border.GestureRecognizers.Add(tapGestureRecognizer);

        var imagemButton = new Image
        {
            Source = ImageSource.FromFile("truck"),
            HeightRequest = 80
        };

        border.Content = imagemButton;
        stack.Children.Add(border);

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
            BackgroundColor = App.GetResource<Color>("White")
        };

        mainGrid.Add(SettingsDxPopup, 0, 0);
    }

    private View CreateContentDxPopupSettings()
    {
        var content = new StackLayout
        {
            WidthRequest = 100,
            HeightRequest = 75,
            Spacing = 5,
            Orientation = StackOrientation.Horizontal,           
            Margin = new Thickness(10,10,0,0),           
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

        return content;
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

    private async void TapGestureRecognizer_Tapped_Logoff(object sender, TappedEventArgs e)
    {
        if (sender is StackLayout element)
        {
            await ClickAnimation.SetFadeOnElement(element);

            var result = await App.Current.MainPage.DisplayAlert("Sair", "Deseja realmente deslogar sua conta?", "Sim", "Cancelar");

            SettingsDxPopup.IsOpen = false;

            if (!result) return;

            ControlPreferences.RemoveKeyFromPreferences(StringConstants.firebaseAuthTokenKey);

            await Shell.Current.GoToAsync("//login");
        }
    }

    #endregion

}
