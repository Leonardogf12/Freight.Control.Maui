using System;
using System.IO;
using freight.control.maui.Components.Popups;
using freight.control.maui.Data;
using Microsoft.Maui.Controls;
using SkiaSharp.Extended.UI.Controls;

namespace freight.control.maui;

public partial class App : Application
{
    public static string WhatIsThePlatform;

    public static SKLottieView SKLottieViewIsBusy { get; set; }

    public static PopupLoadingView PopupLoading = new();

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

    #region DB

    private static DbApp _dbApp;
    public static DbApp DbApp
    {
        get
        {
            if(_dbApp == null)
            {
                _dbApp = new DbApp(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "confretedata.db3"));
            }

            return _dbApp;
        }
    }

    public const string dbPath = "/data/user/0/com.companyname.freight.control.maui/files/confretedata.db3";

    #endregion
}

