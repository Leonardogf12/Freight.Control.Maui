using freight.control.maui.Components.Popups;
using freight.control.maui.Constants;
using freight.control.maui.Controls;
using freight.control.maui.Data;
using freight.control.maui.MVVM.Views;
using SkiaSharp.Extended.UI.Controls;

namespace freight.control.maui
{
    public partial class App : Application
    {
        #region Properties

        private static string whatIsThePlatform;

        public static string WhatIsThePlatform { get => whatIsThePlatform; set => whatIsThePlatform = value; }

        private static PopupLoadingView popupLoading = new();

        public static PopupLoadingView PopupLoading { get => popupLoading; set => popupLoading = value; }

        public static SKLottieView SKLottieViewIsBusy { get; set; }

        public static string UserLocalIdLogged = string.Empty;

        #endregion

        public App()
        {
            CheckDevice();

            SetDatabasePathDevice();

            InitializeComponent();

            MainPage = new AppShell();

            CheckUserHasLogged();
        }

        public static void CheckDevice()
        {
            if (DeviceInfo.Platform == DevicePlatform.iOS)
            {
                WhatIsThePlatform = "ios";
            }
            else if (DeviceInfo.Platform == DevicePlatform.Android)
            {
                WhatIsThePlatform = "android";
            }
        }

        public static void SetLocalIdByUserLogged()
        {
            UserLocalIdLogged = ControlPreferences.GetKeyOfPreferences(StringConstants.firebaseUserLocalIdKey);
        }

        private static async void CheckUserHasLogged()
        {
            var value = ControlPreferences.GetKeyOfPreferences(StringConstants.firebaseAuthTokenKey);

            if (string.IsNullOrEmpty(value)) return;

            SetLocalIdByUserLogged();

            await Shell.Current.GoToAsync("//home");          
        }

        #region Style - Colors

        public static Color GetRedColor() => Colors.Red;

        public static Color GetLightGrayColor() => Colors.LightGray;

        public static Color GetGrayColor() => Colors.Gray;

        #endregion

        #region DB

        private static DbApp _dbApp;
        public static DbApp DbApp
        {
#if ANDROID

            get
            {
                if (_dbApp == null)
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
}



