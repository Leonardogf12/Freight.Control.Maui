using freight.control.maui.Components;
using freight.control.maui.Controls.Animations;
using freight.control.maui.MVVM.Base.Views;
using freight.control.maui.MVVM.ViewModels;
using Microsoft.Maui.Controls.Shapes;

namespace freight.control.maui.MVVM.Views;

public class ToFuelView : BaseContentPage
{

    public ToFuelViewModel ViewModel = new();

    public ClickAnimation ClickAnimation = new();

    public ToFuelView()
	{
        BackgroundColor = Colors.White;

        Content = BuildToFuelView();

        BindingContext = ViewModel;
    }

    #region UI

    private View BuildToFuelView()
    {
        var mainGrid = CreateMainGrid();

        CreateStackTitle(mainGrid);

        CreateStackInfoFreight(mainGrid);

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
                new () {Height = 80},
                new () {Height = 60},
                new () {Height = GridLength.Star},
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
                new () { Width = GridLength.Auto},
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
            HorizontalOptions = LayoutOptions.Start,           
        };

        var tapGestureRecognizer = new TapGestureRecognizer();
        tapGestureRecognizer.Tapped += TapGestureRecognizer_Tapped_GoBack;

        imageBackButton.GestureRecognizers.Add(tapGestureRecognizer);

        contentGridStackTitle.Add(imageBackButton, 0, 0);

        var labelTitle = new Label
        {
            Text = "Abastecimento",
            TextColor = (Color)App.Current.Resources["PrimaryDark"],
            Style = (Style)App.Current.Resources["labelTitleView"],                   
        };
        contentGridStackTitle.Add(labelTitle, 1, 0);

        stackTitle.Children.Add(contentGridStackTitle);

