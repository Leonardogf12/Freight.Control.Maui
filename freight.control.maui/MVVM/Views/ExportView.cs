using freight.control.maui.Components;
using freight.control.maui.Controls.Animations;
using freight.control.maui.MVVM.Base.Views;
using freight.control.maui.MVVM.ViewModels;
using Microsoft.Maui.Controls.Shapes;

namespace freight.control.maui.MVVM.Views;

public class ExportView : BaseContentPage
{
    public ExportViewModel ViewModel = new();

    public ClickAnimation ClickAnimation = new();

    public ExportView()
	{
        BackgroundColor = Colors.White;

        Content = BuildExportView();

        BindingContext = ViewModel;
    }

    private View BuildExportView()
    {
        var mainGrid = CreateMainGrid();

        CreateStackTitle(mainGrid);

        CreateForm(mainGrid);

        CreateButtonSave(mainGrid);

        return mainGrid;
    }

    private Grid CreateMainGrid()
    {
        return new Grid
        {
            RowDefinitions = new RowDefinitionCollection
            {
                new () {Height = 100},
                new () {Height = GridLength.Auto},
                new () {Height = 50},
            }
        };
    }

    private void CreateStackTitle(Grid mainGrid)
    {
        var stackTitle = new StackLayout
        {
            BackgroundColor = Colors.White
        };

        var contentGridStackTitle = new Grid
        {
            RowDefinitions = new RowDefinitionCollection
            {
                new () {Height = 50},
            },
            ColumnDefinitions = new ColumnDefinitionCollection
            {
                new () { Width = GridLength.Star},
                new () { Width = GridLength.Star},
                new () { Width = GridLength.Star},
            },
            ColumnSpacing = 15,
            Margin = 10
        };

        var imageBackButton = new Image
        {
            Source = ImageSource.FromFile("back_primary_dark"),
            Margin = new Thickness(20, 0, 0, 0),
            HeightRequest = 20,
            HorizontalOptions = LayoutOptions.Start
        };

        var tapGestureRecognizer = new TapGestureRecognizer();
        tapGestureRecognizer.Tapped += TapGestureRecognizer_Tapped_GoBack;

        imageBackButton.GestureRecognizers.Add(tapGestureRecognizer);

        contentGridStackTitle.Add(imageBackButton, 0, 0);

        var labelTitle = new Label
        {
            Text = "Exportar",
            TextColor = (Color)App.Current.Resources["PrimaryDark"],
            Style = (Style)App.Current.Resources["labelTitleView"],
        };
        contentGridStackTitle.Add(labelTitle, 1, 0);

        stackTitle.Children.Add(contentGridStackTitle);

        mainGrid.Children.Add(stackTitle);
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
            FontFamily= "MontserratRegular",
            HorizontalOptions = LayoutOptions.Start,
            Margin = new Thickness(10,10,0,0),
            FontSize = 16
        };
        stackInitialDate.Children.Add(titleInitialDate);
        var initialDate = new DatePickerFieldCustom();
        initialDate.Border.Margin = new Thickness(10, 0, 10, 0);
        initialDate.DatePicker.SetBinding(DatePicker.DateProperty, nameof(ViewModel.InitialDate));
        stackInitialDate.Children.Add(initialDate);
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
        var finalDate = new DatePickerFieldCustom();
        finalDate.Border.Margin = new Thickness(10, 0, 10, 0);
        finalDate.DatePicker.SetBinding(DatePicker.DateProperty, nameof(ViewModel.FinalDate));      
        stackFinalDate.Children.Add(finalDate);
        contentGridBorderForm.SetColumnSpan(stackFinalDate, 2);
        contentGridBorderForm.Add(stackFinalDate, 0, 1);

        borderForm.Content = contentGridBorderForm;

        mainGrid.Add(borderForm, 0, 1);
    }

    private void CreateButtonSave(Grid mainGrid)
    {
        var button = new Button
        {
            Text = "Exportar",
            Style = (Style)App.Current.Resources["buttonDarkPrimary"]
        };

        button.Clicked += SaveClicked;

        mainGrid.Add(button, 0, 2);
    }
    
    private async void TapGestureRecognizer_Tapped_GoBack(object sender, TappedEventArgs e)
    {
        View element = sender as Image;

        await ClickAnimation.SetFadeOnElement(element);

        await App.Current.MainPage.Navigation.PopAsync();
    }

    private void SaveClicked(object sender, EventArgs e)
    {
        ViewModel.OnSave();
    }
}
