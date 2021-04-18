using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using kumatodo.Model;
using SQLite;

namespace kumatodo.Persistence
{
    public class SQLiteMemoStore : IMemoStore
    {

        private SQLiteAsyncConnection _connection;

        public SQLiteMemoStore(ISQLiteDb db)
        {
            _connection = db.GetConnection();
            _connection.CreateTableAsync<Memo>();
        }

        public async Task<IEnumerable<Memo>> GetMemosAsync()
        {
            return await _connection.Table<Memo>().ToListAsync();
        }

        public async Task AddMemo(Memo memo)
        {
            await _connection.InsertAsync(memo);
        }

        public async Task DeleteMemo(Memo memo)
        {
            await _connection.DeleteAsync(memo);
        }

        public async Task<Memo> GetMemo(int id)
        {
            return await _connection.FindAsync<Memo>(id);
        }

        public async Task UpdateMemo(Memo memo)
        {
            await _connection.UpdateAsync(memo);
        }
    }
}
