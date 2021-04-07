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
  public class FavoriteManager
  {
    string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["weather"].ConnectionString;

    public IEnumerable<City> GetFavoriteList()
    {
      using (SqlConnection connection = new SqlConnection(connectionString))
      {
        string sql = "Select * FROM Favorites;";
        return connection.Query<City>(sql);
      }
    }

    internal bool AddFavorite(City city)
    {
      try
      {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
          string sql = @"INSERT INTO Favorites ([Key], LocalizedName)
                        SELECT @Key, @LocalizedName
                        WHERE NOT EXISTS ( SELECT 1 FROM Favorites WHERE [Key]=@Key )";

          connection.Execute(sql, new { Key = city.Key, LocalizedName = city.LocalizedName });

          return true;
        }
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    internal bool DeleteFavorite(int cityKey)
    {
      try
      {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
          connection.Delete(new City{ Key = cityKey });
          return true;
        }
      }
      catch (Exception ex)
      {
        return false;
      }
    }
  }
}
