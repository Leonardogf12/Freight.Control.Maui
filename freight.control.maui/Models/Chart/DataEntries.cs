using SkiaSharp;

namespace freight.control.maui.Models.Chart
{
    public class DataEntries
	{
        public float Value { get; set; }
        public string Label { get; set; }
        public string ValueLabel { get; set; }        
        public SKColor ColorDefault => SKColor.Parse("#27AAE7");
        public SKColor ValueLabelColorDefault => SKColor.Parse("#FFFFFF");
        public SKColor TextColorDefault => SKColor.Parse("#FFFFFF");
    }
}

