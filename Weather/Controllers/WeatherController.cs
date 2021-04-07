using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Weather.BL;
using Weather.DAL;
using Weather.DAL.Models;

namespace Weather.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class WeatherController : ControllerBase
  {
    // GET api/<WeatherController>/5
    [HttpGet("{id}")]
    public CityWeather GetCurrentWeather(int id)
    {
      AccuweatherConnector accuweather = new AccuweatherConnector();

      WeatherManager manager = new WeatherManager();
      CityWeather cityWeather = manager.GetWeather(id);

      if (cityWeather == null) {
        Conditions conditions = accuweather.GetConditions(id);
        cityWeather = GetWeatherFromConditions(id, conditions);

        _ = manager.SaveWeather(cityWeather);
      }

      return cityWeather;
    }

    private CityWeather GetWeatherFromConditions(int locationId, Conditions conditions)
    {
      CityWeather cityWeather = new CityWeather();
      cityWeather.CityKey = locationId;
      cityWeather.Weather = conditions.Temperature.Metric.Value;
      cityWeather.WeatherText = conditions.WeatherText;
      cityWeather.WeatherDate = DateTime.Today;
      
      return cityWeather;
    }
  }
}
