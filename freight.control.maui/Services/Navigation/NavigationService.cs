namespace freight.control.maui.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        public bool IsBrowsing = false;

        public async Task NavigationToPageAsync<T>(Dictionary<string, object> parameters = null,
                                             View view = null, string barsNav = "") where T : IView
        {
            if (IsBrowsing) return;

            IsBrowsing = true;

            var typeView = typeof(T);

            if (parameters != null)
            {
                await Shell.Current.GoToAsync($"{typeView.Name}", parameters);
            }
            else if (!string.IsNullOrEmpty(barsNav))
            {
                await Shell.Current.GoToAsync($"{barsNav}{typeView.Name}");
            }
            else
            {
                await Shell.Current.GoToAsync($"{typeView.Name}");
            }

            IsBrowsing = false;
        }
    }
}



