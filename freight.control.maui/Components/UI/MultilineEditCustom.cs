using DevExpress.Maui.Editors;
using freight.control.maui.Controls.Resources;

namespace freight.control.maui.Components.UI
{
    public class MultilineEditCustom : MultilineEdit
    {
        public MultilineEditCustom(string icon = "", string placeholder = "", int minimumHeightRequest = 50, int maximumHeigthRequest = 200, int maxCharacterCount = 200, int maxLineCount = 7)
        {
            MaxCharacterCountOverflowMode = OverflowMode.LimitInput;
            MaxCharacterCount = maxCharacterCount;
            MaxLineCount = maxLineCount;
            PlaceholderText = placeholder;
            Keyboard = Keyboard.Default;
            IconIndent = 5;
            Margin = new Thickness(10, 15, 10, 0);
            CornerRadius = 10;
            IsLabelFloating = false;
            LabelText = null;
            StartIcon = ImageSource.FromFile(icon);
            PlaceholderColor = Colors.LightGray;
            FocusedBorderColor = Colors.Gray;
            BorderColor = Colors.LightGray;
            TextColor = ControlResources.GetResource<Color>("PrimaryDark");
            CursorColor = ControlResources.GetResource<Color>("BorderGray400");
            ClearIconColor = ControlResources.GetResource<Color>("BorderGray400");
            IconColor = ControlResources.GetResource<Color>("ColorOfIcons");
            IconVerticalAlignment = LayoutAlignment.Start;
            TextVerticalAlignment = TextAlignment.Start;
            FlowDirection = FlowDirection.LeftToRight;
            MinimumHeightRequest = minimumHeightRequest;
            MaximumHeightRequest = maximumHeigthRequest;
        }
    }
}


