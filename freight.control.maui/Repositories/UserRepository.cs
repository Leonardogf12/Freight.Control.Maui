using freight.control.maui.MVVM.Models;
using SQLite;

namespace freight.control.maui.Repositories;

public class UserRepository : GenericRepository<UserModel>
{
    private readonly SQLiteAsyncConnection _db;

    public UserRepository()
    {
        _db = new SQLiteAsyncConnection(App.DbPath);
    }

    public async Task<UserModel> GetUserByFirebaseLocalId(string localId)
    {
        return await _db.Table<UserModel>().Where(x => x.FirebaseLocalId == localId).FirstOrDefaultAsync();
    }
}
