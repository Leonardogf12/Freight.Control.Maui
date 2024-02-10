using Microsoft.Maui.Controls.Shapes;

namespace freight.control.maui.Components;

public class DatePickerFieldCustom : ContentView
{
    public DatePicker DatePicker { get; set; }

    public Border Border { get; set; }

    public  DatePickerFieldCustom(string nameIcon = "calendar")
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
            Margin = new Thickness(10,0,0,0),
            HeightRequest = 30,
            VerticalOptions = LayoutOptions.Center,
        };
        contentGridBorder.Add(icon, 0);

        DatePicker = new DatePicker { 
            Margin = new Thickness(0,0,5,0),
            FontSize = 16,
            MaximumDate = new DateTime(2035,12,31),
            MinimumDate = new DateTime(2020, 01, 01),
            TextColor = (Color)App.Current.Resources["PrimaryDark"],
            VerticalOptions =LayoutOptions.Center,
        };
        contentGridBorder.Add(DatePicker, 1);

        Border.Content = contentGridBorder;

        Content = Border;	
	}
}
