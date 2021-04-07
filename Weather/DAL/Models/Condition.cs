using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weather.DAL.Models
{
  public class Conditions
  {
    public string WeatherText { get; set; }
    public Temperature Temperature { get; set; }
  }

  public class Temperature
  {
    public MeasurementMethod Metric { get; set; }
  }

  public class MeasurementMethod
  {
    public decimal Value { get; set; }
  }
}
