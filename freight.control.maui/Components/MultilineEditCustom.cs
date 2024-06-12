using DevExpress.Maui.Editors;

namespace freight.control.maui.Components
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
            TextColor = App.GetResource<Color>("PrimaryDark");
            CursorColor = App.GetResource<Color>("BorderGray400");
            ClearIconColor = App.GetResource<Color>("BorderGray400");
            IconColor = App.GetResource<Color>("ColorOfIcons");
            IconVerticalAlignment = LayoutAlignment.Start;
            TextVerticalAlignment = TextAlignment.Start;
            FlowDirection = FlowDirection.LeftToRight;
            MinimumHeightRequest = minimumHeightRequest;
            MaximumHeightRequest = maximumHeigthRequest;
        }
    }
}


