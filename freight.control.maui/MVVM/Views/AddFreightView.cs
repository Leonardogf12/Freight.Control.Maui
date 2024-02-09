using freight.control.maui.Components;
using freight.control.maui.MVVM.ViewModels;
using Microsoft.Maui.Controls.Shapes;
using freight.control.maui.Controls.ControlCheckers;
using freight.control.maui.MVVM.Base.Views;
using freight.control.maui.Controls.Animations;

namespace freight.control.maui.MVVM.Views;

public class AddFreightView : BaseContentPage
{
    public AddFreightViewModel ViewModel = new();

    public ClickAnimation ClickAnimation = new();

    public AddFreightView()
	{
        BackgroundColor = Colors.White;

        Content = BuildAddFreightView();

        BindingContext = ViewModel;
    }

    #region UI

    private View BuildAddFreightView()
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
            Text = "Frete",
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

        var travel = new DatePickerFieldCustom();
        travel.DatePicker.SetBinding(DatePicker.DateProperty, nameof(AddFreightViewModel.TravelDate));
        contentGridBorderForm.SetColumnSpan(travel, 2);
        contentGridBorderForm.Add(travel, 0, 0);

        var origin = new EntryTextFieldCustom("local", "Origem");
        origin.Entry.SetBinding(Entry.TextProperty, nameof(AddFreightViewModel.Origin));
        contentGridBorderForm.SetColumnSpan(origin, 2);
        contentGridBorderForm.Add(origin, 0, 1);

        var destination = new EntryTextFieldCustom("local", "Destino");
        destination.Entry.SetBinding(Entry.TextProperty, nameof(AddFreightViewModel.Destination));
        contentGridBorderForm.SetColumnSpan(destination, 2);
        contentGridBorderForm.Add(destination, 0, 2);

        var km = new EntryTextFieldCustom("km", "Km");
        km.Entry.Keyboard = Keyboard.Numeric;
        km.Entry.SetBinding(Entry.TextProperty, nameof(AddFreightViewModel.Kilometer));
        km.Border.SetBinding(Border.StrokeProperty, nameof(AddFreightViewModel.StrokeKm));
        km.Entry.TextChanged += TextChangedEntryKm;
        contentGridBorderForm.Add(km, 0, 3);

        var freigthField = new EntryTextFieldCustom("money", "Valor");
        freigthField.Entry.Keyboard = Keyboard.Numeric;
        freigthField.Entry.SetBinding(Entry.TextProperty, nameof(AddFreightViewModel.FreightValue));
        freigthField.Border.SetBinding(Border.StrokeProperty, nameof(AddFreightViewModel.StrokeFreight));
        freigthField.Entry.TextChanged += TextChangedEntryFreight;
        contentGridBorderForm.Add(freigthField, 1, 3);

        var observation = new EditorTextFieldCustom("comment", "Observação");
        observation.Editor.SetBinding(Editor.TextProperty, nameof(AddFreightViewModel.Observation));
        contentGridBorderForm.SetColumnSpan(observation, 2);
        contentGridBorderForm.Add(observation, 0, 5);

        borderForm.Content = contentGridBorderForm;

        mainGrid.Add(borderForm, 0, 1);
    }

    private void CreateButtonSave(Grid mainGrid)
    {
        var button = new Button
        {
            Text = "Salvar",
            Style = (Style)App.Current.Resources["buttonDarkPrimary"]
        };

        button.Clicked += SaveClicked;

        mainGrid.Add(button, 0, 2);
    }

    #endregion

    #region Events

    private void TextChangedEntryKm(object sender, TextChangedEventArgs e)
    {
        var text = e.NewTextValue;

        if (string.IsNullOrEmpty(text))
        {
            SetColorDefaultKmFieldBorder();
            return;
        }

        if (!CheckTheEntrys.IsValidDouble(text))
        {
            ViewModel.StrokeKm = Colors.Red;
            return;
        }

        SetColorDefaultKmFieldBorder();
    }

    private void TextChangedEntryFreight(object sender, TextChangedEventArgs e)
    {
        var text = e.NewTextValue;

        if (string.IsNullOrEmpty(text))
        {

            SetColorDefaultFreightFieldBorder();
            return;
        }

        if (!CheckTheEntrys.IsValidDouble(text))
        {
            ViewModel.StrokeFreight = Colors.Red;
            return;
        }

        SetColorDefaultFreightFieldBorder();
    }

    private void SaveClicked(object sender, EventArgs e)
    {
        ViewModel.OnSave();
    }

    private async void TapGestureRecognizer_Tapped_GoBack(object sender, TappedEventArgs e)
    {
        View element = sender as Image;

        await ClickAnimation.SetFadeOnElement(element);

        await App.Current.MainPage.Navigation.PopAsync();        
    }

    #endregion

    #region Actions

    private void SetColorDefaultKmFieldBorder() => ViewModel.StrokeKm = Colors.LightGray;

    private void SetColorDefaultFreightFieldBorder() => ViewModel.StrokeFreight = Colors.LightGray;

    #endregion
}
