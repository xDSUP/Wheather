using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using MySqlConnector;
using WebApplication;
using WebApplication.Models;

namespace WebApplication.Query
{
    public class WeatherQuery
    {
        public AppDb Db { get; }

        public WeatherQuery(AppDb db)
        {
            Db = db;
        }

        public async Task<Weather> FindOneAsync(int id)
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT `Id`, `Title`, `Content` FROM `City` WHERE `Id` = @id";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = id,
            });
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            return result.Count > 0 ? result[0] : null;
        }

        public async Task<List<Weather>> LatestPostsAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT id, title, link FROM city ORDER BY id DESC LIMIT 10;";
            return await ReadAllAsync(await cmd.ExecuteReaderAsync());
        }

        public async Task DeleteAllAsync()
        {
            using var txn = await Db.Connection.BeginTransactionAsync();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"DELETE FROM `City`";
            await cmd.ExecuteNonQueryAsync();
            await txn.CommitAsync();
        }

        private async Task<List<Weather>> ReadAllAsync(DbDataReader reader)
        {
            var posts = new List<Weather>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var post = new Weather(Db)
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Link = reader.GetString(2),
                    };
                    posts.Add(post);
                }
            }
            return posts;
        }
    }
}
