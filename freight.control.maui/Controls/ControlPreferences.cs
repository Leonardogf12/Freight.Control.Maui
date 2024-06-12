using Newtonsoft.Json;

namespace freight.control.maui.Controls
{
    public static class ControlPreferences
	{
        public static void AddKeyOnPreferences(string key, object contentOfObject)
        {
            var serializeContent = JsonConvert.SerializeObject(contentOfObject);

            Preferences.Set(key, serializeContent);
        }

        public static void RemoveKeyFromPreferences(string key)
        {
            if (Preferences.ContainsKey(key))
            {
                Preferences.Remove(key);
            }
        }

        public static string GetKeyOfPreferences(string key)
        {
            return Preferences.Get(key, "");
        }
    }
}

