using freight.control.maui.Components.Others;
using freight.control.maui.Controls.Animations;
using freight.control.maui.MVVM.Base.Views;
using freight.control.maui.MVVM.Models;
using freight.control.maui.MVVM.ViewModels;
using freight.control.maui.Services;
using Microsoft.Maui.Controls.Shapes;

namespace freight.control.maui.MVVM.Views;

public class DetailFreightView : BaseContentPage
{
    private readonly INavigationService _navigationService;

    public DetailFreightViewModel ViewModel = new();

    public ClickAnimation ClickAnimation = new();

    public DetailFreightView(INavigationService navigationService)
	{
        _navigationService = navigationService;

        BackgroundColor = App.GetResource<Color>("PrimaryDark");

        Content = BuildDetailFreightView();

        BindingContext = ViewModel;
    }


    #region UI

    private View BuildDetailFreightView()
    {
        var mainGrid = CreateMainGrid();

        CreateStackHeader(mainGrid);

        CreateDetailsFreight(mainGrid);

        CreateTitleToFuel(mainGrid);

        CreateCollectionDetailFreight(mainGrid);

        CreateStackWithEmptyCollection(mainGrid);


        return mainGrid;
    }
  
    private Grid CreateMainGrid()
    {
        return new Grid
        {
            RowDefinitions = new RowDefinitionCollection
            {
                new () {Height = 140},
                new () {Height = GridLength.Auto},
                new () {Height = GridLength.Auto},
                new () {Height = GridLength.Star},
            },
            BackgroundColor = Colors.White,
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
            Margin = new Thickness(20, 0, 0, 0),
            HeightRequest = 20,
            HorizontalOptions = LayoutOptions.Start
        };
        var tapGestureRecognizer = new TapGestureRecognizer();
        tapGestureRecognizer.Tapped += TapGestureRecognizer_Tapped_GoBack;
        iconGoBack.GestureRecognizers.Add(tapGestureRecognizer);
        contentGridStack.Add(iconGoBack, 0, 0);

        var title = new Label
        {
            Text = "Detalhes",
            Style = App.GetResource<Style>("labelTitleView"),
        };
        contentGridStack.Add(title, 1, 0);

        var date = new Label
        {                    
            Style = App.GetResource<Style>("labelTitleView"),
            FontSize = 16          
        };
        date.SetBinding(Label.TextProperty, nameof(ViewModel.DetailTravelDate));
        contentGridStack.Add(date, 1, 1);   

        stack.Children.Add(contentGridStack);

        mainGrid.Children.Add(stack);
    }

    private void CreateDetailsFreight(Grid mainGrid)
    {
        var grid = new Grid
        {
           
            RowDefinitions = new RowDefinitionCollection
            {
                new () {Height = GridLength.Star},
                new () {Height = GridLength.Star},
                new () {Height = GridLength.Star},
                new () {Height = GridLength.Star},
                new () {Height = GridLength.Star},
                new () {Height = GridLength.Star},
            },
            BackgroundColor = Colors.White,
            Margin = 10, RowSpacing = 10,
        };
       
        var origin = new LabelDetailOfFreight("Origem:");        
        origin.ContentLabel.SetBinding(Label.TextProperty, nameof(ViewModel.DetailOrigin));
        grid.Add(origin, 0, 0);
        
        var destination = new LabelDetailOfFreight("Destino:");
        destination.ContentLabel.SetBinding(Label.TextProperty, nameof(ViewModel.DetailDestination));
        grid.Add(destination, 0, 1);

        var km = new LabelDetailOfFreight("KM:");
        km.ContentLabel.SetBinding(Label.TextProperty, nameof(ViewModel.DetailKm));
        grid.Add(km, 0, 2);

        var totalFreight = new LabelDetailOfFreight("Total Frete:");
        totalFreight.ContentLabel.SetBinding(Label.TextProperty, nameof(ViewModel.DetailTotalFreight));
        grid.Add(totalFreight, 0, 3);

        var totalFuel = new LabelDetailOfFreight("Total de Litros:");
        totalFuel.ContentLabel.SetBinding(Label.TextProperty, nameof(ViewModel.TotalFuel));
        grid.Add(totalFuel, 0, 4);

        var totalSpentInLiters = new LabelDetailOfFreight("Total gasto em Litros:");
        totalSpentInLiters.ContentLabel.SetBinding(Label.TextProperty, nameof(ViewModel.TotalSpentLiters));
        grid.Add(totalSpentInLiters, 0, 5);        

        mainGrid.Add(grid, 0, 1);
    }

