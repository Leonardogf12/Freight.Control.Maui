using freight.control.maui.MVVM.Models;
using Microcharts;

namespace freight.control.maui.Services.Chart
{
    public interface IChartService
	{
        ChartEntry[] GenerateLineChartFreight(List<FreightModel> model);
    }
}

