namespace freight.control.maui.MVVM.Base.Views;

public class BaseContentPage : ContentPage
{
	public BaseContentPage()
	{
        Shell.SetNavBarIsVisible(this, false);

        Content = new Grid();
	}   
}
