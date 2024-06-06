using System;
namespace freight.control.maui.Models
{
	public class MainDataMock
	{
		public string Name { get; set; }

		public List<DataMock> ListDataMock { get; set; }
	}

	public class DataMock
	{
		public DateTime Yaer { get; set; }
		public double Population { get; set; }
	}
}

