using System.Text;
using freight.control.maui.MVVM.Models;
using freight.control.maui.Repositories;
using freight.control.maui.Services;

namespace freight.control.maui.Controls
{
    public class ExportDataToExcel : IExportDataToExcel
    {
        private readonly ToFuelRepository _toFuelRepository;

        public ExportDataToExcel()
        {
            _toFuelRepository = new();
        }

		public async Task ExportData(List<FreightModel> list)
		{
            if (list == null) return;

            string nameFile = $"fretes{DateTime.Now.ToString("dd-MM-yy-hh-mm-ss")}.csv";

            string path = Path.Combine(Android.App.Application.Context.FilesDir.AbsolutePath, "/storage/emulated/0/Documents/");

            string filePath = Path.Combine(path, nameFile);

            var utf8 = new UTF8Encoding(true);
                     
            var totalFreight = list.Select(x => x.FreightValue).Sum();

            using (var writer = new StreamWriter(filePath, false, utf8))
            {
                await writer.WriteAsync($"Código #;Data;Origem;Destino;Distância (KM);Valor (R$);Observação");

                foreach (var freight in list)
                {
                    await writer.WriteAsync($"\n# {freight.Id};" +
                                            $"{freight.TravelDate.ToShortDateString()};" +
                                            $"{freight.Origin} - {freight.OriginUf};" +
                                            $"{freight.Destination} - {freight.DestinationUf};" +
                                            $"{freight.Kilometer};" +
                                            $"{freight.FreightValue:c};" +
                                            $"{freight.Observation}");
                }


                await writer.WriteLineAsync();
                await writer.WriteAsync($"-;-;-;-;-;Total Valor: {totalFreight:c};-");
                await writer.WriteLineAsync();
                await writer.WriteLineAsync();
                await writer.WriteAsync($"Código #;Data;Litros (Lt);Valor (R$);Valor/Litro (R$);Despesas (R$);Observação");

                double totalLiters = 0;
                decimal totalValue = 0;
                decimal totalExpenses = 0;

                foreach (var item in list)
                {
                    var supplies = await GetFreightSupplies(item);

                    foreach (var fuel in supplies)
                    {
                        await writer.WriteAsync($"\n# {fuel.FreightModelId};" +
                                                $"{fuel.Date.ToShortDateString()};" +
                                                $"{fuel.Liters};" +
                                                $"{fuel.AmountSpentFuel:c};" +
                                                $"{fuel.ValuePerLiter:c};" +
                                                $"{fuel.Expenses:c};" +
                                                $"{fuel.Observation}");

                        totalLiters += fuel.Liters;
                        totalValue += fuel.AmountSpentFuel;
                        totalExpenses += fuel.Expenses;
                    }
                }

                await writer.WriteLineAsync();
                await writer.WriteAsync($"-;-;Total Litros: {totalLiters};Total Valor: {totalValue:c};-;Total Despesas: {totalExpenses:c};-");
                await writer.WriteLineAsync();
                await writer.WriteAsync($"Total Geral: {totalFreight - totalValue - totalExpenses:c};-;-;-;-;-;-");
            }

            await App.Current.MainPage.DisplayAlert("Sucesso", "Arquivo exportado com sucesso. O arquivo foi salvo em: Documentos.", "Ok");
        }

        public async Task<List<ToFuelModel>> GetFreightSupplies(FreightModel item)
        {
            var list = await _toFuelRepository.GetAllById(item.Id);

            return list.ToList();
        }
    }
}

