using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DevExpress.Maui.Controls;
using freight.control.maui.Components;
using freight.control.maui.Controls.Animations;
using freight.control.maui.MVVM.Base.Views;
using freight.control.maui.MVVM.Models;
using freight.control.maui.MVVM.ViewModels;
using freight.control.maui.Services;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Graphics;
using Color = Microsoft.Maui.Graphics.Color;
using Style = Microsoft.Maui.Controls.Style;

namespace freight.control.maui.MVVM.Views;

public class FreightView : BaseContentPage
{
    private readonly INavigationService _navigationService;
  
    public FreightViewModel ViewModel = new();

    #region Properties

    ClickAnimation ClickAnimation = new();

    public BottomSheet BottomSheetFilter;

    public BottomSheet BottomSheetExport;

    #endregion

    public FreightView(INavigationService navigationService)
	{
        _navigationService = navigationService;   

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

        CreateLabelAddNewFreights(mainGrid);

        CreateBottomSheetFilter(mainGrid);

        CreateBottomSheetExport(mainGrid);

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
        var refresh = new RefreshView
        {
            RefreshColor = App.GetResource<Color>("PrimaryDark")
        };
        refresh.SetBinding(RefreshView.IsRefreshingProperty, nameof(ViewModel.IsRefreshingView));
        refresh.Command = ViewModel.RefreshingCommand;
        
        var collection = new CollectionView
        {
            BackgroundColor = Colors.White,
            ItemTemplate = new DataTemplate(CreateItemTemplateFreight),
        };
        collection.SetBinding(CollectionView.ItemsSourceProperty, nameof(FreightViewModel.FreightCollection));       

        refresh.Content = collection;
        mainGrid.Add(refresh, 0, 1);
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
            Spacing = 5
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

        var divider = new Label
        {
            Text = "-",
            TextColor = App.GetResource<Color>("PrimaryDark"),
            FontFamily = "MontserratRegular",
            FontSize = 16,
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center
        };      
        stackOrigin.Children.Add(divider);

        var labelUf = new Label
        {
            TextColor = App.GetResource<Color>("PrimaryDark"),
            FontFamily = "MontserratRegular",
            FontSize = 16,
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center
        };
        labelUf.SetBinding(Label.TextProperty, nameof(FreightModel.OriginUf));
        stackOrigin.Children.Add(labelUf);

        contentGridBorder.SetColumnSpan(stackOrigin, 3);
        contentGridBorder.Add(stackOrigin, 0, 1);
    }

