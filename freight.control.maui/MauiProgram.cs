using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Storage;
using DevExpress.Maui;
using DotNet.Meteor.HotReload.Plugin;
using freight.control.maui.Controls;
using freight.control.maui.MVVM.ViewModels;
using freight.control.maui.MVVM.Views;
using freight.control.maui.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace freight.control.maui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseSkiaSharp()
            .UseDevExpress()
            .UseMauiCommunityToolkit()
#if DEBUG
            .EnableHotReload()
#endif
			.ConfigureFonts(fonts =>
            {
                fonts.AddFont("Montserrat-Regular.ttf", "MontserratRegular");
                fonts.AddFont("Montserrat-Bold.ttf", "MontserratBold");
                fonts.AddFont("Montserrat-SemiBold.ttf", "MontserratSemiBold");
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services.AddTransient<FreightView>();
        builder.Services.AddTransient<AddFreightView>();
        builder.Services.AddTransient<DetailFreightView>();
        builder.Services.AddTransient<ToFuelView>();
        builder.Services.AddTransient<RegisterView>();


        builder.Services.AddTransient<FreightViewModel>();
        builder.Services.AddTransient<AddFreightViewModel>();
        builder.Services.AddTransient<DetailFreightViewModel>();
        builder.Services.AddTransient<ToFuelViewModel>();

        builder.Services.AddSingleton<INavigationService, NavigationService>();
        builder.Services.AddSingleton<IFileSaver>(FileSaver.Default);
        builder.Services.AddSingleton<IExportDataToExcel, ExportDataToExcel>();


#if DEBUG
        builder.Logging.AddDebug();
#endif       
       
        return builder.Build();
	}
}

