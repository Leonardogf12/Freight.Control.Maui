using freight.control.maui.MVVM.Models;
using Microcharts;

namespace freight.control.maui.Services.Chart
{
    public interface IChartService
	{
        ChartEntry[] GenerateLineChartFreightMonthly(List<FreightModel> model);

        ChartEntry[] GenerateLineChartFreightDaily(List<FreightModel> model);

        Task<ChartEntry[]> GenerateLineChartToFuelMonthly(List<FreightModel> model);

        Task<ChartEntry[]> GenerateLineChartToFuelDaily(List<FreightModel> model);
    }
}

