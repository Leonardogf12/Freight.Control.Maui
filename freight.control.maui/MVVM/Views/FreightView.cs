using freight.control.maui.Controls.Animations;
using freight.control.maui.MVVM.Base.Views;
using freight.control.maui.MVVM.Models;
using freight.control.maui.MVVM.ViewModels;
using Microsoft.Maui.Controls.Shapes;

namespace freight.control.maui.MVVM.Views;

public class FreightView : BaseContentPage
{
    public FreightViewModel ViewModel = new();

    ClickAnimation ClickAnimation = new();

    public FreightView()
	{
        BackgroundColor = App.GetResource<Color>("PrimaryDark");

		Content = BuildFreightView();

        BindingContext = ViewModel;
    }

    #region UI
   
    private View BuildFreightView()
    {       
        var mainGrid = CreateMainGrid();

        CreateStackHeader(mainGrid);

        CreateCollectionFreight(mainGrid);

        return mainGrid;
    }
    
    private Grid CreateMainGrid()
    {
        return new Grid
        {
            RowDefinitions = new RowDefinitionCollection
            {
                new () {Height = 140},
                new () {Height = GridLength.Star},
            },
        };
    }

    private void CreateStackHeader(Grid mainGrid)
    {
        var stack = new StackLayout
        {
            BackgroundColor = App.GetResource<Color>("PrimaryDark"),
        };

        var contentGridStack = new Grid
        {
            RowDefinitions = new RowDefinitionCollection
            {
                new () {Height = 50},
                new () {Height = 100},
            },
            ColumnDefinitions = new ColumnDefinitionCollection
            {
                new(){Width = GridLength.Star},
                new(){Width = GridLength.Star},
                new(){Width = GridLength.Star},
            },
            ColumnSpacing = 15,
            Margin = 10
        };

        var iconGoBack = new Image
        {
            Source = ImageSource.FromFile("back_white"),
            Margin = new Thickness(20,0,0,0),
            HeightRequest = 20,
            HorizontalOptions = LayoutOptions.Start
        };
        var tapGestureRecognizer = new TapGestureRecognizer();
        tapGestureRecognizer.Tapped += TapGestureRecognizer_Tapped_GoBack;
        iconGoBack.GestureRecognizers.Add(tapGestureRecognizer);
        contentGridStack.Add(iconGoBack, 0, 0);

        var title = new Label
        {
            Text = "Fretes",            
            Style = App.GetResource<Style>("labelTitleView"),
        };
        contentGridStack.Add(title, 1, 0);

        var buttonNew = CreateBaseButton(text: "Novo", style: "buttonDarkLight", clicked: ClickedButtonNew);
        contentGridStack.Add(buttonNew, 0, 1);

        var buttonFilter = CreateBaseButton(text: "Filtrar", style: "buttonDarkLight", clicked: ClickedButtonFilter);
        contentGridStack.Add(buttonFilter, 1, 1);

        var buttonExport= CreateBaseButton(text: "Exportar", style: "buttonDarkLight", clicked: ClickedButtonExport);
        contentGridStack.Add(buttonExport, 2, 1);

        stack.Children.Add(contentGridStack);

        mainGrid.Children.Add(stack);
    }

    private void CreateCollectionFreight(Grid mainGrid)
    {
        var collection = new CollectionView
        {
            BackgroundColor = Colors.White,
            ItemTemplate = new DataTemplate(CreateItemTemplateFreight),
        };
        collection.SetBinding(CollectionView.ItemsSourceProperty, nameof(FreightViewModel.FreightCollection));

        mainGrid.Add(collection, 0, 1); 
    }

