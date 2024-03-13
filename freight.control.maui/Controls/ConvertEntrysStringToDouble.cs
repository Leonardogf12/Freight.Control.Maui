using System.Globalization;

namespace freight.control.maui.Controls
{
    public static class ConvertEntrysStringToDouble
	{
        public static Task<double> ConvertValue(string valueStr)
        {
            double convertedValue = 0;

            CultureInfo cultureInfo = CultureInfo.InvariantCulture;

            if (double.TryParse(valueStr, NumberStyles.Number, cultureInfo, out convertedValue))
            {
                return Task.FromResult(convertedValue);
            }

            return Task.FromResult(convertedValue);
        }
    }
}

