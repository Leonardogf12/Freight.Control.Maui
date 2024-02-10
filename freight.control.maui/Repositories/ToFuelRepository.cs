using freight.control.maui.MVVM.Models;
using SQLite;

namespace freight.control.maui.Repositories;

public class ToFuelRepository : GenericRepository<ToFuelModel>
{
	private readonly SQLiteAsyncConnection _db;

	public ToFuelRepository()
	{
		_db = new SQLiteAsyncConnection(App.dbPath);
    }
}
