namespace freight.control.maui;

public partial class App : Application
{
    public static string WhatIsThePlatform;


	public App()
	{
        CheckDevice();

        InitializeComponent();

		MainPage = new AppShell();
	}

	public void CheckDevice()
	{
        if (Device.RuntimePlatform == Device.iOS)
        {
            WhatIsThePlatform = "ios";
        }
        else if (Device.RuntimePlatform == Device.Android)
        {
            WhatIsThePlatform = "android";
        }
    }

    public static T GetResource<T>(string name)
    {
        if (App.Current.Resources.TryGetValue(name, out var resourceValue) && resourceValue is T typedResource)
        {
            return typedResource;
        }
       
        return default(T);
    }
}

