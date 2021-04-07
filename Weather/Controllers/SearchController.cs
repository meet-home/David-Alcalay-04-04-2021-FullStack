using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Weather.BL;
using Weather.DAL.Models;

namespace Weather.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SearchController : ControllerBase
  {
    // GET api/<SearchController>/5
    [HttpGet("{query}")]
    public List<City> Search(string query)
    {
      AccuweatherConnector accuweather = new AccuweatherConnector();
      return accuweather.AutocompleteSearch(query);
    }
  }
}
