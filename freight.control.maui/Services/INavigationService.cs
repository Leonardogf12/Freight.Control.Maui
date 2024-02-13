namespace freight.control.maui.Services;

public interface INavigationService
{
    Task NavigationToPageAsync<T>(Dictionary<string, object> parameters = null, View view = null) where T : IView;    
}
