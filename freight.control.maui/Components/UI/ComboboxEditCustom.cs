using DevExpress.Maui.Editors;
using freight.control.maui.Controls.Resources;

namespace freight.control.maui.Components.UI
{
    public class ComboboxEditCustom : ComboBoxEdit
    {
        public ComboboxEditCustom(string icon = "", string labelText = "")
        {
            LabelText = labelText;
            LabelColor = Colors.LightGray;
            FocusedLabelColor = Colors.Gray;
            IsLabelFloating = true;
            HeightRequest = 60;
            Keyboard = Keyboard.Default;
            Margin = new Thickness(10, 0, 5, 0);
            CornerRadius = 10;
            IconIndent = 5;
            StartIcon = ImageSource.FromFile(icon);
            FocusedBorderColor = Colors.Gray;
            BorderColor = Colors.LightGray;
            TextColor = ControlResources.GetResource<Color>("PrimaryDark");
            CursorColor = ControlResources.GetResource<Color>("BorderGray400");
            ClearIconColor = ControlResources.GetResource<Color>("BorderGray400");
            IconColor = ControlResources.GetResource<Color>("ColorOfIcons");
            IconVerticalAlignment = LayoutAlignment.Center;
            TextVerticalAlignment = TextAlignment.Center;
            IsFilterEnabled = false;
            DropDownBackgroundColor = ControlResources.GetResource<Color>("TertiaryGreen");
            DropDownItemTextColor = ControlResources.GetResource<Color>("PrimaryDark");
        }
    }
}


