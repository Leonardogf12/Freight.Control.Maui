using freight.control.maui.MVVM.Views;

namespace freight.control.maui;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(FreightView), typeof(FreightView));
        Routing.RegisterRoute(nameof(AddFreightView), typeof(AddFreightView));
        Routing.RegisterRoute(nameof(DetailFreightView), typeof(DetailFreightView));
        Routing.RegisterRoute(nameof(ToFuelView), typeof(ToFuelView));
    }
}

