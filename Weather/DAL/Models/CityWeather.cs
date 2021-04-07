using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weather.DAL.Models
{
  [Table("CityWeather")]
  public class CityWeather
  {
    [ExplicitKey]
    public int CityKey { get; set; }
    public decimal Weather { get; set; }
    public string WeatherText { get; set; }
    public DateTime WeatherDate { get; set; }
  }
}