    public View CreateDetailOfFreight(string title)
    {
        var stack = new StackLayout
        {
            Orientation = StackOrientation.Horizontal,
            Spacing = 10
        };

        var titleLabel = new Label
        {
            Text = title,
            TextColor = App.GetResource<Color>("PrimaryDark"),
            FontFamily = "MontserratSemiBold",
            FontSize = 16,
            VerticalOptions = LayoutOptions.Center,           
        };

        var content = new Label
        {
            TextColor = App.GetResource<Color>("PrimaryDark"),
            FontFamily = "MontserratRegular",
            FontSize = 16,
            VerticalOptions = LayoutOptions.Center
        };

        stack.Children.Add(titleLabel);
        stack.Children.Add(content);

        return stack;
    }

    private void CreateTitleToFuel(Grid mainGrid)
    {
        var stack = new StackLayout
        {
            Orientation = StackOrientation.Horizontal,
            Spacing = 10,
            HorizontalOptions = LayoutOptions.Center,
            Margin = new Thickness(0,10,0,10)
        };

        var icon = new Image
        {
            Source = ImageSource.FromFile("fuel"),
            HeightRequest = 25,
            VerticalOptions = LayoutOptions.Center
        };
        stack.Children.Add(icon);

        var titleToFuel = new Label
        {
            Text = "Abastecimentos",
            Style = App.GetResource<Style>("labelTitleView"),
            TextColor = App.GetResource<Color>("PrimaryDark")
        };
        stack.Children.Add(titleToFuel);

        mainGrid.Add(stack, 0, 2);

    }    

    private void CreateCollectionDetailFreight(Grid mainGrid)
    {
        var collection = new CollectionView
        {
            BackgroundColor = Colors.White,
            ItemTemplate = new DataTemplate(CreateItemTemplateDetailFreight),
        };
        collection.SetBinding(CollectionView.ItemsSourceProperty, nameof(ViewModel.ToFuelCollection));

        mainGrid.Add(collection, 0, 3);
    }

    private View CreateItemTemplateDetailFreight()
    {
        var border = new Border
        {
            BackgroundColor = Colors.Transparent,
            StrokeThickness = 1,
            Stroke = App.GetResource<Color>("PrimaryGreen"),
            HeightRequest = 230,
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
                new () {Height = GridLength.Star},

            },
            ColumnDefinitions = new ColumnDefinitionCollection
            {
                new () {Width = GridLength.Star},
                new () {Width = GridLength.Star},          
            }
        };

        CreateLabelDate(contentGridBorder);

        CreateIconTrash(contentGridBorder);

        CreateStackLiters(contentGridBorder);

        CreateStackAmountSpentLiters(contentGridBorder);

        CreateStackValuePerLiter(contentGridBorder);

        CreateStackExpenses(contentGridBorder);

        CreateStackObservation(contentGridBorder);

        CreateStackButtonsActions(contentGridBorder);

        border.Content = contentGridBorder;

