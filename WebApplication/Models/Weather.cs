using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MySqlConnector;

namespace WebApplication.Models
{
    // погода на определенную часть дня
    public class WeatherInHour
    {
        // 
        public enum PartOfDay { NIGHT, MORNING, AFTERNOON, EVENING };

        public PartOfDay partOfDay { get; set; }

        public int Temperature { get; set; }

        // направление ветра
        public String Wind { get; set; }
        
        // скорость ветра
        public int Speed { get; set; }

        // давление
        public int Pressure { get; set; }

        // влажность
        public int Humidiy { get; set; }

        // осадки в мм
        public float Precipitation { get; set; }

        // облачность
        public String Sky { get; set; }
    }

    public class Weather
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }

        internal AppDb Db { get; set; }

        public Weather()
        {
        }

        internal Weather(AppDb db)
        {
            Db = db;
        }

        public async Task InsertAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO `city` (`title`, `link`) VALUES (@Title, @Link);";
            BindParams(cmd);
            await cmd.ExecuteNonQueryAsync();
            Id = (int)cmd.LastInsertedId;
        }

        public async Task UpdateAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"UPDATE `city` SET `title` = @Title, `link` = @Link WHERE `idcity` = @Id;";
            BindParams(cmd);
            BindId(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task DeleteAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"DELETE FROM `City` WHERE `idcity` = @id;";
            BindId(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        private void BindId(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = Id,
            });
        }

        private void BindParams(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@title",
                DbType = DbType.String,
                Value = Title,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@link",
                DbType = DbType.String,
                Value = Link,
            });
        }
    }
}
