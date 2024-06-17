using freight.control.maui.Controls.Resources;
using Microsoft.Maui.Controls.Shapes;

namespace freight.control.maui.Components.UI
{
    public class ButtonHomeMenu : StackLayout
    {
        public ButtonHomeMenu(string iconName, EventHandler<TappedEventArgs> eventTap)
        {
            var stack = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center
            };

            var border = new Border
            {
                HeightRequest = 150,
                WidthRequest = 150,
                BackgroundColor = ControlResources.GetResource<Color>("SecondaryGreen"),
                StrokeThickness = 0,
                StrokeShape = new RoundRectangle
                {
                    CornerRadius = 20,
                }
            };

            var tapGestureRecognizer = new TapGestureRecognizer
            {
                NumberOfTapsRequired = 1,                
            };
            tapGestureRecognizer.Tapped += eventTap;
            border.GestureRecognizers.Add(tapGestureRecognizer);

            var imagemButton = new Image
            {
                Source = ImageSource.FromFile(iconName),
                HeightRequest = 80
            };

            border.Content = imagemButton;
            stack.Children.Add(border);

            Children.Add(stack);
        }
    }
}


