namespace freight.control.maui.Controls.Resources
{
    public static class ControlResources
	{
        public static T GetResource<T>(string name)
        {
            if (App.Current.Resources.TryGetValue(name, out var resourceValue) && resourceValue is T typedResource)
            {
                return typedResource;
            }

            return default;
        }
    }
}

