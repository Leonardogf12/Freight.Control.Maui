using DevExpress.Maui.Editors;
using freight.control.maui.Components;
using freight.control.maui.Controls.Animations;
using freight.control.maui.Controls.ControlCheckers;
using freight.control.maui.MVVM.Base.Views;
using freight.control.maui.MVVM.Models;
using freight.control.maui.MVVM.ViewModels;
using Microsoft.Maui.Controls.Shapes;

namespace freight.control.maui.MVVM.Views;

public class AddFreightView : BaseContentPage
{
    public AddFreightViewModel ViewModel = new();

    public ClickAnimation ClickAnimation = new();

    public AddFreightView()
	{
        BackgroundColor = Colors.White;
       
        Content = BuildAddFreightView();

        CreateLoadingPopupView(this, ViewModel);
       
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
            HorizontalOptions = LayoutOptions.Start
        };

        var tapGestureRecognizer = new TapGestureRecognizer();
        tapGestureRecognizer.Tapped += TapGestureRecognizer_Tapped_GoBack;

        imageBackButton.GestureRecognizers.Add(tapGestureRecognizer);

        contentGridStackTitle.Add(imageBackButton, 0, 0);

        var labelTitle = new Label
        {            
            TextColor = (Color)App.Current.Resources["PrimaryDark"],
            Style = (Style)App.Current.Resources["labelTitleView"],
        };
        labelTitle.SetBinding(Label.TextProperty, nameof(ViewModel.TextTitlePage));
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
                new () { Width = GridLength.Star},
                new () { Width = GridLength.Star},               
            }
        };

        CreateTravelDateFieldForm(contentGridBorderForm);

        CreateOriginFieldForm(contentGridBorderForm);

        CreateDestinationFieldForm(contentGridBorderForm);

        CreateKmFieldForm(contentGridBorderForm);

        CreateFreightValueFieldForm(contentGridBorderForm);

        CreateObservationFieldCustom(contentGridBorderForm);
    
        borderForm.Content = contentGridBorderForm;

        mainGrid.Add(borderForm, 0, 1);
    }
   
    private void CreateTravelDateFieldForm(Grid contentGridBorderForm)
    {
        var travel = new DatePickerFieldCustom();
        travel.DatePicker.SetBinding(DatePicker.DateProperty, nameof(AddFreightViewModel.TravelDate));
        contentGridBorderForm.SetColumnSpan(travel, 5);
        contentGridBorderForm.Add(travel, 0, 0);
    }

    private void CreateOriginFieldForm(Grid contentGridBorderForm)
    {
        var grid = new Grid
        {
            RowDefinitions = new RowDefinitionCollection
            {
                new () { Height = GridLength.Star},
                new () { Height = GridLength.Star},
            },
            ColumnDefinitions = new ColumnDefinitionCollection
            {
                new () { Width = GridLength.Star},
                new () { Width = GridLength.Star},
                new () { Width = GridLength.Star},
                new () { Width = GridLength.Star},
                new () { Width = GridLength.Star},
            },
            //Margin = new Thickness(0, 15, 0, 0),
            RowSpacing = 3
        };

        var title = new Label
        {
            Text = "Origem",
            FontFamily = "MontserratRegular",
            FontSize = 16,            
            VerticalOptions = LayoutOptions.Center,           
            Margin = new Thickness(10, 0, 0, 0),
        };
        grid.SetColumnSpan(title, 5);
        grid.Add(title, 0, 0);

        var originUf = new ComboboxEditCustom(icon: "uf_24")
        {           
            Margin = new Thickness(10, 0, 5, 0),           
        };
        originUf.SetBinding(ItemsEditBase.ItemsSourceProperty, nameof(ViewModel.OriginUfCollection));
        originUf.SelectionChanged += OriginUf_SelectionChanged;
        originUf.SetBinding(ComboBoxEdit.SelectedItemProperty, nameof(ViewModel.SelectedItemOriginUf), BindingMode.TwoWay);       
        grid.SetColumnSpan(originUf, 2);
        grid.Add(originUf, 0, 1);

        var origin = new ComboboxEditCustom(icon: "local_24")
        {           
            Margin = new Thickness(0, 0, 10, 0),           
        };
        origin.SetBinding(ItemsEditBase.ItemsSourceProperty, nameof(ViewModel.OriginCollection));
        origin.SetBinding(ComboBoxEdit.SelectedItemProperty, nameof(ViewModel.SelectedItemOrigin), BindingMode.TwoWay);
        grid.SetColumnSpan(origin, 3);
        grid.Add(origin, 2, 1);
            
        contentGridBorderForm.SetColumnSpan(grid, 5);
        contentGridBorderForm.Add(grid, 0, 1);
    }
   
    private void CreateDestinationFieldForm(Grid contentGridBorderForm)
    {
        var grid = new Grid
        {
            RowDefinitions = new RowDefinitionCollection
            {
                new () { Height = GridLength.Auto},
                new () { Height = GridLength.Star},
            },
            ColumnDefinitions = new ColumnDefinitionCollection
            {
                new () { Width = GridLength.Star},
                new () { Width = GridLength.Star},
                new () { Width = GridLength.Star},
                new () { Width = GridLength.Star},
                new () { Width = GridLength.Star},
            },
            //Margin = new Thickness(0, 0, 0, 0),
            RowSpacing = 3
        };

        var title = new Label
        {
            Text = "Destino",
            FontFamily = "MontserratRegular",
            FontSize = 16,
            HorizontalOptions = LayoutOptions.Start,
            VerticalOptions = LayoutOptions.Center,
            Margin = new Thickness(10, 0, 0, 0),
        };
        grid.SetColumnSpan(title, 5);
        grid.Add(title, 0, 0);

        var destinationUf = new ComboboxEditCustom(icon: "uf_24")
        {
            Margin = new Thickness(10, 0, 5, 0),
        };
        destinationUf.SetBinding(ItemsEditBase.ItemsSourceProperty, nameof(ViewModel.DestinationUfCollection));
        destinationUf.SelectionChanged += DestinationUf_SelectionChanged;
        destinationUf.SetBinding(ComboBoxEdit.SelectedItemProperty, nameof(ViewModel.SelectedItemDestinationUf), BindingMode.TwoWay);       
        grid.SetColumnSpan(destinationUf, 2);
        grid.Add(destinationUf, 0, 1);

        var destination = new ComboboxEditCustom(icon: "local_24")
        {
            Margin = new Thickness(0, 0, 10, 0),
        };
        destination.SetBinding(ItemsEditBase.ItemsSourceProperty, nameof(ViewModel.DestinationCollection));
        destination.SetBinding(ComboBoxEdit.SelectedItemProperty, nameof(ViewModel.SelectedItemDestination));
        grid.SetColumnSpan(destination, 3);
        grid.Add(destination, 2, 1);

        contentGridBorderForm.SetColumnSpan(grid, 5);
        contentGridBorderForm.Add(grid, 0, 2);
    }

   

    private void CreateKmFieldForm(Grid contentGridBorderForm)
    {        
        var km = new TextEditCustom(icon: "km_24", placeholder: "Km: 1000", keyboard: Keyboard.Numeric)
        {
            Margin = new Thickness(10, 15, 5, 0),
        };
        km.SetBinding(TextEditBase.TextProperty, nameof(ViewModel.Kilometer));
        km.SetBinding(EditBase.BorderColorProperty, nameof(ViewModel.BorderColorKm));
        km.SetBinding(EditBase.FocusedBorderColorProperty, nameof(ViewModel.BorderColorFocusedKm));
        km.TextChanged += Km_TextChanged;
        contentGridBorderForm.SetColumnSpan(km, 2);
        contentGridBorderForm.Add(km, 0, 3);
    }

    private void CreateFreightValueFieldForm(Grid contentGridBorderForm)
    {
        var freigthField = new TextEditCustom(icon: "money_24", placeholder: "R$ 1000.00", keyboard: Keyboard.Numeric)
        {
            Margin = new Thickness(0, 15, 10, 0),
        };
        freigthField.SetBinding(TextEditBase.TextProperty, nameof(ViewModel.FreightValue));
        freigthField.SetBinding(EditBase.BorderColorProperty, nameof(ViewModel.BorderColorFreightValue));
        freigthField.SetBinding(EditBase.FocusedBorderColorProperty, nameof(ViewModel.BorderColorFocusedFreightValue));
        freigthField.TextChanged += FreigthField_TextChanged;
        contentGridBorderForm.SetColumnSpan(freigthField, 2);
        contentGridBorderForm.Add(freigthField, 2, 3);
    }

    private void CreateObservationFieldCustom(Grid contentGridBorderForm)
    {
        var observation = new MultilineEditCustom(icon: "comment_24", placeholder: "Observacão");
        observation.SetBinding(TextEditBase.TextProperty, nameof(ViewModel.Observation));
        contentGridBorderForm.SetColumnSpan(observation, 4);
        contentGridBorderForm.Add(observation, 0, 5);
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

    private void OriginUf_SelectionChanged(object sender, EventArgs e)
    {       
        if(sender is ComboBoxEdit element)
        {
            if(element.SelectedItem is string uf)
            {                
                ViewModel.SelectedItemOriginUf = uf;
                ViewModel.ChangedItemOriginUf(uf);
            }
        }
    }

    private void DestinationUf_SelectionChanged(object sender, EventArgs e)
    {
        if (sender is ComboBoxEdit element)
        {
            if (element.SelectedItem is string uf)
            {
                ViewModel.SelectedItemDestinationUf = uf;
                ViewModel.ChangedItemDestinationUf(uf);
            }
        }
    }


    private void Km_TextChanged(object sender, EventArgs e)
    {
        var element = sender as TextEdit;

        var text = element.Text;

        if (string.IsNullOrEmpty(text))
        {
            SetBorderColorDefaultKmField();
            return;
        }

        if (!CheckTheEntrys.IsValidEntry(text, CheckTheEntrys.patternKilometer))
        {
            ViewModel.BorderColorKm = Colors.Red;
            ViewModel.BorderColorFocusedKm = Colors.Red;
            return;
        }

        SetBorderColorDefaultKmField();
    }

    private void FreigthField_TextChanged(object sender, EventArgs e)
    {
        var element = sender as TextEdit;

        var text = element.Text;

        if (string.IsNullOrEmpty(text))
        {
            SetBorderColorDefaultFreightField();
            return;
        }

        if (!CheckTheEntrys.IsValidEntry(text, CheckTheEntrys.patternMoney))
        {
            ViewModel.BorderColorFreightValue = Colors.Red;
            ViewModel.BorderColorFocusedFreightValue = Colors.Red;

            return;
        }

        SetBorderColorDefaultFreightField();
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

    private void SetBorderColorDefaultKmField()
    {
       ViewModel.BorderColorKm = Colors.LightGray;
       ViewModel.BorderColorFocusedKm = Colors.Gray;
    }

    private void SetBorderColorDefaultFreightField()
    {
        ViewModel.BorderColorFreightValue = Colors.LightGray;
        ViewModel.BorderColorFocusedFreightValue = Colors.Gray;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ViewModel.OnAppearing();
    }
  
    #endregion
}
