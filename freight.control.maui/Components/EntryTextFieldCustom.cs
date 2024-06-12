using Microsoft.Maui.Controls.Shapes;

namespace freight.control.maui.Components
{
    public class EntryTextFieldCustom : ContentView
    {
        public Entry Entry { get; set; }
        public Border Border { get; set; }

        public EntryTextFieldCustom(string nameIcon, string placeholder)
        {
            Border = new Border
            {
                Stroke = Colors.LightGray,
                Background = Colors.Transparent,
                StrokeThickness = 1,
                Margin = Device.RuntimePlatform == Device.Android ? new Thickness(10, 15, 10, 0) : 20,
                HeightRequest = 50,
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
                Margin = new Thickness(10, 0, 0, 0),
                HeightRequest = 30,
                VerticalOptions = LayoutOptions.Center,
            };
            contentGridBorder.Add(icon, 0);

            Entry = new Entry
            {
                Margin = new Thickness(0, 0, 5, 0),
                FontSize = 16,
                PlaceholderColor = (Color)App.Current.Resources["PrimaryDark"],
                Placeholder = placeholder,
                TextColor = (Color)App.Current.Resources["PrimaryDark"],
                VerticalOptions = LayoutOptions.Center,
            };
            contentGridBorder.Add(Entry, 1);

            Border.Content = contentGridBorder;

            Content = Border;
        }
    }
}

