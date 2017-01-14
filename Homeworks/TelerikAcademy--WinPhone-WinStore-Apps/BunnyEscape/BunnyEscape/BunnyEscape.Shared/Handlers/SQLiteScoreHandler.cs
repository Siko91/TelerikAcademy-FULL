using BunnyEscape.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace BunnyEscape.Handlers
{
    public class SQLiteScoreHandler
    {
        private const string dbName = "ScoresDatabase.db";

        public static SQLiteScoreHandler CreateInstance()
        {
            var db = new SQLiteScoreHandler();
            return db;
        }


        private SQLiteAsyncConnection db;

        public SQLiteScoreHandler()
        {
            CreateDatabaseIfNotExists();
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(dbName);
            this.db = conn;
        }

        protected async Task CreateDatabaseIfNotExists()
        {
            bool dbExists = await CheckDbExistsAsync(dbName);
            if (!dbExists)
            {
                await CreateDatabaseAsync();
            }
        }
        private async Task<bool> CheckDbExistsAsync(string dbName)
        {
            bool dbExist = true;
            try
            {
                StorageFile sf = await ApplicationData.Current.LocalFolder.GetFileAsync(dbName);
            }
            catch (Exception)
            {
                dbExist = false;
            }

            return dbExist;
        }
        private async Task CreateDatabaseAsync()
        {
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(dbName); 
            await db.CreateTableAsync<ScoreLocal>();
        }

        public async Task SaveNewScore(IScore score)
        {
            if (score is ScoreLocal)
            {
                await this.db.InsertAsync(score as ScoreLocal);
            }
            else
            {
                throw new ArgumentException("Only local scores can be saved in local database");
            }
        }

        public async Task<IEnumerable<IScore>> GetTopScores(int count = 10)
        {
            var query = this.db.Table<ScoreLocal>()
                 .OrderByDescending(sc => sc.Points)
                 .Take(count);
            var result = await query.ToListAsync();
            return result;
        }

    }
}
