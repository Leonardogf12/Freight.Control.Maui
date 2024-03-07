using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using System.Threading;

namespace freight.control.maui.Services
{
    public static class ToastFailConectionService
	{        
        public static bool CheckIfConnectionIsSuccessful()
        {
            NetworkAccess access = Connectivity.Current.NetworkAccess;

            return access == NetworkAccess.Internet;
        }

        public async static void ShowToastMessageFailConnection()
        {
            CancellationTokenSource cancellationTokenSource = new();

            ToastDuration duration = ToastDuration.Long;
            var toast = Toast.Make("Verifique sua conexão com a internet", duration, 14);

            await toast.Show(cancellationTokenSource.Token);
        }
    }
}

