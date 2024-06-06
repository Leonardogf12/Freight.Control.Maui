using Microcharts;
using SkiaSharp;

namespace freight.control.maui.Components.Chart;

public static class ChartStyleCustom
{
	public static LineChart GetLineChartCustom(ChartEntry[] entries)
	{
        return new LineChart
        {
            Entries = entries,
            IsAnimated = true,
            LineMode = LineMode.Straight,
            PointMode = PointMode.Circle,
            LabelTextSize = 35,
            PointSize = 20,
            MaxValue = 100,
            MinValue = 0,
            Margin = 50,
            LabelOrientation = Orientation.Horizontal,
            ValueLabelOrientation = Orientation.Horizontal,
            BackgroundColor = SKColor.Parse("#333850"),
            LabelColor = SKColor.Parse("#FFFFFF"),
            Typeface = SKTypeface.Default,
        };        
	}   
}

