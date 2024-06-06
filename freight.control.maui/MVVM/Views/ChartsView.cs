using freight.control.maui.Controls.Animations;
using freight.control.maui.MVVM.Base.Views;
using freight.control.maui.MVVM.ViewModels;
using Microcharts;
using Microcharts.Maui;
using SkiaSharp;

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

        var yearButton = new Button
        {
            Text = "Anual",           
        };
        yearButton.SetBinding(Button.StyleProperty, nameof(ViewModel.YearButtonStyle));
        yearButton.Clicked += YearButton_Clicked;
        grid.Add(yearButton, 0, 0);

        var mounthButton = new Button
        {
            Text = "Mensal",                 
        };
        mounthButton.SetBinding(Button.StyleProperty, nameof(ViewModel.MounthButtonStyle));
        mounthButton.Clicked += MounthButton_Clicked;
        grid.Add(mounthButton, 1, 0);
        
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

        var scrollViewYear = new ScrollView
        {
            Orientation = ScrollOrientation.Horizontal,
            Content = CreateLineChartFreight()
        };
        stackFreight.Children.Add(scrollViewYear);

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
        stackFreight.Children.Add(toFuelChartTitle);
        
        var scrollViewMounth= new ScrollView
        {
            Orientation = ScrollOrientation.Horizontal,
            Content = CreateLineChartMounth()
        };
        stackFreight.Children.Add(scrollViewMounth);

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
            Chart = ViewModel.FreightChart,            
        };
        chart.SetBinding(WidthRequestProperty, nameof(ViewModel.WidthLineChartFreight));
        chart.SetBinding(ChartView.ChartProperty, nameof(ViewModel.FreightChart));
       
        return chart;
    }

    private View CreateLineChartMounth()
    {
        var chart = new ChartView
        {
            Margin = new Thickness(10),
            HeightRequest = 500,
            WidthRequest = 1000,
            HorizontalOptions = LayoutOptions.CenterAndExpand,
            FlowDirection = FlowDirection.LeftToRight,

            Chart = new LineChart
            {
                Entries = new ChartEntry[new int { }],
                IsAnimated = true,
                LineMode = LineMode.Straight,
                PointMode = PointMode.Square,
                LabelTextSize = 30,
                PointSize = 15,
                MaxValue = 100,
                MinValue = 0,
                Margin = 80,
                LabelOrientation = Orientation.Horizontal,
                ValueLabelOrientation = Orientation.Horizontal,
                BackgroundColor = SKColor.Parse("#333850"),
                LabelColor = SKColor.Parse("#FFFFFF"),
                Typeface = SKTypeface.Default,
            }
        };
        
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
    
    private void YearButton_Clicked(object sender, EventArgs e)
    {
        ViewModel.YearButtonStyle = App.GetResource<Style>("buttonDarkLightFilterSecondary");
        ViewModel.MounthButtonStyle = App.GetResource<Style>("buttonDarkLightFilterPrimary");              
    }

    private void MounthButton_Clicked(object sender, EventArgs e)
    {
        ViewModel.MounthButtonStyle = App.GetResource<Style>("buttonDarkLightFilterSecondary");
        ViewModel.YearButtonStyle = App.GetResource<Style>("buttonDarkLightFilterPrimary");             
    }

    #endregion

    #region Actions

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await ViewModel.LoadEntrysToCharts();
    }

    #endregion


}
