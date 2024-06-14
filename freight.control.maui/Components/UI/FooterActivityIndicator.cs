namespace freight.control.maui.Components.UI
{
    public class FooterActivityIndicator : ActivityIndicator
	{
		public FooterActivityIndicator()
		{           
            Color = App.GetResource<Color>("PrimaryDark");
            IsRunning = true;
            HeightRequest = 40;
            WidthRequest = 40;
            HorizontalOptions = LayoutOptions.Center;           
        }      
	}
}

