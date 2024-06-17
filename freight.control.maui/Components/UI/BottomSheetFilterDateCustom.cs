using DevExpress.Maui.Controls;
using freight.control.maui.Controls.Resources;
using Microsoft.Maui.Controls.Shapes;

namespace freight.control.maui.Components.UI
{
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

        private static Grid CreateMainGridBoxFilter()
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

        private static void CreateStackTitle(Grid mainGrid, string title)
        {
            var labelTitle = new Label
            {
                Text = title,
                TextColor = ControlResources.GetResource<Color>("PrimaryDark"),
                Style = ControlResources.GetResource<Style>("labelTitleView"),               
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
                Margin = DeviceInfo.Platform == DevicePlatform.Android ? 10 : 20,
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
                TextColor = ControlResources.GetResource<Color>("PrimaryDark"),
                Style = ControlResources.GetResource<Style>("labelTitleView"),              
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
                TextColor = ControlResources.GetResource<Color>("PrimaryDark"),         
                Style = ControlResources.GetResource<Style>("labelTitleView"),              
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

        private static void CreateButton(Grid mainGrid, string text, EventHandler eventHandler)
        {
            var button = new Button
            {
                Text = text,
                Style = ControlResources.GetResource<Style>("buttonDarkPrimary"),               
            };

            button.Clicked += eventHandler;

            mainGrid.Add(button, 0, 2);
        }
    }
}


