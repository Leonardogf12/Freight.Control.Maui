using freight.control.maui.Components.Popups;
using freight.control.maui.Constants;
using freight.control.maui.Controls;
using freight.control.maui.Data;
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

        SetDatabasePathDevice();
      
        InitializeComponent();
       
        MainPage = new AppShell();

        CheckUserHasLogged();
    }

    private async void CheckUserHasLogged()
    {       
        var value = ControlPreferences.GetKeyOfPreferences(StringConstants.firebaseAuthTokenKey);

        if (string.IsNullOrEmpty(value)) return;

        await Shell.Current.GoToAsync("//home");                         
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
    #if ANDROID
        
        get
        {
            if(_dbApp == null)
            {
                _dbApp = new DbApp(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), StringConstants.DatabaseName));
            }

            return _dbApp;
        }

    #else

        get
        {
            if (_dbApp == null)
            {
                _dbApp = new DbApp(Path.Combine(FileSystem.AppDataDirectory, StringConstants.DatabaseName));
            }

            return _dbApp;
        }

    #endif
    }

    public static string DbPath = string.Empty;

    public void SetDatabasePathDevice()
    {

#if ANDROID
        DbPath = "/data/user/0/com.companyname.freight.control.maui/files/confretedata.db3";


#else

        string documentsPath = FileSystem.AppDataDirectory;
        string databaseName = "nomedodatabase.db3";
        DbPath = databaseName;

#endif
       
    }

    #endregion
}

