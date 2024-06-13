using DevExpress.Maui.Controls;
using freight.control.maui.Components;
using freight.control.maui.Controls.Animations;
using freight.control.maui.Controls.Excel;
using freight.control.maui.Models;
using freight.control.maui.MVVM.Base.Views;
using freight.control.maui.MVVM.Models;
using freight.control.maui.MVVM.ViewModels;
using freight.control.maui.Services.Navigation;
using Microsoft.Maui.Controls.Shapes;
using Color = Microsoft.Maui.Graphics.Color;
using Image = Microsoft.Maui.Controls.Image;
using Style = Microsoft.Maui.Controls.Style;

namespace freight.control.maui.MVVM.Views
{
    public class FreightView : BaseContentPage
    {
        #region Properties

        private readonly INavigationService _navigationService;

        private readonly IExportDataToExcel _exportDataToExcel;

        public FreightViewModel ViewModel = new();

        readonly ClickAnimation ClickAnimation = new();

        #endregion

        public FreightView(INavigationService navigationService, IExportDataToExcel exportDataToExcel)
        {
            _navigationService = navigationService;
            _exportDataToExcel = exportDataToExcel;

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

        private static Grid CreateMainGrid()
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
                Text = "Fretes",
                Style = App.GetResource<Style>("labelTitleView"),
            };
            contentGridStack.Add(title, 1, 0);

            var collectionButtons = CreateHeaderButtonsCollection();
            contentGridStack.Add(collectionButtons, 0, 1);
            contentGridStack.SetColumnSpan(collectionButtons, 3);

            stack.Children.Add(contentGridStack);

            mainGrid.Children.Add(stack);
        }

        private CollectionView CreateHeaderButtonsCollection()
        {
            var collection = new CollectionView
            {
                ItemsLayout = new LinearItemsLayout(ItemsLayoutOrientation.Horizontal)
                {
                    ItemSpacing = 10
                },
                VerticalOptions = LayoutOptions.Center,
            };
            collection.SetBinding(ItemsView.ItemsSourceProperty, nameof(ViewModel.HeaderButtonFreightCollection));
            collection.ItemTemplate = new DataTemplate(CreateDataTemplateHeaderButton);

            return collection;
        }

        private View CreateDataTemplateHeaderButton()
        {
            var button = new Button
            {
                Style = App.GetResource<Style>("buttonDarkLight"),
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = 120
            };
            button.SetBinding(Button.TextProperty, nameof(HeaderButtonFreight.Text));
            button.SetBinding(Button.CommandProperty, nameof(HeaderButtonFreight.Command));

            return button;
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
            collection.SetBinding(ItemsView.ItemsSourceProperty, nameof(FreightViewModel.FreightCollection));

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
                Margin = DeviceInfo.Platform == DevicePlatform.Android ? 10 : 20,
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

        private static void CreateLabelDate(Grid contentGridBorder)
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

        private static void CreateStackOrigin(Grid contentGridBorder)
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

            var labelOrigin = new Label
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

        private static void CreateStackDestination(Grid contentGridBorder)
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

        private static void CreateStackKilometer(Grid contentGridBorder)
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
                Margin = new Thickness(10, 0, 10, 0),
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

            contentGridBorder.SetColumnSpan(stack, 4);
            contentGridBorder.Add(stack, 0, 4);
        }

        private void CreateLabelAddNewFreights(Grid contentGridBorder)
        {
            var label = new Label
            {
                Text = "Clique em Novo para adicionar um frete.",
                FontSize = 14,
                FontFamily = "MontserratRegular",
                TextColor = Colors.Gray,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            label.SetBinding(IsVisibleProperty, nameof(ViewModel.IsVisibleTextAddNewFreight));

            contentGridBorder.SetRowSpan(label, 3);
            contentGridBorder.Children.Add(label);
        }

        private void CreateBottomSheetFilter(Grid mainGrid)
        {
            var bottomSheetFilter = new BottomSheetFilterDateCustom(title: "Filtrar", textButton: "Confirmar", EventFilter);
            bottomSheetFilter.SetBinding(BottomSheet.StateProperty, nameof(ViewModel.BottomSheetFilterState));
            bottomSheetFilter.DatePickerFieldCustomInitialDate.DatePicker.SetBinding(DatePicker.DateProperty, nameof(ViewModel.InitialDate));
            bottomSheetFilter.DatePickerFieldCustomFinalDate.DatePicker.SetBinding(DatePicker.DateProperty, nameof(ViewModel.FinalDate));

            mainGrid.Add(bottomSheetFilter, 0, 1);
        }

        private void CreateBottomSheetExport(Grid mainGrid)
        {
            var bottomSheetExport = new BottomSheetFilterDateCustom(title: "Exportar", textButton: "Exportar", EventExport);
            bottomSheetExport.SetBinding(BottomSheet.StateProperty, nameof(ViewModel.BottomSheetExportState));
            bottomSheetExport.DatePickerFieldCustomInitialDate.DatePicker.SetBinding(DatePicker.DateProperty, nameof(ViewModel.InitialDate));
            bottomSheetExport.DatePickerFieldCustomFinalDate.DatePicker.SetBinding(DatePicker.DateProperty, nameof(ViewModel.FinalDate));

            mainGrid.Add(bottomSheetExport, 0, 1);
        }

        #endregion

        #region Events

        private async void TapGestureRecognizer_Tapped_GoBack(object sender, TappedEventArgs e)
        {
            View element = sender as Image;

            await ClickAnimation.SetFadeOnElement(element);

            await Application.Current.MainPage.Navigation.PopAsync();
        }

        private async void ClickedButtonNew(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AddFreightView());
        }

        private void ClickedButtonFilter(object sender, EventArgs e)
        {
            ViewModel.BottomSheetFilterState = BottomSheetState.HalfExpanded;
        }

        private void ClickedButtonExport(object sender, EventArgs e)
        {
            ViewModel.BottomSheetExportState = BottomSheetState.HalfExpanded;
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
                    Dictionary<string, object> obj = new()
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
                    Dictionary<string, object> obj = new()
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
                    Dictionary<string, object> obj = new()
                    {
                        { "SelectedFreightToEdit", item }
                    };

                    await _navigationService.NavigationToPageAsync<AddFreightView>(parameters: obj);
                }
            }
        }

        private static Button CreateBaseButton(string text, string style, EventHandler clicked)
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
            ViewModel.BottomSheetFilterState = BottomSheetState.Hidden;
        }

        private async void EventExport(object sender, EventArgs e)
        {
            ViewModel.IsBusy = true;

            try
            {
                await _exportDataToExcel.ExportData(await ViewModel.GetFreightsToExport());

                ViewModel.BottomSheetExportState = BottomSheetState.Hidden;
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
}
