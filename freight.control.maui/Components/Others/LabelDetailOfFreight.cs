namespace freight.control.maui.Components.Others
{
    public class LabelDetailOfFreight : StackLayout
    {
        public Label ContentLabel { get; set; }

        public LabelDetailOfFreight(string title)
        {
            var stack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = 10
            };

            var titleLabel = new Label
            {
                Text = title,
                TextColor = App.GetResource<Color>("PrimaryDark"),
                FontFamily = "MontserratSemiBold",
                FontSize = 16,
                VerticalOptions = LayoutOptions.Center,
            };

            ContentLabel = new Label
            {
                TextColor = App.GetResource<Color>("PrimaryDark"),
                FontFamily = "MontserratRegular",
                FontSize = 16,
                VerticalOptions = LayoutOptions.Center
            };

            stack.Children.Add(titleLabel);
            stack.Children.Add(ContentLabel);

            Children.Add(stack);
        }
    }
}


