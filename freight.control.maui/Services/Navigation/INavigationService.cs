namespace freight.control.maui.Services.Navigation;

public interface INavigationService
{
    Task NavigationToPageAsync<T>(Dictionary<string, object> parameters = null, View view = null, string barsNav = "") where T : IView;    
}
