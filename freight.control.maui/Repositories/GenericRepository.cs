using SQLite;

namespace freight.control.maui.Repositories
{
    public class GenericRepository<T> where T : new()
    {
        private readonly SQLiteAsyncConnection _db;

        public GenericRepository()
        {
            _db = new SQLiteAsyncConnection(App.DbPath);
            _db.CreateTableAsync<T>().Wait();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _db.Table<T>().ToListAsync();
        }

        public async Task<int> SaveAsync(T model)
        {
            return await _db.InsertAsync(model);
        }

        public async Task<int> UpdateAsync(T model)
        {
            return await _db.UpdateAsync(model);
        }

        public async Task<int> DeleteAsync(T model)
        {
            return await _db.DeleteAsync(model);
        }

        public async Task<int> DeleteAllAsync()
        {
            return await _db.DeleteAllAsync<T>();
        }
    }
}