    private View CreateItemTemplateFreight()
    {
        var border = new Border
        {
            BackgroundColor = Colors.Transparent,
            StrokeThickness = 1,
            Stroke = App.GetResource<Color>("PrimaryGreen"),
            HeightRequest = 200,
            Margin = Device.RuntimePlatform == Device.Android ? 10 : 20,
            StrokeShape = new RoundRectangle
            {
                CornerRadius = 10,
            }
        };

        var contentGridBorder = new Grid
        {
            RowDefinitions = new RowDefinitionCollection
            {
                new () {Height = GridLength.Star},
                new () {Height = GridLength.Star},
                new () {Height = GridLength.Star},
                new () {Height = GridLength.Star},
                new () {Height = GridLength.Star},
            },
            ColumnDefinitions = new ColumnDefinitionCollection
            {
                new () {Width = GridLength.Star},
                new () {Width = GridLength.Star},
                new () {Width = GridLength.Star},
            }
        };

        CreateLabelDate(contentGridBorder);

        CreateIconTrash(contentGridBorder);

        CreateStackOrigin(contentGridBorder);

        CreateStackDestination(contentGridBorder);

        CreateStackKilometer(contentGridBorder);

        CreateStackButtonsActions(contentGridBorder);

        border.Content = contentGridBorder;

        return border;
    }
   
