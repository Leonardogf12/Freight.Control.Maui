using DevExpress.Maui.Editors;

namespace freight.control.maui.Components.UI
{
    public class TextEditCustom : TextEdit
    {
        public TextEditCustom(string icon = "", string placeholder = "", Keyboard keyboard = null, char maskPlaceholder = new(), string mask = null)
        {
            MaskPlaceholderChar = maskPlaceholder;
            Mask = mask;
            PlaceholderText = placeholder;
            Keyboard = keyboard;
            IconIndent = 5;
            Margin = new Thickness(10, 15, 10, 0);
            HeightRequest = 50;
            CornerRadius = 10;
            IsLabelFloating = false;
            LabelText = null;
            StartIcon = ImageSource.FromFile(icon);
            PlaceholderColor = Colors.LightGray;
            FocusedBorderColor = Colors.Gray;
            BorderColor = Colors.LightGray;
            TextColor = App.GetResource<Color>("PrimaryDark");
            CursorColor = App.GetResource<Color>("BorderGray400");
            ClearIconColor = App.GetResource<Color>("BorderGray400");
            AffixColor = App.GetResource<Color>("BorderGray400");
            IconColor = App.GetResource<Color>("ColorOfIcons");
            IconVerticalAlignment = LayoutAlignment.Center;
            TextVerticalAlignment = TextAlignment.Center;
        }
    }
}


