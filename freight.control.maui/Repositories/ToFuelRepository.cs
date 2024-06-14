using freight.control.maui.MVVM.Models;
using SQLite;

namespace freight.control.maui.Repositories
{
    public class ToFuelRepository : GenericRepository<ToFuelModel>
    {
        private readonly SQLiteAsyncConnection _db;

        public ToFuelRepository()
        {
            _db = new SQLiteAsyncConnection(App.DbPath);
        }

        public async Task<List<ToFuelModel>> GetAllById(int id)
        {
            return await _db.Table<ToFuelModel>().Where(x => x.FreightModelId == id).ToListAsync();
        }

        public async Task<bool> DeleteByIdFreightAsync(int id)
        {
            try
            {
                var list = await GetAllById(id);

                if (!list.Any()) return false;

                await Task.WhenAll(list.Select(x => _db.DeleteAsync(x)));

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Falha ao deletar alguns registros de Abastecimento. Conferir detalhes em => {ex.Message}");
                return false;
            }

        }
    }
}


