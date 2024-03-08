using System;
using freight.control.maui.MVVM.Models;

namespace freight.control.maui.Services
{
	public interface IExportDataToExcel
	{
        Task ExportData(List<FreightModel> list);
    }
}

