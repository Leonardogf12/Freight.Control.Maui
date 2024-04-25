using freight.control.maui.Controls.Animations;
using freight.control.maui.MVVM.Base.Views;
using freight.control.maui.Services;
using Microsoft.Maui.Controls.Shapes;

namespace freight.control.maui.MVVM.Views;

public class HomeView : BaseContentPage
{
    private readonly INavigationService _navigationService;

    ClickAnimation ClickAnimation = new();

    public HomeView()
	{       
        BackgroundColor = App.GetResource<Color>("PrimaryDark");
      
		Content = BuildHomeView();       
    }

    #region UI

    private View BuildHomeView()
    {
        var verticalStack = new VerticalStackLayout
        {
            VerticalOptions = LayoutOptions.Center
        };

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
        verticalStack.Children.Add(stack);

        return verticalStack;
    }

    #endregion

    #region Events

    private async void TapGestureRecognizer_Tapped_GoToFreightView(object sender, TappedEventArgs e)
    {
        View element = sender as Border;

        await ClickAnimation.SetFadeOnElement(element);        

        await Shell.Current.GoToAsync("FreightView");        
    }

    #endregion
    
}
