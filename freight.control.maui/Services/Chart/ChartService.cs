using System.Globalization;
using freight.control.maui.Models.Chart;
using freight.control.maui.MVVM.Models;
using Microcharts;

namespace freight.control.maui.Services.Chart
{
    public class ChartService : IChartService
    {
        public ChartEntry[] GenerateLineChartFreight(List<FreightModel> model)
        {
            var data = model.GroupBy(x => new { x.TravelDate.Month })
                            .Select(g => new
                            {
                                M = ConvertStringMount(g.Key.Month),
                                R = g.Sum(t => t.FreightValue)
                            }).ToList();

            var list = new List<DataEntries>();

            foreach (var obj in data)
            {
                list.Add(new DataEntries
                {
                    Label = obj.M,
                    Value = (float)obj.R,
                    ValueLabel = obj.R.ToString("c")
                });
            }

            return list.Select(x =>
            {
                return new ChartEntry(x.Value)
                {
                    Label = x.Label,
                    ValueLabel = x.ValueLabel,
                    Color = x.ColorDefault,
                    TextColor = x.TextColorDefault,
                    ValueLabelColor = x.ValueLabelColorDefault
                };

            }).ToArray();
        }

        private string ConvertStringMount(int month)
        {
            DateTime data = new DateTime(1, month, 1);
            return data.ToString("MMM", new CultureInfo("pt-BR"));
        }
    }

    public class MyInterfaceFactoryChartService
    {
        public static IChartService CreateInstance()
        {
            return new ChartService();
        }
    }
}

