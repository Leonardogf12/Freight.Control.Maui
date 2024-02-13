using ForeignKeyAttribute = SQLiteNetExtensions.Attributes.ForeignKeyAttribute;
using SQLite;
using System.ComponentModel.DataAnnotations.Schema;

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


    [NotMapped]
    public string ToFuelDateCustom => Date.ToShortDateString();
    [NotMapped]
    public string AmountSpentFuelCustom => AmountSpentFuel.ToString("c");
    [NotMapped]
    public string ExpensesCustom => Expenses.ToString("c");
    [NotMapped]
    public string ValuePerLiterCustom => ValuePerLiter.ToString("c");


}