        mainGrid.Children.Add(stackTitle);
    }

    private void CreateStackInfoFreight(Grid mainGrid)
    {
        var stack = new StackLayout
        {
            Orientation = StackOrientation.Vertical,
            Spacing = 5,
            Margin = new Thickness(10,0,0,0)
        };

        var stackDate = new StackLayout
        {
            Orientation = StackOrientation.Horizontal,
            Spacing = 5
        };
        var titleDate = new Label
        {
            Text= "Data:",
            FontFamily = "MontserratSemiBold",
            FontSize = 14,
            TextColor = App.GetResource<Color>("PrimaryDark")
        };
        stackDate.Children.Add(titleDate);
        var contentDate = new Label
        {           
            FontFamily = "MontserratRegular",
            FontSize = 14,
            TextColor = App.GetResource<Color>("PrimaryDark")
        };
        contentDate.SetBinding(Label.TextProperty, nameof(ViewModel.FreightTravelDate));
        stackDate.Children.Add(contentDate);

        stack.Children.Add(stackDate);

        var stackOrigin = new StackLayout
        {
            Orientation = StackOrientation.Horizontal,
            Spacing = 5
        };
        var titleOrigin = new Label
        {
            Text = "Origem:",
            FontFamily = "MontserratSemiBold",
            FontSize = 14,
            TextColor = App.GetResource<Color>("PrimaryDark")
        };
        stackOrigin.Children.Add(titleOrigin);
        var contentOrigin = new Label
        {
            FontFamily = "MontserratRegular",
            FontSize = 14,
            TextColor = App.GetResource<Color>("PrimaryDark")
        };
        contentOrigin.SetBinding(Label.TextProperty, nameof(ViewModel.FreightModel.Origin));
        stackOrigin.Children.Add(contentOrigin);

        stack.Children.Add(stackOrigin);

        var stackDestination = new StackLayout
        {
            Orientation = StackOrientation.Horizontal,
            Spacing = 5
        };
        var titleDestination = new Label
        {
            Text = "Origem:",
            FontFamily = "MontserratSemiBold",
            FontSize = 14,
            TextColor = App.GetResource<Color>("PrimaryDark")
        };
        stackDestination.Children.Add(titleDestination);
        var contentDestination= new Label
        {
            FontFamily = "MontserratRegular",
            FontSize = 14,
            TextColor = App.GetResource<Color>("PrimaryDark")
        };
        stackDestination.SetBinding(Label.TextProperty, nameof(ViewModel.FreightModel.Destination));
        stackOrigin.Children.Add(contentDestination);

        stack.Children.Add(stackDestination);

        mainGrid.Add(stack, 0, 1);
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
                new () {Height = GridLength.Auto},
                new () {Height = GridLength.Auto},
                new () {Height = GridLength.Auto},
            },
            ColumnDefinitions = new ColumnDefinitionCollection
            {
                new () { Width = GridLength.Star},
                new () { Width = GridLength.Star},
            }
        };

        var date = new DatePickerFieldCustom();
        date.DatePicker.SetBinding(DatePicker.DateProperty, nameof(ViewModel.ToFuelModel.Date));
        contentGridBorderForm.SetColumnSpan(date, 2);
        contentGridBorderForm.Add(date, 0, 0);

        var borderFuel = new Border
        {
            Stroke = Colors.LightGray,
            Background = Colors.Transparent,
            StrokeThickness = 1,
            Margin = Device.RuntimePlatform == Device.Android ? 10 : 20,
            StrokeShape = new RoundRectangle
            {
                CornerRadius = new CornerRadius(10)
            },
        };

        var gridFuel = new Grid
        {
            RowDefinitions = new RowDefinitionCollection
            {
                new() {Height = GridLength.Star},
                new() {Height = GridLength.Star},
            },
            ColumnDefinitions = new ColumnDefinitionCollection
            {
                new () {Width = GridLength.Star},
                new () {Width = GridLength.Star},
            },            
            RowSpacing = 10,
        };
        
        var liters = new EntryTextFieldCustom("liters", "Litros");
        liters.Entry.SetBinding(Entry.TextProperty, nameof(ViewModel.ToFuelModel.Liters));
        gridFuel.Add(liters, 0, 0);
        
        var amountSpentFuel = new EntryTextFieldCustom("money", "Valor");
        amountSpentFuel.Entry.SetBinding(Entry.TextProperty, nameof(ViewModel.ToFuelModel.AmountSpentFuel));
        gridFuel.Add(amountSpentFuel, 1, 0);

        var titleValuePerLiter = new Label
        {
            Text = "Valor do Litro:",
            FontFamily = "MontserratRegular",
            FontSize = 16,
            TextColor = App.GetResource<Color>("PrimaryDark"),
            Margin = new Thickness(10,0,0,10),            
        };
        gridFuel.Add(titleValuePerLiter, 0, 1);

        var contentValuePerLiter = new Label
        {            
            FontFamily = "MontserratRegular",
            FontSize = 16,
            TextColor = Colors.LightGray,
            HorizontalOptions = LayoutOptions.End,
            Margin = new Thickness(0, 0, 10, 0),
        };       
        contentValuePerLiter.SetBinding(Entry.TextProperty, nameof(ViewModel.ToFuelModel.ValuePerLiter));
        gridFuel.Add(contentValuePerLiter, 1, 1);

        borderFuel.Content = gridFuel;

        contentGridBorderForm.SetColumnSpan(borderFuel,2);
        contentGridBorderForm.Add(borderFuel, 0, 2);


        var expenses = new EntryTextFieldCustom("money", "Despesas");
        expenses.Entry.SetBinding(Entry.TextProperty, nameof(ViewModel.ToFuelModel.Expenses));
        contentGridBorderForm.SetColumnSpan(expenses, 2);
        contentGridBorderForm.Add(expenses, 0, 3);

        var observation = new EditorTextFieldCustom("comment", "Observação");
        observation.Editor.SetBinding(Editor.TextProperty, nameof(ViewModel.ToFuelModel.Observation));
        contentGridBorderForm.SetColumnSpan(observation, 2);
        contentGridBorderForm.Add(observation, 0, 5);

        borderForm.Content = contentGridBorderForm;

        mainGrid.Add(borderForm, 0, 2);
    }

    private void CreateButtonSave(Grid mainGrid)
    {
        var button = new Button
        {
            Text = "Salvar",
            Style = (Style)App.Current.Resources["buttonDarkPrimary"]
        };

        button.Clicked += SaveClicked;

        mainGrid.Add(button, 0, 3);
    }

    #endregion

    #region Events

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

    #endregion

    #region Actions
    #endregion

}
