using DevExpress.Maui.Editors;

namespace freight.control.maui.Components;

public class ComboboxEditCustom : ComboBoxEdit
{
	public ComboboxEditCustom(string icon = "")
	{
        HeightRequest = 50;
        Keyboard = Keyboard.Default;
        Margin = new Thickness(10, 0, 5, 0); // Margin = new Thickness(0, 15, 10, 0),
        CornerRadius = 10;
        IsLabelFloating = false;         
        PlaceholderColor = Colors.LightGray;
        IconIndent = 5;
        StartIcon = ImageSource.FromFile(icon);
        FocusedBorderColor = Colors.Gray;
        BorderColor = Colors.LightGray;
        TextColor = App.GetResource<Color>("PrimaryDark");
        CursorColor = App.GetResource<Color>("BorderGray400");
        ClearIconColor = App.GetResource<Color>("BorderGray400");
        IconColor = App.GetResource<Color>("ColorOfIcons");
        IconVerticalAlignment = LayoutAlignment.Center;
        TextVerticalAlignment = TextAlignment.Center;
        IsFilterEnabled = false;
        DropDownBackgroundColor = App.GetResource<Color>("TertiaryGreen");
        DropDownItemTextColor = App.GetResource<Color>("PrimaryDark");
    }
}
