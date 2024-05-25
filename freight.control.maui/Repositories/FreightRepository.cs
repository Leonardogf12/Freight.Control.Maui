using freight.control.maui.MVVM.Models;
using SQLite;

namespace freight.control.maui.Repositories;

public class FreightRepository : GenericRepository<FreightModel>
{
    private readonly SQLiteAsyncConnection _db;

    public FreightRepository()
    {
        _db = new SQLiteAsyncConnection(App.DbPath);
    }

    public async Task<FreightModel> GetById(int id)
    {
        return await _db.Table<FreightModel>().Where(x => x.Id == id).FirstAsync();
    }

    public async Task<List<FreightModel>> GetByDateInitialAndFinal(DateTime initial, DateTime final)
    {
        var res = await _db.Table<FreightModel>().Where(x => x.TravelDate >= initial.Date &&
                                                        x.TravelDate <= final.Date &&
                                                        x.UserLocalId == App.UserLocalIdLogged).ToListAsync();

        return res;
    }

    public async Task<List<FreightModel>> GetByUserLocalId(string id)
    {
        return await _db.Table<FreightModel>().Where(x => x.UserLocalId == id).ToListAsync();
    }
}
