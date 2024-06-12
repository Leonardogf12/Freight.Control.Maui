using CommunityToolkit.Maui.Views;
using SkiaSharp.Extended.UI.Controls;

namespace freight.control.maui.Components.Popups
{
    public class PopupLoadingView : Popup
    {
        public bool IsOpen = false;

        public PopupLoadingView()
        {
            Color = Colors.Transparent;
            CanBeDismissedByTappingOutsideOfPopup = false;

            Content = new VerticalStackLayout
            {
                BackgroundColor = Colors.Transparent,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Children = {
                CreateLoadingComponent()
            }
            };
        }

        private SKLottieView CreateLoadingComponent()
        {
            var load = new SKLottieView
            {
                Source = (SKLottieImageSource)SKLottieImageSource.FromFile("loading_truck.json"),
                HeightRequest = 120,
                WidthRequest = 120,
                BackgroundColor = Colors.Transparent,
                RepeatCount = -1,
            };

            return load;
        }
    }
}


