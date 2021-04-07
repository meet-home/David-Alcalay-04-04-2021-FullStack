using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Weather.DAL;
using Weather.DAL.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Weather.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class FavoriteController : ControllerBase
  {
    // GET: api/<FavoriteController>
    [HttpGet]
    public IEnumerable<City> Get()
    {
      FavoriteManager manager = new FavoriteManager();
      return manager.GetFavoriteList();
    }

    // POST api/<FavoriteController>
    [HttpPost]
    public void AddToFavorites([FromBody] City city)
    {
      FavoriteManager favoriteManager = new FavoriteManager();
      favoriteManager.AddFavorite(city);
    }

    // DELETE api/<FavoriteController>/5
    [HttpDelete("{id}")]
    public void DeleteFavorite(int id)
    {
      FavoriteManager favoriteManager = new FavoriteManager();
      favoriteManager.DeleteFavorite(id);
    }
  }
}
