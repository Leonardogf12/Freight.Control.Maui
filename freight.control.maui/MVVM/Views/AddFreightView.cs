using DevExpress.Maui.Editors;
using freight.control.maui.Components;
using freight.control.maui.Controls.Animations;
using freight.control.maui.Controls.ControlCheckers;
using freight.control.maui.MVVM.Base.Views;
using freight.control.maui.MVVM.ViewModels;
using Microsoft.Maui.Controls.Shapes;

namespace freight.control.maui.MVVM.Views
{
    public class AddFreightView : BaseContentPage
    {
        #region Properties

        public AddFreightViewModel ViewModel = new();

        public ClickAnimation ClickAnimation = new();

        public ComboboxEditCustom OriginUfComboboxEditCustom;

        public ComboboxEditCustom DestinationUfComboboxEditCustom;

        #endregion

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

            CreateHeader(mainGrid);

            CreateForm(mainGrid);

            CreateSaveButton(mainGrid);

            return mainGrid;
        }

        private static Grid CreateMainGrid()
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

        private void CreateHeader(Grid mainGrid)
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
                TextColor = App.GetResource<Color>("PrimaryDark"), //(Color)Application.Current.Resources["PrimaryDark"],
                Style = App.GetResource<Style>("labelTitleView") //(Style)Application.Current.Resources["labelTitleView"],
            };
            labelTitle.SetBinding(Label.TextProperty, nameof(ViewModel.TextTitlePage));
            contentGridStackTitle.Add(labelTitle, 1, 0);

            stackTitle.Children.Add(contentGridStackTitle);

            mainGrid.Children.Add(stackTitle);
        }

        private void CreateForm(Grid mainGrid)
        {
            var scroll = new ScrollView
            {
                Orientation = ScrollOrientation.Vertical,
                VerticalScrollBarVisibility = ScrollBarVisibility.Always
            };

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

            scroll.Content = borderForm;

            mainGrid.Add(scroll, 0, 1);
        }

        private static void CreateTravelDateFieldForm(Grid contentGridBorderForm)
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

            OriginUfComboboxEditCustom = new ComboboxEditCustom(icon: "uf_24", labelText: "Uf")
            {
                Margin = new Thickness(10, 0, 5, 0),
            };
            OriginUfComboboxEditCustom.SetBinding(ItemsEditBase.ItemsSourceProperty, nameof(ViewModel.OriginUfCollection));
            OriginUfComboboxEditCustom.SetBinding(ComboBoxEdit.SelectedItemProperty, nameof(ViewModel.SelectedItemOriginUf), BindingMode.TwoWay);
            OriginUfComboboxEditCustom.SetBinding(EditBase.BorderColorProperty, nameof(ViewModel.BorderColorOriginUf));
            OriginUfComboboxEditCustom.SetBinding(EditBase.FocusedBorderColorProperty, nameof(ViewModel.BorderColorFocusedOriginUf));
            OriginUfComboboxEditCustom.SelectionChanged += OriginUf_SelectionChanged;
            grid.SetColumnSpan(OriginUfComboboxEditCustom, 2);
            grid.Add(OriginUfComboboxEditCustom, 0, 1);

            var origin = new ComboboxEditCustom(icon: "local_24", labelText: "Origem")
            {
                Margin = new Thickness(0, 0, 10, 0),
            };
            origin.SetBinding(ItemsEditBase.ItemsSourceProperty, nameof(ViewModel.OriginCollection));
            origin.SetBinding(ComboBoxEdit.SelectedItemProperty, nameof(ViewModel.SelectedItemOrigin), BindingMode.TwoWay);
            origin.SetBinding(EditBase.BorderColorProperty, nameof(ViewModel.BorderColorOrigin));
            origin.SetBinding(EditBase.FocusedBorderColorProperty, nameof(ViewModel.BorderColorFocusedOrigin));
            origin.SelectionChanged += Origin_SelectionChanged;

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

            DestinationUfComboboxEditCustom = new ComboboxEditCustom(icon: "uf_24", labelText: "Uf")
            {
                Margin = new Thickness(10, 0, 5, 0),
            };
            DestinationUfComboboxEditCustom.SetBinding(ItemsEditBase.ItemsSourceProperty, nameof(ViewModel.DestinationUfCollection));
            DestinationUfComboboxEditCustom.SetBinding(ComboBoxEdit.SelectedItemProperty, nameof(ViewModel.SelectedItemDestinationUf), BindingMode.TwoWay);
            DestinationUfComboboxEditCustom.SetBinding(EditBase.BorderColorProperty, nameof(ViewModel.BorderColorDestinationUf));
            DestinationUfComboboxEditCustom.SetBinding(EditBase.FocusedBorderColorProperty, nameof(ViewModel.BorderColorFocusedDestinationUf));
            DestinationUfComboboxEditCustom.SelectionChanged += DestinationUf_SelectionChanged;
            grid.SetColumnSpan(DestinationUfComboboxEditCustom, 2);
            grid.Add(DestinationUfComboboxEditCustom, 0, 1);

            var destination = new ComboboxEditCustom(icon: "local_24", labelText: "Destino")
            {
                Margin = new Thickness(0, 0, 10, 0),
            };
            destination.SetBinding(ItemsEditBase.ItemsSourceProperty, nameof(ViewModel.DestinationCollection));
            destination.SetBinding(ComboBoxEdit.SelectedItemProperty, nameof(ViewModel.SelectedItemDestination));
            destination.SetBinding(EditBase.BorderColorProperty, nameof(ViewModel.BorderColorDestination));
            destination.SetBinding(EditBase.FocusedBorderColorProperty, nameof(ViewModel.BorderColorFocusedDestination));
            destination.SelectionChanged += Destination_SelectionChanged;
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
            contentGridBorderForm.Add(observation, 0, 4);
        }

        private void CreateSaveButton(Grid mainGrid)
        {
            var button = new Button
            {
                Text = "Salvar",
                Style = (Style)Application.Current.Resources["buttonDarkPrimary"]
            };

            button.Clicked += SaveClicked;

            mainGrid.Add(button, 0, 2);
        }

        #endregion

        #region Events

        private void OriginUf_SelectionChanged(object sender, EventArgs e)
        {
            if (sender is ComboBoxEdit element)
            {
                if (element.SelectedItem is string uf)
                {
                    ViewModel.SelectedItemOriginUf = uf;
                    ViewModel.ChangedItemOriginUf(uf);
                    SetBorderColorDefaultForDropdownOriginUf();
                    OriginUfComboboxEditCustom.Unfocus();
                }
            }
        }

        private void Origin_SelectionChanged(object sender, EventArgs e)
        {
            if (sender is ComboBoxEdit element)
            {
                if (element.SelectedItem is string)
                {
                    SetBorderColorDefaultForDropdownOrigin();
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
                    SetBorderColorDefaultForDropdownDestinationUf();
                    DestinationUfComboboxEditCustom.Unfocus();
                }
            }
        }

        private void Destination_SelectionChanged(object sender, EventArgs e)
        {
            if (sender is ComboBoxEdit element)
            {
                if (element.SelectedItem is string)
                {
                    SetBorderColorDefaultForDropdownDestination();
                }
            }
        }

        private void Km_TextChanged(object sender, EventArgs e)
        {
            var element = sender as TextEdit;

            var text = element.Text;

            SetBorderColorToElementKmTextField(text);
        }

        private void FreigthField_TextChanged(object sender, EventArgs e)
        {
            var element = sender as TextEdit;

            var text = element.Text;

            SetBorderColorToElementFreightValueTextField(text);
        }

        private async void SaveClicked(object sender, EventArgs e)
        {
            if (!ValidationOfFieldsOriginAndDestination())
            {
                await DisplayAlert("Atenção", "Um ou mais campos precisam de correção. Favor verificar.", "Ok");
                return;
            }

            if (!CheckIfIsAllValidToSave())
            {
                await DisplayAlert("Atenção", "Um ou mais campos precisam de correção. Favor verificar.", "Ok");
                return;
            }

            ViewModel.OnSave();
        }

        private async void TapGestureRecognizer_Tapped_GoBack(object sender, TappedEventArgs e)
        {
            View element = sender as Image;

            await ClickAnimation.SetFadeOnElement(element);

            await Application.Current.MainPage.Navigation.PopAsync();
        }

        #endregion

        #region Actions

        private void SetBorderColorDefaultKmField()
        {
            ViewModel.BorderColorKm = App.GetLightGrayColor();
            ViewModel.BorderColorFocusedKm = App.GetGrayColor();
        }

        private void SetBorderColorDefaultFreightField()
        {
            ViewModel.BorderColorFreightValue = App.GetLightGrayColor();
            ViewModel.BorderColorFocusedFreightValue = App.GetGrayColor();
        }

        private void SetBorderColorToElementKmTextField(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                SetBorderColorDefaultKmField();
                ViewModel.IsValidToSave = true;
                return;
            }

            if (!CheckTheEntrys.IsValidEntry(text, CheckTheEntrys.patternKilometer))
            {
                ViewModel.BorderColorKm = App.GetRedColor();
                ViewModel.BorderColorFocusedKm = App.GetRedColor();
                ViewModel.IsValidToSave = false;
                return;
            }

            SetBorderColorDefaultKmField();

            ViewModel.IsValidToSave = true;
        }

        private void SetBorderColorToElementFreightValueTextField(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                SetBorderColorDefaultFreightField();
                ViewModel.IsValidToSave = true;
                return;
            }

            if (!CheckTheEntrys.IsValidEntry(text, CheckTheEntrys.patternMoney))
            {
                ViewModel.BorderColorFreightValue = App.GetRedColor();
                ViewModel.BorderColorFocusedFreightValue = App.GetRedColor();
                ViewModel.IsValidToSave = false;

                return;
            }

            SetBorderColorDefaultFreightField();
            ViewModel.IsValidToSave = true;
        }

        #region Origin

        private void SetBorderColorForDropdownOriginUf()
        {
            ViewModel.BorderColorOriginUf = App.GetRedColor();
            ViewModel.BorderColorFocusedOriginUf = App.GetRedColor();
        }

        private void SetBorderColorForDropdownOrigin()
        {
            ViewModel.BorderColorOrigin = App.GetRedColor();
            ViewModel.BorderColorFocusedOrigin = App.GetRedColor();
        }

        private void SetBorderColorDefaultForDropdownOriginUf()
        {
            ViewModel.BorderColorOriginUf = App.GetLightGrayColor();
            ViewModel.BorderColorFocusedOriginUf = App.GetGrayColor();
        }

        private void SetBorderColorDefaultForDropdownOrigin()
        {
            ViewModel.BorderColorOrigin = App.GetLightGrayColor();
            ViewModel.BorderColorFocusedOrigin = App.GetGrayColor();
        }

        #endregion

        #region Destination

        private void SetBorderColorDefaultForDropdownDestinationUf()
        {
            ViewModel.BorderColorDestinationUf = App.GetLightGrayColor();
            ViewModel.BorderColorFocusedDestinationUf = App.GetGrayColor();
        }

        private void SetBorderColorDefaultForDropdownDestination()
        {
            ViewModel.BorderColorDestination = App.GetLightGrayColor();
            ViewModel.BorderColorFocusedDestination = App.GetGrayColor();
        }

        private void SetBorderColorForDropdownDestinationUf()
        {
            ViewModel.BorderColorDestinationUf = App.GetRedColor();
            ViewModel.BorderColorFocusedDestinationUf = App.GetRedColor();
        }

        private void SetBorderColorForDropdownDestination()
        {
            ViewModel.BorderColorDestination = App.GetRedColor();
            ViewModel.BorderColorFocusedDestination = App.GetRedColor();
        }

        #endregion

        private bool CheckIfIsAllValidToSave()
        {
            return ViewModel.IsValidToSave;
        }

        private bool ValidationOfFieldsOriginAndDestination()
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(ViewModel.SelectedItemOriginUf))
            {
                SetBorderColorForDropdownOriginUf();
                isValid = false;
            }
            else
            {
                SetBorderColorDefaultForDropdownOriginUf();
            }

            if (string.IsNullOrEmpty(ViewModel.SelectedItemOrigin))
            {
                SetBorderColorForDropdownOrigin();
                isValid = false;
            }
            else
            {
                SetBorderColorDefaultForDropdownOrigin();
            }

            if (string.IsNullOrEmpty(ViewModel.SelectedItemDestinationUf))
            {
                SetBorderColorForDropdownDestinationUf();
                isValid = false;
            }
            else
            {
                SetBorderColorDefaultForDropdownDestinationUf();
            }

            if (string.IsNullOrEmpty(ViewModel.SelectedItemDestination))
            {
                SetBorderColorForDropdownDestination();
                isValid = false;
            }
            else
            {
                SetBorderColorDefaultForDropdownDestination();
            }

            return isValid;
        }
      
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.OnAppearing();
        }

        #endregion
    }
}
