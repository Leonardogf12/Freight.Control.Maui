using System.Globalization;
using freight.control.maui.Models.Chart;
using freight.control.maui.MVVM.Models;
using freight.control.maui.Repositories;
using Microcharts;

namespace freight.control.maui.Services.Chart
{    
    public class ChartService : IChartService
    {
        private readonly ToFuelRepository _toFuelRepository;


        public ChartService()
        {
            _toFuelRepository = new();
        }

        public ChartEntry[] GenerateLineChartFreightMonthly(List<FreightModel> model)
        {
            var data = model.GroupBy(x => new { x.TravelDate.Month })
                            .Select(g => new DataEntriesHelper
                            {
                                MonthFilter = g.Key.Month,                              
                                Label = ConvertIntNumberToStringMount(g.Key.Month),
                                Value = g.Sum(t => t.FreightValue)
                            }).OrderBy(o=>o.MonthFilter).ToList();


            return GetArrayToChartEntries(data);
        }

        public ChartEntry[] GenerateLineChartFreightDaily(List<FreightModel> model)
        {
            var data = model.GroupBy(x => new { x.TravelDate.Day, x.TravelDate.Month, x.TravelDate })
                            .Select(n => new DataEntriesHelper
                            {
                                DayFilter = n.Key.Day,
                                DateFilter = n.Key.TravelDate,                                
                                Label = $"{n.Key.Day}/{ConvertIntNumberToStringMount(n.Key.Month)}",
                                Value = n.Sum(f => f.FreightValue)
                            }).OrderBy(o => o.DateFilter).ToList();

           
            return GetArrayToChartEntries(data);
        }

        public async Task<ChartEntry[]> GenerateLineChartToFuelMonthly(List<FreightModel> model)
        {            
            List<DataEntriesHelper> SupplyList = new();
           
            foreach (var freight in model)
            {
                var listToFuel = await _toFuelRepository.GetAllById(freight.Id);
                
                if (listToFuel.Count() == 0) continue;

                var listDataEntries = listToFuel.GroupBy(x => new {x.Date.Month})
                                   .Select(n => new DataEntriesHelper
                                   {
                                       MonthFilter = n.Key.Month,
                                       Label = ConvertIntNumberToStringMount(n.Key.Month),
                                       Value = n.Sum(s=> s.AmountSpentFuel)
                                   }).OrderBy(o=>o.MonthFilter).ToList();

                SupplyList.AddRange(listDataEntries);           
            }
           
            var finalList = SupplyList.GroupBy(x => new {x.MonthFilter, x.Label })
                                      .Select(n => new DataEntriesHelper
                                      {
                                          MonthFilter = n.Key.MonthFilter,                                                                                  
                                          Label = n.Key.Label,
                                          Value = n.Sum(x=>x.Value)
                                      }).OrderBy(x=>x.MonthFilter).ToList();          

            return GetArrayToChartEntries(finalList);
        }

        public async Task<ChartEntry[]> GenerateLineChartToFuelDaily(List<FreightModel> model)
        {
            List<DataEntriesHelper> SupplyList = new();

            foreach (var freight in model)
            {
                var listToFuel = await _toFuelRepository.GetAllById(freight.Id);

                if (listToFuel.Count() == 0) continue;

                var data = listToFuel.GroupBy(x => new { x.Date.Day, x.Date.Month, x.Date})
                             .Select(n => new DataEntriesHelper
                             {
                                 DayFilter = n.Key.Day,
                                 DateFilter = n.Key.Date,
                                 Label = $"{n.Key.Day}/{ConvertIntNumberToStringMount(n.Key.Month)}",
                                 Value = n.Sum(f => f.AmountSpentFuel)
                             }).OrderBy(o => o.DayFilter).ToList();

                SupplyList.AddRange(data);
            }

            var finalList = SupplyList.GroupBy(x => x.DayFilter).Select(x => x.First()).OrderBy(x=>x.DateFilter).ToList();

            return GetArrayToChartEntries(finalList);
        }

        private ChartEntry[] GetArrayToChartEntries(List<DataEntriesHelper> data)
        {
            var list = new List<DataEntries>();

            foreach (var obj in data)
            {
                list.Add(new DataEntries
                {
                    Label = obj.Label,
                    Value = (float)obj.Value,
                    ValueLabel = obj.Value.ToString("c")
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

        private string ConvertIntNumberToStringMount(int month)
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

