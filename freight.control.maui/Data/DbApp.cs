using freight.control.maui.MVVM.Models;
using SQLite;

namespace freight.control.maui.Data;

public class DbApp
{
	private readonly SQLiteAsyncConnection _dbApp;

	public DbApp(string path)
	{
		_dbApp = new SQLiteAsyncConnection(path);

		_dbApp.CreateTableAsync<FreightModel>();
        _dbApp.CreateTableAsync<ToFuelModel>();
    }
}
