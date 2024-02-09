using System.Text.RegularExpressions;

namespace freight.control.maui.Controls.ControlCheckers;

public static class CheckTheEntrys
{
	public static string patternDouble = @"^[+-]?\d*\.?\d+([eE][+-]?\d+)?$";

    public static bool IsValidDouble(string input)
    {
        return Regex.IsMatch(input, patternDouble);
    }
}
