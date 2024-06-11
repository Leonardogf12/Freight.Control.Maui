using freight.control.maui.Controls.Animations;
using freight.control.maui.MVVM.Base.Views;
using freight.control.maui.MVVM.ViewModels;
using Microcharts.Maui;

namespace freight.control.maui.MVVM.Views;

public class ChartsView : BaseContentPage
{
    #region Properties

    public ChartsViewModel ViewModel = new();

    ClickAnimation ClickAnimation = new();
    
    #endregion

    public ChartsView()
	{      
        BackgroundColor = App.GetResource<Color>("PrimaryDark");

        Content = BuildChartsView();
      
        BindingContext = ViewModel;
	}

    #region UI

    private View BuildChartsView()
    {
        var mainGrid = CreateMainGrid();

        CreateStackHeader(mainGrid);

        CreateCharts(mainGrid);

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
            RowSpacing = 10
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
            Text = "Análise",
            Style = App.GetResource<Style>("labelTitleView"),
        };
        contentGridStack.Add(title, 1, 0);

        var buttons = CreateFilterButtons();
        contentGridStack.Add(buttons, 0, 1);
        contentGridStack.SetColumnSpan(buttons, 3);

        stack.Children.Add(contentGridStack);

        mainGrid.Add(stack, 0, 0);
    }

    private View CreateFilterButtons()
    {
        var grid = new Grid
        {
            ColumnDefinitions = new ColumnDefinitionCollection
            {
                new () {Width = GridLength.Star},
                new () {Width = GridLength.Star},             
            },
            ColumnSpacing = 0
        };

        var monthlyButton = new Button
        {
            Text = "Mensal",           
        };
        monthlyButton.SetBinding(Button.StyleProperty, nameof(ViewModel.MonthButtonStyle));
        monthlyButton.Clicked += MonthlyButton_Clicked;
        grid.Add(monthlyButton, 0, 0);

        var dailyButton = new Button
        {
            Text = "Diário",                 
        };
        dailyButton.SetBinding(Button.StyleProperty, nameof(ViewModel.DayButtonStyle));
        dailyButton.Clicked += DailyButton_Clicked;
        grid.Add(dailyButton, 1, 0);
        
        return grid;
    }
  
    private void CreateCharts(Grid mainGrid)
    {
        var scroll = new ScrollView
        {
            Orientation = ScrollOrientation.Vertical
        };

        var grid = new Grid
        {            
            RowDefinitions = new RowDefinitionCollection
            {
               new () { Height = GridLength.Star},
               new () { Height = GridLength.Star},       
            },
           RowSpacing = 20,
        };

        var stackFreight = new StackLayout
        {
            Orientation = StackOrientation.Vertical,
            Spacing = 5,
        };

        var freightChartTitle = new Label
        {
           Text = "Fretes",
           Margin = new Thickness(10,0,0,0)
        };
        stackFreight.Children.Add(freightChartTitle);

        var scrollViewMonthly = new ScrollView
        {
            Orientation = ScrollOrientation.Horizontal,
            Content = CreateLineChartFreight()
        };
        stackFreight.Children.Add(scrollViewMonthly);

        grid.Add(stackFreight, 0, 0);

        var stackToFuel = new StackLayout
        {
            Orientation = StackOrientation.Vertical,
            Spacing = 5,
        };

        var toFuelChartTitle = new Label
        {
            Text = "Abastecimento",
            Margin = new Thickness(10, 0, 0, 0)
        };
        stackToFuel.Children.Add(toFuelChartTitle);
        
        var scrollViewChartToFuel = new ScrollView
        {
            Orientation = ScrollOrientation.Horizontal,
            Content = CreateLineChartToFuel()
        };
        stackToFuel.Children.Add(scrollViewChartToFuel);

        grid.Add(stackToFuel, 0, 1);    

        scroll.Content = grid;

        mainGrid.Add(scroll, 0, 1);
    }

    private View CreateLineChartFreight()
    {       
        var chart = new ChartView
        {
            BindingContext = ViewModel,
            Margin = new Thickness(10),
            HeightRequest = 200,         
            HorizontalOptions = LayoutOptions.Center,
            FlowDirection = FlowDirection.LeftToRight,                    
        };
        chart.SetBinding(WidthRequestProperty, nameof(ViewModel.WidthLineChartFreight));
        chart.SetBinding(ChartView.ChartProperty, nameof(ViewModel.FreightChart));
       
        return chart;
    }

    private View CreateLineChartToFuel()
    {
        var chart = new ChartView
        {
            BindingContext = ViewModel,
            Margin = new Thickness(10),
            HeightRequest = 200,
            HorizontalOptions = LayoutOptions.Center,
            FlowDirection = FlowDirection.LeftToRight,                  
        };
        
        chart.SetBinding(WidthRequestProperty, nameof(ViewModel.WidthLineChartToFuel));
        chart.SetBinding(ChartView.ChartProperty, nameof(ViewModel.ToFuelChart));        

        return chart;        
    }

    #endregion

    #region Events

    private async void TapGestureRecognizer_Tapped_GoBack(object sender, TappedEventArgs e)
    {
        View element = sender as Image;

        await ClickAnimation.SetFadeOnElement(element);

        await App.Current.MainPage.Navigation.PopAsync();
    }
    
    private async void MonthlyButton_Clicked(object sender, EventArgs e)
    {
        ViewModel.MonthButtonStyle = App.GetResource<Style>("buttonDarkLightFilterSecondary");
        ViewModel.DayButtonStyle = App.GetResource<Style>("buttonDarkLightFilterPrimary");

        await LoadMonthlyCharts();        
    }
    
    private async void DailyButton_Clicked(object sender, EventArgs e)
    {
        ViewModel.DayButtonStyle = App.GetResource<Style>("buttonDarkLightFilterSecondary");
        ViewModel.MonthButtonStyle = App.GetResource<Style>("buttonDarkLightFilterPrimary");

        await LoadDailyCharts();
       
    }
   
    #endregion

    #region Actions

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await LoadMonthlyCharts();
    }

    private async Task LoadMonthlyCharts()
    {
        await ViewModel.LoadEntriesFreightChartMonthly();
        await ViewModel.LoadEntriesToFuelChartMonthly();
    }

    private async Task LoadDailyCharts()
    {
        await ViewModel.LoadEntriesFreightChartsDaily();
        await ViewModel.LoadEntriesToFuelChartsDaily();
    }

    #endregion
}