    private void CreateStackDestination(Grid contentGridBorder)
    {
        var stackDestination = new StackLayout
        {
            Orientation = StackOrientation.Horizontal,
            Margin = new Thickness(10, 0, 10, 0),
            Spacing = 5
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

        var divider = new Label
        {
            Text = "-",
            TextColor = App.GetResource<Color>("PrimaryDark"),
            FontFamily = "MontserratRegular",
            FontSize = 16,
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center
        };
        stackDestination.Children.Add(divider);

        var labelUf = new Label
        {
            TextColor = App.GetResource<Color>("PrimaryDark"),
            FontFamily = "MontserratRegular",
            FontSize = 16,
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center
        };
        labelUf.SetBinding(Label.TextProperty, nameof(FreightModel.DestinationUf));
        stackDestination.Children.Add(labelUf);

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
            Source = ImageSource.FromFile("km_24"),
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
     
    private void CreateLabelAddNewFreights(Grid contentGridBorder)
    {
        var label = new Label
        {
            Text = "Clique em Novo para adicionar um frete",
            FontSize = 14,
            FontFamily = "MontserratRegular",
            TextColor = Colors.Gray,
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center
        };
        label.SetBinding(Label.IsVisibleProperty, nameof(ViewModel.IsVisibleTextAddNewFreight));

        contentGridBorder.SetRowSpan(label,3);
        contentGridBorder.Children.Add(label);
    }

    private void CreateBottomSheetFilter(Grid mainGrid)
    {       
        var bottomSheetFilter = new BottomSheetFilterDateCustom(title: "Filtrar", textButton: "Confirmar", EventFilter);
        bottomSheetFilter.DatePickerFieldCustomInitialDate.DatePicker.SetBinding(DatePicker.DateProperty, nameof(ViewModel.InitialDate));
        bottomSheetFilter.DatePickerFieldCustomFinalDate.DatePicker.SetBinding(DatePicker.DateProperty, nameof(ViewModel.FinalDate));

        BottomSheetFilter = bottomSheetFilter;

        mainGrid.Add(BottomSheetFilter, 0, 1);
    }

    private void CreateBottomSheetExport(Grid mainGrid)
    {
        var bottomSheetExport = new BottomSheetFilterDateCustom(title: "Exportar", textButton: "Exportar", EventExport);
        bottomSheetExport.DatePickerFieldCustomInitialDate.DatePicker.SetBinding(DatePicker.DateProperty, nameof(ViewModel.InitialDate));
        bottomSheetExport.DatePickerFieldCustomFinalDate.DatePicker.SetBinding(DatePicker.DateProperty, nameof(ViewModel.FinalDate));

        BottomSheetExport = bottomSheetExport;

        mainGrid.Add(BottomSheetExport, 0, 1);
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

    private void ClickedButtonFilter(object sender, EventArgs e)
    {     
        BottomSheetFilter.State = BottomSheetState.HalfExpanded;
    }

    private void ClickedButtonExport(object sender, EventArgs e)
    {        
        BottomSheetExport.State = BottomSheetState.HalfExpanded;       
    }

    private async void TapGestureRecognizer_Tapped_DeleteItem(object sender, TappedEventArgs e)
    {                   
        if (sender is Image element)
        {
            await ClickAnimation.SetFadeOnElement(element);

            var result = await DisplayAlert("Excluir", "Deseja realmente excluir este frete?", "Sim", "Não");

            if (!result) return;

            if (element.BindingContext is FreightModel item)
            {
                await ViewModel.DeleteFreight(item);
            }
        }       
    }

    private async void ClickedButtonSee(object sender, EventArgs e)
    {
        if (sender is Button element)
        {
            if (element.BindingContext is FreightModel item)
            {
                Dictionary<string, object> obj = new Dictionary<string, object>
                {
                    { "SelectedFreightToDetail", item }
                };

                await _navigationService.NavigationToPageAsync<DetailFreightView>(parameters: obj);
            }
        }
    }

    private async void ClickedButtonToFuel(object sender, EventArgs e)
    {
        if (sender is Button element)
        {
            if (element.BindingContext is FreightModel item)
            {
                Dictionary<string, object> obj = new Dictionary<string, object>
                {
                    { "DetailsFreight", item }
                };

                await _navigationService.NavigationToPageAsync<ToFuelView>(parameters: obj);
            }
        }
    }

    private async void ClickedButtonEdit(object sender, EventArgs e)
    {
        if (sender is Button element)
        {
            if (element.BindingContext is FreightModel item)
            {
                Dictionary<string, object> obj = new Dictionary<string, object>
                {
                    { "SelectedFreightToEdit", item }
                };

                await _navigationService.NavigationToPageAsync<AddFreightView>(parameters: obj);
            }
        }        
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

    private async void EventFilter(object sender, EventArgs e)
    {
        await ViewModel.FilterFreights();
        BottomSheetFilter.State = BottomSheetState.Hidden;
    }

    private async void EventExport(object sender, EventArgs e)
    {
        ViewModel.IsBusy = true;

        try
        {            
            string nameFile = $"fretes{DateTime.Now.ToString("dd-MM-yy-hh-mm-ss")}.csv";            

            string path = System.IO.Path.Combine(Android.App.Application.Context.FilesDir.AbsolutePath, "/storage/emulated/0/Documents/");
        
            string filePath = System.IO.Path.Combine(path, nameFile);
            
            var utf8 = new UTF8Encoding(true);

            var freightsData = await ViewModel.GetFreightsToExport();

            if (freightsData == null) return;

            var totalFreight = freightsData.Select(x => x.FreightValue).Sum();

            using (var writer = new StreamWriter(filePath, false, utf8))
            {                
                await writer.WriteAsync($"Código #;Data;Origem;Destino;Distância (KM);Valor (R$);Observação");
               
                foreach (var freight in freightsData)
                {
                    await writer.WriteAsync($"\n# {freight.Id};" +
                                            $"{freight.TravelDate.ToShortDateString()};" +
                                            $"{freight.Origin} - {freight.OriginUf};" +
                                            $"{freight.Destination} - {freight.DestinationUf};" +
                                            $"{freight.Kilometer};" +
                                            $"{freight.FreightValue:c};" +
                                            $"{freight.Observation}");                    
                }


                await writer.WriteLineAsync();
                await writer.WriteAsync($"-;-;-;-;-;Total Valor: {totalFreight:c};-");
                await writer.WriteLineAsync();
                await writer.WriteLineAsync();
                await writer.WriteAsync($"Código #;Data;Litros (Lt);Valor (R$);Valor/Litro (R$);Despesas (R$);Observação");

                double totalLiters = 0;
                decimal totalValue = 0;
                decimal totalExpenses = 0;

                foreach (var item in freightsData)
                {
                    var supplies = await ViewModel.GetFreightSupplies(item);

                    foreach(var fuel in supplies)
                    {
                        await writer.WriteAsync($"\n# {fuel.FreightModelId};" +
                                                $"{fuel.Date.ToShortDateString()};" +
                                                $"{fuel.Liters};" +
                                                $"{fuel.AmountSpentFuel:c};" +
                                                $"{fuel.ValuePerLiter:c};" +
                                                $"{fuel.Expenses:c};" +
                                                $"{fuel.Observation}");
                        
                        totalLiters += fuel.Liters;
                        totalValue += fuel.AmountSpentFuel;
                        totalExpenses += fuel.Expenses;
                    }                    
                }
               
                await writer.WriteLineAsync();
                await writer.WriteAsync($"-;-;Total Litros: {totalLiters};Total Valor: {totalValue:c};-;Total Despesas: {totalExpenses:c};-");
                await writer.WriteLineAsync();
                await writer.WriteAsync($"Total Geral: {totalFreight - totalValue - totalExpenses:c};-;-;-;-;-;-");
            }            

            await DisplayAlert("Sucesso", "Arquivo exportado com sucesso. O arquivo foi salvo em: Documentos.", "Ok");

            BottomSheetExport.State = BottomSheetState.Hidden;

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            await DisplayAlert("Erro", "Parece que ocorreu um erro ao tentar exportar os fretes. Por favor, tente novamente.", "Ok");
        }
        finally
        {
            ViewModel.IsBusy = false;
        }
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


