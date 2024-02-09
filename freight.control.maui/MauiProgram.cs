using DotNet.Meteor.HotReload.Plugin;
using freight.control.maui.MVVM.ViewModels;
using freight.control.maui.MVVM.Views;
using Microsoft.Extensions.Logging;

namespace freight.control.maui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
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

#if DEBUG
		builder.Logging.AddDebug();
#endif

		builder.Services.AddTransient<FreightView>();
        builder.Services.AddTransient<AddFreightView>();
        builder.Services.AddTransient<DetailFreightView>();

        builder.Services.AddTransient<FreightViewModel>();
        builder.Services.AddTransient<AddFreightViewModel>();
        builder.Services.AddTransient<DetailFreightViewModel>();


        return builder.Build();
	}
}

