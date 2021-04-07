using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Weather.DAL.Models;

namespace Weather.DAL
{
  public class WeatherManager
  {
    string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["weather"].ConnectionString;

    public CityWeather GetWeather(int locationKey)
    {
      using (SqlConnection connection = new SqlConnection(connectionString))
      {
        string sql = "Select * FROM CityWeather where CityKey=@locationKey and WeatherDate=@today;";
        return connection.QueryFirstOrDefault<CityWeather>(sql, new { locationKey=locationKey, today=DateTime.Today });
      }
    }

    internal async Task SaveWeather(CityWeather cityWeather)
    {
      try
      {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
          await connection.InsertAsync(cityWeather);
        }
      }
      catch (Exception ex)
      {
      }
    }
  }
}
