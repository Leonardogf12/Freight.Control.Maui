using Microsoft.Maui.Controls.Shapes;

namespace freight.control.maui.Components.UI
{
    public class EditorTextFieldCustom : ContentView
    {
        public Editor Editor { get; set; }
        public Border Border { get; set; }

        public EditorTextFieldCustom(string nameIcon, string placeholder)
        {
            Border = new Border
            {
                Stroke = Colors.LightGray,
                Background = Colors.Transparent,
                StrokeThickness = 1,
                Margin = DeviceInfo.Platform == DevicePlatform.Android ? new Thickness(10, 15, 10, 0) : 20,
                StrokeShape = new RoundRectangle
                {
                    CornerRadius = new CornerRadius(8)
                }
            };

            var contentGridBorder = new Grid
            {
                ColumnDefinitions = new ColumnDefinitionCollection
            {
                new () {Width = GridLength.Auto},
                new () {Width = GridLength.Star},
            },
                ColumnSpacing = 10
            };

            var icon = new Image
            {
                Source = nameIcon,
                Margin = new Thickness(10, 10, 0, 0),
                HeightRequest = 30,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Start
            };
            contentGridBorder.Add(icon, 0);

            Editor = new Editor
            {
                HeightRequest = 200,
                Margin = new Thickness(0, 0, 5, 0),
                FontSize = 16,
                PlaceholderColor = (Color)Application.Current.Resources["PrimaryDark"],
                Placeholder = placeholder,
                TextColor = (Color)Application.Current.Resources["PrimaryDark"],
                VerticalOptions = LayoutOptions.Start,
            };
            contentGridBorder.Add(Editor, 1);

            Border.Content = contentGridBorder;

            Content = Border;
        }
    }
}