        return border;
    }

    private void CreateLabelDate(Grid contentGridBorder)
    {
        var stack = new StackLayout
        {
            Spacing = 10,
            Orientation = StackOrientation.Horizontal,
            Margin = 10
        };

        var title = new Label
        {
            Text = "Data:",
            TextColor = App.GetResource<Color>("PrimaryDark"),
            FontFamily = "MontserratSemiBold",
            FontSize = 16,
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center
        };

        stack.Children.Add(title);

        var labelDate = new Label
        {
            TextColor = App.GetResource<Color>("PrimaryDark"),
            FontFamily = "MontserratRegular",
            FontSize = 16,
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center
        };        
        labelDate.SetBinding(Label.TextProperty, nameof(ToFuelModel.ToFuelDateCustom));

        stack.Children.Add(labelDate);

        contentGridBorder.Add(stack, 0, 0);
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

        contentGridBorder.Add(iconTrash, 1, 0);
    }
   
    private void CreateStackLiters(Grid contentGridBorder)
    {
        var stackLiters = new StackLayout
        {
            Orientation = StackOrientation.Horizontal,
            Margin = new Thickness(10, 0, 10, 0),
            Spacing = 10
        };

        var labelTitle = new Label
        {
            Text = "Litros:",
            TextColor = App.GetResource<Color>("PrimaryDark"),
            FontFamily = "MontserratSemiBold",
            FontSize = 16,
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center
        };
        stackLiters.Children.Add(labelTitle);

        var labelQtyLiters = new Label
        {
            TextColor = App.GetResource<Color>("PrimaryDark"),
            FontFamily = "MontserratRegular",
            FontSize = 16,
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center
        };
        labelQtyLiters.SetBinding(Label.TextProperty, nameof(ToFuelModel.Liters));
        stackLiters.Children.Add(labelQtyLiters);
        
        contentGridBorder.Add(stackLiters, 0, 1);
    }

    private void CreateStackAmountSpentLiters(Grid contentGridBorder)
    {
        var stackAmountSpentFuel = new StackLayout
        {
            Orientation = StackOrientation.Horizontal,
            Margin = new Thickness(10, 0, 10, 0),
            Spacing = 10
        };

        var labelTitle = new Label
        {
            Text = "Valor:",
            TextColor = App.GetResource<Color>("PrimaryDark"),
            FontFamily = "MontserratSemiBold",
            FontSize = 16,
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center
        };
        stackAmountSpentFuel.Children.Add(labelTitle);

        var labelAmountSpentFuel = new Label
        {
            TextColor = App.GetResource<Color>("PrimaryDark"),
            FontFamily = "MontserratRegular",
            FontSize = 16,
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center
        };
        labelAmountSpentFuel.SetBinding(Label.TextProperty, nameof(ToFuelModel.AmountSpentFuelCustom));
        stackAmountSpentFuel.Children.Add(labelAmountSpentFuel);

        contentGridBorder.Add(stackAmountSpentFuel, 1, 1);
    }

    private void CreateStackValuePerLiter(Grid contentGridBorder)
    {
        var stackValuePerLiter = new StackLayout
        {
            Orientation = StackOrientation.Horizontal,
            Margin = new Thickness(10, 0, 10, 0),
            Spacing = 10
        };

        var labelTitle = new Label
        {
            Text = "Valor/Litro:",
            TextColor = App.GetResource<Color>("PrimaryDark"),
            FontFamily = "MontserratSemiBold",
            FontSize = 16,
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center
        };
        stackValuePerLiter.Children.Add(labelTitle);

        var labelValuePerLiter = new Label
        {
            TextColor = App.GetResource<Color>("PrimaryDark"),
            FontFamily = "MontserratRegular",
            FontSize = 16,
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center,           
        };
        labelValuePerLiter.SetBinding(Label.TextProperty, nameof(ToFuelModel.ValuePerLiterCustom));
        stackValuePerLiter.Children.Add(labelValuePerLiter);

        contentGridBorder.SetColumnSpan(stackValuePerLiter, 2);
        contentGridBorder.Add(stackValuePerLiter, 0, 2);

    }

    private void CreateStackExpenses(Grid contentGridBorder)
    {
        var stackExpenses = new StackLayout
        {
            Orientation = StackOrientation.Horizontal,
            Margin = new Thickness(10, 0, 10, 0),
            Spacing = 10
        };

        var labelTitle = new Label
        {
            Text = "Despesas:",
            TextColor = App.GetResource<Color>("PrimaryDark"),
            FontFamily = "MontserratSemiBold",
            FontSize = 16,
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center
        };
        stackExpenses.Children.Add(labelTitle);

        var labelExpenses = new Label
        {
            TextColor = App.GetResource<Color>("PrimaryDark"),
            FontFamily = "MontserratRegular",
            FontSize = 16,
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center,
        };
        labelExpenses.SetBinding(Label.TextProperty, nameof(ToFuelModel.ExpensesCustom));
        stackExpenses.Children.Add(labelExpenses);

        contentGridBorder.SetColumnSpan(stackExpenses, 2);
        contentGridBorder.Add(stackExpenses, 0, 3);

    }

    private void CreateStackObservation(Grid contentGridBorder)
    {
        var stackObservation = new Grid
        {
            ColumnDefinitions = new ColumnDefinitionCollection
            {
                new () {Width = GridLength.Auto},
                new () {Width = GridLength.Star},
            },
            ColumnSpacing = 10,
            Margin = new Thickness(10, 0, 10, 0),
        };  
        var labelTitle = new Label
        {
            Text = "Observação:",
            TextColor = App.GetResource<Color>("PrimaryDark"),
            FontFamily = "MontserratSemiBold",
            FontSize = 16,
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center,            
        };
        stackObservation.Add(labelTitle, 0, 0);

        var labelObservation = new Label
        {
            TextColor = App.GetResource<Color>("PrimaryDark"),
            FontFamily = "MontserratRegular",
            FontSize = 16,
            VerticalOptions = LayoutOptions.Center,
            LineBreakMode = LineBreakMode.TailTruncation,
            MaxLines = 1 
        };
        labelObservation.SetBinding(Label.TextProperty, nameof(ToFuelModel.Observation));
        stackObservation.Add(labelObservation, 1, 0);

        contentGridBorder.SetColumnSpan(stackObservation, 2);
        contentGridBorder.Add(stackObservation, 0, 4);
    }

    private void CreateStackButtonsActions(Grid contentGridBorder)
    {       
        var buttonEdit = CreateBaseButton("Editar", "buttonTertiaryGreen", ClickedButtonEdit);
        buttonEdit.WidthRequest = 80;
        buttonEdit.Margin = new Thickness(0,0,10,10);
        buttonEdit.HorizontalOptions = LayoutOptions.End;

        contentGridBorder.Add(buttonEdit, 1, 5);
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

    private void CreateStackWithEmptyCollection(Grid mainGrid)
    {
        var label = new Label
        {
            Text = "Você ainda não abasteceu nesta viagem.",
            FontSize = 14,
            FontFamily = "MontserratRegular",
            TextColor = Colors.Gray,           
            HorizontalTextAlignment = TextAlignment.Center,
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center,
        };

        label.SetBinding(Label.IsVisibleProperty, nameof(ViewModel.IsVisibleTextPhraseToFuelEmpty));
      
        mainGrid.Add(label, 0,3);
    }

    #endregion

    #region Events

    private async void TapGestureRecognizer_Tapped_GoBack(object sender, TappedEventArgs e)
    {
        var element = sender as Image;

        await ClickAnimation.SetFadeOnElement(element);

        await App.Current.MainPage.Navigation.PopAsync();
    }

    private async void TapGestureRecognizer_Tapped_DeleteItem(object sender, TappedEventArgs e)
    {      
        if (sender is Image element)
        {
            await ClickAnimation.SetFadeOnElement(element);

            var result = await DisplayAlert("Excluir", "Deseja realmente excluir este abastecimento?", "Sim", "Não");

            if (!result) return;

            if (element.BindingContext is ToFuelModel item)
            {
                await ViewModel.DeleteSupply(item);
            }
        }        
    }

    private async void ClickedButtonEdit(object sender, EventArgs e)
    {
        if (sender is Button element)
        {
            if (element.BindingContext is ToFuelModel item)
            {
                Dictionary<string, object> obj = new Dictionary<string, object>
                {
                    { "SelectedToFuelToEdit", item }
                };

                await _navigationService.NavigationToPageAsync<ToFuelView>(parameters: obj);
            }
        }
    }

    #endregion

    #region Actions

    protected override void OnAppearing()
    {
        base.OnAppearing();

        var vm = BindingContext as DetailFreightViewModel;

        vm.OnAppearing();
    }

    #endregion

}
