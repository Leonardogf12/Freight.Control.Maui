using System.Text.RegularExpressions;

namespace freight.control.maui.Controls.ControlCheckers;

public static class CheckTheEntrys
{
    public static string patternKilometer = @"^[1-9][0-9]*(\.[0-9]{1,2})?$";
    public static string patternMoney = @"^\d+(\.\d{1,2})?$";
    public static string patternLiters= @"^[0-9]{1,4}$";
    
    public static bool IsValidEntry(string input, string pattern)
    {
        return Regex.IsMatch(input, pattern);
    }
}
