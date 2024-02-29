using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace freight.control.maui.Services;

public interface INavigationService
{
    Task NavigationToPageAsync<T>(Dictionary<string, object> parameters = null, View view = null) where T : IView;    
}