    private void CreateLabelDate(Grid contentGridBorder)
        {
            var labelDate = new Label
            {
                TextColor = App.GetResource<Color>("PrimaryDark"),
                FontFamily = "MontserratSemiBold",
                FontSize = 16,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            labelDate.SetBinding(Label.TextProperty, nameof(FreightModel.TravelDateCustom));
            contentGridBorder.Add(labelDate, 1, 0);
        }

    private void CreateIconTrash(Grid contentGridBorder)
    {
        var iconTrash = new Image
        {
            Source = ImageSource.FromFile("trash"),
            HeightRequest = 25,
            HorizontalOptions = LayoutOptions.End,
            Margin = 10
        };
        var tapGestureRecognizer = new TapGestureRecognizer();
        tapGestureRecognizer.Tapped += TapGestureRecognizer_Tapped_DeleteItem;
        iconTrash.GestureRecognizers.Add(tapGestureRecognizer);

        contentGridBorder.Add(iconTrash, 2, 0);
    }

    private void CreateStackOrigin(Grid contentGridBorder)
    {
        var stackOrigin = new StackLayout
        {
            Orientation = StackOrientation.Horizontal,
            Margin = new Thickness(10, 0, 10, 0),
            Spacing = 10
        };

        var iconOrigin = new Image
        {
            Source = ImageSource.FromFile("shipment"),
            HeightRequest = 25,
            HorizontalOptions = LayoutOptions.End,
            Margin = 10
        };
        stackOrigin.Children.Add(iconOrigin);

        var labelOrigin= new Label
        {
            TextColor = App.GetResource<Color>("PrimaryDark"),
            FontFamily = "MontserratRegular",
            FontSize = 16,
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center
        };
        labelOrigin.SetBinding(Label.TextProperty, nameof(FreightModel.Origin));
        stackOrigin.Children.Add(labelOrigin);

        contentGridBorder.SetColumnSpan(stackOrigin, 3);
        contentGridBorder.Add(stackOrigin, 0, 1);
    }

    private void CreateStackDestination(Grid contentGridBorder)
    {
        var stackDestination = new StackLayout
        {
            Orientation = StackOrientation.Horizontal,
            Margin = new Thickness(10, 0, 10, 0),
            Spacing = 10
        };

        var iconDestination = new Image
        {
            Source = ImageSource.FromFile("landing"),
            HeightRequest = 25,
            HorizontalOptions = LayoutOptions.End,
            Margin = 10
        };
        stackDestination.Children.Add(iconDestination);

        var labelDestination = new Label
        {
            TextColor = App.GetResource<Color>("PrimaryDark"),
            FontFamily = "MontserratRegular",
            FontSize = 16,
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center
        };
        labelDestination.SetBinding(Label.TextProperty, nameof(FreightModel.Destination));
        stackDestination.Children.Add(labelDestination);

        contentGridBorder.SetColumnSpan(stackDestination, 3);
        contentGridBorder.Add(stackDestination, 0, 2);
    }

    private void CreateStackKilometer(Grid contentGridBorder)
    {
        var stackKm = new StackLayout
        {
            Orientation = StackOrientation.Horizontal,
            Margin = new Thickness(10, 0, 10, 0),
            Spacing = 10
        };

        var iconKm = new Image
        {
            Source = ImageSource.FromFile("km"),
            HeightRequest = 25,
            HorizontalOptions = LayoutOptions.End,
            Margin = 10
        };
        stackKm.Children.Add(iconKm);

        var labelKm = new Label
        {
            TextColor = App.GetResource<Color>("PrimaryDark"),
            FontFamily = "MontserratRegular",
            FontSize = 16,
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center
        };
        labelKm.SetBinding(Label.TextProperty, nameof(FreightModel.Kilometer));
        stackKm.Children.Add(labelKm);

        contentGridBorder.SetColumnSpan(stackKm, 3);
        contentGridBorder.Add(stackKm, 0, 3);
    }

    private void CreateStackButtonsActions(Grid contentGridBorder)
    {
        var stack = new StackLayout
        {
            Margin = new Thickness(10,0,10,0),
            Spacing = 10
        };

        var contentGridStack = new Grid
        {
            ColumnDefinitions = new ColumnDefinitionCollection
            {
                new () { Width = GridLength.Star },
                new () { Width = GridLength.Star },
                new () { Width = GridLength.Star },
            },
            ColumnSpacing = 10
        };

        var buttonSee = CreateBaseButton("Ver", "buttonTertiaryGreen", ClickedButtonSee);
        contentGridStack.Add(buttonSee, 0, 0);

        var buttonToFuel = CreateBaseButton("Abastecer", "buttonTertiaryGreen", ClickedButtonToFuel);
        contentGridStack.Add(buttonToFuel, 1, 0);

        var buttonEdit = CreateBaseButton("Editar", "buttonTertiaryGreen", ClickedButtonEdit);
        contentGridStack.Add(buttonEdit, 2, 0);

        stack.Children.Add(contentGridStack);

        contentGridBorder.SetColumnSpan(stack,4);
        contentGridBorder.Add(stack, 0, 4);
    }
   
    private Button CreateBaseButton(string text, string style, EventHandler clicked)
    {
        var button = new Button
        {
            Text = text,
            Style = App.GetResource<Style>(style),
        };

        button.Clicked += clicked;

        return button;
    }

    #endregion

    #region Events

    private async void TapGestureRecognizer_Tapped_GoBack(object sender, TappedEventArgs e)
    {
        View element = sender as Image;

        await ClickAnimation.SetFadeOnElement(element);
    
        await App.Current.MainPage.Navigation.PopAsync();
    }

    private async void ClickedButtonNew(object sender, EventArgs e)
    {
        await App.Current.MainPage.Navigation.PushAsync(new AddFreightView());
    }

    private async void ClickedButtonFilter(object sender, EventArgs e)
    {
        await App.Current.MainPage.DisplayAlert("Filter", "Future implementation", "Ok");
    }

    private async void ClickedButtonExport(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ExportView());
    }

    private async void TapGestureRecognizer_Tapped_DeleteItem(object sender, TappedEventArgs e)
    {
        await App.Current.MainPage.DisplayAlert("Delete Item", "Future implementation", "Ok");
    }

    private async void ClickedButtonSee(object sender, EventArgs e)
    {
        await App.Current.MainPage.Navigation.PushAsync(new DetailFreightView());
    }

    private async void ClickedButtonToFuel(object sender, EventArgs e)
    {
        await App.Current.MainPage.Navigation.PushAsync(new ToFuelView());
    }

    private async void ClickedButtonEdit(object sender, EventArgs e)
    {
        await App.Current.MainPage.DisplayAlert("Edit", "Future implementation", "Ok");
    }

    #endregion

    #region Actions

    protected override void OnAppearing()
    {
        base.OnAppearing();

        var vm = BindingContext as FreightViewModel;

        vm.OnAppearing();
    }


    #endregion
}
