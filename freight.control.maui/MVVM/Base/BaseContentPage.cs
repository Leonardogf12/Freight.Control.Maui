using System.ComponentModel;
using CommunityToolkit.Maui.Views;
using freight.control.maui.MVVM.Base.ViewModels;

namespace freight.control.maui.MVVM.Base.Views;

public class BaseContentPage : ContentPage
{    
	public BaseContentPage()
	{
        Shell.SetNavBarIsVisible(this, false);
		
        Content = new Grid
		{			
		};
	}

    public void CreateLoadingPopupView<TViewModel>(Page page, TViewModel viewModel) where TViewModel : INotifyPropertyChanged
    {
        viewModel.PropertyChanged += (s, a) =>
        {
            var vm = s as BaseViewModel;
            
            if (a.PropertyName == "IsBusy")
            {
                MainThread.BeginInvokeOnMainThread(async () => {
                   
                    if (vm.IsBusy)
                    {
                        if(App.PopupLoading == null) 
                        {
                            App.PopupLoading = new();
                        }

                        await page.ShowPopupAsync(App.PopupLoading);                                            
                    }
                    else
                    {
                        if(App.PopupLoading == null) return;

                        await App.PopupLoading.CloseAsync();
                  
                        App.PopupLoading = null;                        
                    }                    
                });
            }
        };       
    }

}
