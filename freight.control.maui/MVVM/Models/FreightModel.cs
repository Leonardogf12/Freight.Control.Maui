using SQLite;

namespace freight.control.maui.MVVM.Models;

public class FreightModel
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string UserLocalId { get; set; }

    public DateTime TravelDate { get; set; }

	public string OriginUf { get; set; }

    public string Origin { get; set; }

    public string DestinationUf { get; set; }

    public string Destination { get; set; }

    public double Kilometer { get; set; }

	public decimal FreightValue { get; set; }

	public string Observation { get; set; }

	public string TravelDateCustom => TravelDate.ToShortDateString();
}
