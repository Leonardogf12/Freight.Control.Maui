using ForeignKeyAttribute = SQLiteNetExtensions.Attributes.ForeignKeyAttribute;
using SQLite;

namespace freight.control.maui.MVVM.Models;

public class ToFuelModel
{
	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }

	public DateTime Date { get; set; }

	public double Liters { get; set; }
	
	public decimal AmountSpentFuel { get; set; }

    public decimal ValuePerLiter { get; set; }

    public decimal Expenses { get; set; }

	public string Observation { get; set; }

	[ForeignKey(typeof(FreightModel))]
    public int  FreightModelId { get; set; }


    public string ToFuelDateCustom => Date.ToShortDateString();
	public string AmountSpentFuelCustom => AmountSpentFuel.ToString("c");
    public string ExpensesCustom => Expenses.ToString("c");
	public string ValuePerLiterCustom => ValuePerLiter.ToString("c");

}

