using System;
using DevExpress.Maui.Controls;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Graphics;

namespace freight.control.maui.Components;

public class BottomSheetFilterDateCustom : BottomSheet
{
    public DatePickerFieldCustom DatePickerFieldCustomInitialDate { get; set; }
    public DatePickerFieldCustom DatePickerFieldCustomFinalDate { get; set; }


    public BottomSheetFilterDateCustom(string title, string textButton, EventHandler eventHandler)
	{
        BackgroundColor = Colors.White;

        var mainGrid = CreateMainGridBoxFilter();

        CreateStackTitle(mainGrid, title);

        CreateForm(mainGrid);

        CreateButton(mainGrid, textButton, eventHandler);

        Content = mainGrid;
    }
   
    private Grid CreateMainGridBoxFilter()
    {
        return new Grid
        {
            RowDefinitions = new RowDefinitionCollection
            {
                new () {Height = 50},
                new () {Height = GridLength.Auto},
                new () {Height = 50},
            }
        };
    }

    private void CreateStackTitle(Grid mainGrid, string title)
    {
        var labelTitle = new Label
        {
            Text = title,
            TextColor = (Color)App.Current.Resources["PrimaryDark"],
            Style = (Style)App.Current.Resources["labelTitleView"],
            HorizontalOptions = LayoutOptions.Center
        };
        mainGrid.Add(labelTitle, 0, 0);
    }

    private void CreateForm(Grid mainGrid)
    {
        var borderForm = new Border
        {
            Stroke = Colors.LightGray,
            Background = Colors.Transparent,
            StrokeThickness = 1,
            Margin = Device.RuntimePlatform == Device.Android ? 10 : 20,
            StrokeShape = new RoundRectangle
            {
                CornerRadius = new CornerRadius(10)
            }
        };

        var contentGridBorderForm = new Grid
        {
            RowDefinitions = new RowDefinitionCollection
            {
                new () {Height = GridLength.Auto},
                new () {Height = GridLength.Auto},
            },
        };

        var stackInitialDate = new StackLayout
        {
            Orientation = StackOrientation.Vertical,
        };

        var titleInitialDate = new Label
        {
            Text = "Data de:",
            TextColor = (Color)App.Current.Resources["PrimaryDark"],
            Style = (Style)App.Current.Resources["labelTitleView"],
            FontFamily = "MontserratRegular",
            HorizontalOptions = LayoutOptions.Start,
            Margin = new Thickness(10, 10, 0, 0),
            FontSize = 16
        };
        stackInitialDate.Children.Add(titleInitialDate);

        DatePickerFieldCustomInitialDate = new DatePickerFieldCustom();
        DatePickerFieldCustomInitialDate.Border.Margin = new Thickness(10, 0, 10, 0);        
        stackInitialDate.Children.Add(DatePickerFieldCustomInitialDate);
        contentGridBorderForm.SetColumnSpan(stackInitialDate, 2);
        contentGridBorderForm.Add(stackInitialDate, 0, 0);

        var stackFinalDate = new StackLayout
        {
            Orientation = StackOrientation.Vertical,
            Margin = new Thickness(0, 0, 0, 10)
        };

        var titleFinalDate = new Label
        {
            Text = "Data até:",
            TextColor = (Color)App.Current.Resources["PrimaryDark"],
            Style = (Style)App.Current.Resources["labelTitleView"],
            FontFamily = "MontserratRegular",
            HorizontalOptions = LayoutOptions.Start,
            Margin = new Thickness(10, 10, 0, 0),
            FontSize = 16
        };
        stackFinalDate.Children.Add(titleFinalDate);

        DatePickerFieldCustomFinalDate = new DatePickerFieldCustom();
        DatePickerFieldCustomFinalDate.Border.Margin = new Thickness(10, 0, 10, 0);       
        stackFinalDate.Children.Add(DatePickerFieldCustomFinalDate);
        contentGridBorderForm.SetColumnSpan(stackFinalDate, 2);
        contentGridBorderForm.Add(stackFinalDate, 0, 1);

        borderForm.Content = contentGridBorderForm;

        mainGrid.Add(borderForm, 0, 1);
    }

    private void CreateButton(Grid mainGrid, string text, EventHandler eventHandler)
    {
        var button = new Button
        {
            Text = text,
            Style = (Style)App.Current.Resources["buttonDarkPrimary"]
        };

        button.Clicked += eventHandler;

        mainGrid.Add(button, 0, 2);
    }
}
