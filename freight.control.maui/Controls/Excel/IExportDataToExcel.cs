using freight.control.maui.MVVM.Models;

namespace freight.control.maui.Controls.Excel
{
    public interface IExportDataToExcel
	{
        Task ExportData(List<FreightModel> list);
    }
}

