using DevExpress.Maui.Editors;
using freight.control.maui.Components;
using freight.control.maui.Controls.Animations;
using freight.control.maui.Controls.ControlCheckers;
using freight.control.maui.MVVM.Base.Views;
using freight.control.maui.MVVM.ViewModels;
using Microsoft.Maui.Controls.Shapes;

namespace freight.control.maui.MVVM.Views
{
    public class ToFuelView : BaseContentPage
    {
        #region Properties

        public ToFuelViewModel ViewModel = new();

        public ClickAnimation ClickAnimation = new();

        public int Calc = 0;

        #endregion

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

        private static Grid CreateMainGrid()
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
                TextColor = (Color)Application.Current.Resources["PrimaryDark"],
                Style = (Style)Application.Current.Resources["labelTitleView"],
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
                Margin = new Thickness(15, 0, 0, 0)
            };

            var stackDate = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = 5
            };
            var titleDate = new Label
            {
                Text = "Data:",
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
            contentDate.SetBinding(Label.TextProperty, nameof(ViewModel.DetailTravelDate));
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
            contentOrigin.SetBinding(Label.TextProperty, nameof(ViewModel.DetailOrigin));
            stackOrigin.Children.Add(contentOrigin);

            stack.Children.Add(stackOrigin);

            var stackDestination = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = 5
            };
            var titleDestination = new Label
            {
                Text = "Destino:",
                FontFamily = "MontserratSemiBold",
                FontSize = 14,
                TextColor = App.GetResource<Color>("PrimaryDark")
            };
            stackDestination.Children.Add(titleDestination);
            var contentDestination = new Label
            {
                FontFamily = "MontserratRegular",
                FontSize = 14,
                TextColor = App.GetResource<Color>("PrimaryDark")
            };
            contentDestination.SetBinding(Label.TextProperty, nameof(ViewModel.DetailDestination));
            stackDestination.Children.Add(contentDestination);

            stack.Children.Add(stackDestination);

            mainGrid.Add(stack, 0, 1);
        }

        private void CreateForm(Grid mainGrid)
        {
            var borderForm = new Border
            {
                Stroke = App.GetLightGrayColor(),
                Background = Colors.Transparent,
                StrokeThickness = 1,
                Margin = DeviceInfo.Platform == DevicePlatform.Android ? 10 : 20,
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

            CreateToFuelDateFieldForm(contentGridBorderForm);

            CreateFuelBoxFieldForm(contentGridBorderForm);

            CreateExpensesFieldForm(contentGridBorderForm);

            CreateObservationFieldForm(contentGridBorderForm);

            borderForm.Content = contentGridBorderForm;

            mainGrid.Add(borderForm, 0, 2);
        }

        private void CreateToFuelDateFieldForm(Grid contentGridBorderForm)
        {
            var date = new DatePickerFieldCustom();
            date.DatePicker.SetBinding(DatePicker.DateProperty, nameof(ViewModel.Date));
            date.Border.SetBinding(Border.StrokeProperty, nameof(ViewModel.StrokeDate));
            date.DatePicker.DateSelected += DatePicker_DateSelected;
            contentGridBorderForm.SetColumnSpan(date, 2);
            contentGridBorderForm.Add(date, 0, 0);
        }

        private void CreateFuelBoxFieldForm(Grid contentGridBorderForm)
        {
            var borderFuel = new Border
            {
                Stroke = App.GetLightGrayColor(),
                Background = Colors.Transparent,
                StrokeThickness = 1,
                Margin = DeviceInfo.Platform == DevicePlatform.Android ? 10 : 20,
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

            var liters = new TextEditCustom(icon: "liters_24", placeholder: "Litros", keyboard: Keyboard.Numeric);
            liters.SetBinding(TextEditBase.TextProperty, nameof(ViewModel.Liters));
            liters.SetBinding(EditBase.BorderColorProperty, nameof(ViewModel.BorderColorLiters));
            liters.SetBinding(EditBase.FocusedBorderColorProperty, nameof(ViewModel.BorderColorFocusedLiters));
            liters.TextChanged += Liters_TextChanged;
            gridFuel.Add(liters, 0, 0);

            var amountSpentFuel = new TextEditCustom(icon: "money_24", placeholder: "Valor", keyboard: Keyboard.Numeric);
            amountSpentFuel.SetBinding(TextEditBase.TextProperty, nameof(ViewModel.AmountSpentFuel));
            amountSpentFuel.SetBinding(EditBase.BorderColorProperty, nameof(ViewModel.BorderColorAmountSpentFuel));
            amountSpentFuel.SetBinding(EditBase.FocusedBorderColorProperty, nameof(ViewModel.BorderColorFocusedAmountSpentFuel));
            amountSpentFuel.TextChanged += AmountSpentFuel_TextChanged;
            gridFuel.Add(amountSpentFuel, 1, 0);

            var titleValuePerLiter = new Label
            {
                Text = "Valor do Litro:",
                FontFamily = "MontserratRegular",
                FontSize = 16,
                TextColor = App.GetResource<Color>("PrimaryDark"),
                Margin = new Thickness(10, 0, 0, 10),
            };
            gridFuel.Add(titleValuePerLiter, 0, 1);

            var contentValuePerLiter = new Label
            {
                FontFamily = "MontserratRegular",
                FontSize = 16,
                TextColor = App.GetLightGrayColor(),
                HorizontalOptions = LayoutOptions.End,
                Margin = new Thickness(0, 0, 10, 0),
            };
            contentValuePerLiter.SetBinding(Label.TextProperty, nameof(ViewModel.ValuePerLiter));
            gridFuel.Add(contentValuePerLiter, 1, 1);

            borderFuel.Content = gridFuel;

            contentGridBorderForm.SetColumnSpan(borderFuel, 2);
            contentGridBorderForm.Add(borderFuel, 0, 2);
        }

        private void CreateExpensesFieldForm(Grid contentGridBorderForm)
        {
            var expenses = new TextEditCustom(icon: "money_24", placeholder: "Despesas", keyboard: Keyboard.Numeric);
            expenses.SetBinding(TextEditBase.TextProperty, nameof(ViewModel.Expenses));
            expenses.SetBinding(EditBase.BorderColorProperty, nameof(ViewModel.BorderColorExpenses));
            expenses.SetBinding(EditBase.FocusedBorderColorProperty, nameof(ViewModel.BorderColorFocusedExpenses));
            expenses.TextChanged += Expenses_TextChanged;
            contentGridBorderForm.SetColumnSpan(expenses, 2);
            contentGridBorderForm.Add(expenses, 0, 3);
        }

        private void CreateObservationFieldForm(Grid contentGridBorderForm)
        {
            var observation = new MultilineEditCustom(icon: "comment_24", placeholder: "Observacão");
            observation.SetBinding(TextEditBase.TextProperty, nameof(ViewModel.Observation));
            contentGridBorderForm.SetColumnSpan(observation, 2);
            contentGridBorderForm.Add(observation, 0, 5);
        }

        private void CreateButtonSave(Grid mainGrid)
        {
            var button = new Button
            {
                Text = "Salvar",
                Style = (Style)Application.Current.Resources["buttonDarkPrimary"]
            };
            button.SetBinding(IsEnabledProperty, nameof(ViewModel.IsEnabledSaveButton));

            button.Clicked += SaveClicked;

            mainGrid.Add(button, 0, 3);
        }

        #endregion

        #region Events

        private async void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            var element = sender as DatePicker;

            var dateSelected = element.Date;

            if (dateSelected < ViewModel.DetailsFreight.TravelDate)
            {
                await SetBorderColorErrorToDateField();

                return;
            }

            ViewModel.StrokeDate = App.GetLightGrayColor();
        }

        private async void TapGestureRecognizer_Tapped_GoBack(object sender, TappedEventArgs e)
        {
            View element = sender as Image;

            await ClickAnimation.SetFadeOnElement(element);

            await Application.Current.MainPage.Navigation.PopAsync();
        }

        private void Liters_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(GetValueStringOfObject(sender)))
            {
                ViewModel.ValuePerLiter = Calc.ToString("c");
                SetBorderColorDefaultLitersField();
                return;
            }

            if (!CheckTheEntrys.IsValidEntry(GetValueStringOfObject(sender), CheckTheEntrys.patternLiters))
            {
                SetBorderColorErrorToLitersField();
                return;
            }

            SetBorderColorDefaultLitersField();

            ViewModel.CalculatePriceOfFuel();
        }

        private void AmountSpentFuel_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(GetValueStringOfObject(sender)))
            {
                ViewModel.ValuePerLiter = Calc.ToString("c");
                SetBorderColorDefaultAmountSpentFuelField();
                return;
            }

            if (!CheckTheEntrys.IsValidEntry(GetValueStringOfObject(sender), CheckTheEntrys.patternMoney))
            {
                SetBorderColorErrorToAmountSpentFuelField();
                return;
            }

            SetBorderColorDefaultAmountSpentFuelField();

            ViewModel.CalculatePriceOfFuel();
        }

        private void Expenses_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(GetValueStringOfObject(sender)))
            {
                SetBorderColorDefaultExpensesField();
                return;
            }

            if (!CheckTheEntrys.IsValidEntry(GetValueStringOfObject(sender), CheckTheEntrys.patternMoney))
            {
                SetBorderColorErrorToExpensesField();
                return;
            }

            SetBorderColorDefaultExpensesField();
        }

        private async void SaveClicked(object sender, EventArgs e)
        {
            if (!ValidationToFieldsRequireds())
            {
                await DisplayAlert("Atenção", "Um ou mais campos precisam de correção. Favor verificar.", "Ok");
                return;
            }

            ViewModel.OnSave();
        }

        #endregion

        #region Actions

        private bool ValidationToFieldsRequireds()
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(ViewModel.Liters))
            {
                SetBorderColorErrorToLitersField();
                isValid = false;
            }

            if (string.IsNullOrEmpty(ViewModel.AmountSpentFuel))
            {
                SetBorderColorErrorToAmountSpentFuelField();
                isValid = false;
            }

            if (ViewModel.BorderColorExpenses == App.GetRedColor())
            {
                isValid = false;
            }
            if (ViewModel.BorderColorLiters == App.GetRedColor())
            {
                isValid = false;
            }

            return isValid;
        }

        private static string GetValueStringOfObject(object sender)
        {
            var element = sender as TextEdit;
            return element.Text;
        }

        private void SetBorderColorDefaultLitersField()
        {
            ViewModel.BorderColorLiters = App.GetLightGrayColor();
            ViewModel.BorderColorFocusedLiters = App.GetGrayColor();
        }

        private void SetBorderColorDefaultAmountSpentFuelField()
        {
            ViewModel.BorderColorAmountSpentFuel = App.GetLightGrayColor();
            ViewModel.BorderColorFocusedAmountSpentFuel = App.GetGrayColor();
        }

        private void SetBorderColorDefaultExpensesField()
        {
            ViewModel.BorderColorExpenses = App.GetLightGrayColor();
            ViewModel.BorderColorFocusedExpenses = App.GetGrayColor();
        }

        private void SetBorderColorErrorToLitersField()
        {
            ViewModel.BorderColorLiters = App.GetRedColor();
            ViewModel.BorderColorFocusedLiters = App.GetRedColor();
        }

        private void SetBorderColorErrorToAmountSpentFuelField()
        {
            ViewModel.BorderColorAmountSpentFuel = App.GetRedColor();
            ViewModel.BorderColorFocusedAmountSpentFuel = App.GetRedColor();
        }

        private void SetBorderColorErrorToExpensesField()
        {
            ViewModel.BorderColorExpenses = App.GetRedColor();
            ViewModel.BorderColorFocusedExpenses = App.GetRedColor();
        }

        private async Task SetBorderColorErrorToDateField()
        {
            ViewModel.StrokeDate = App.GetRedColor();
            await DisplayAlert("Ops", "A data selecionada não pode ser menor que a data do frete.", "Ok");
        }

        #endregion
    }
}