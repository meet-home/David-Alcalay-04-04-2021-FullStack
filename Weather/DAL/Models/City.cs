using Dapper.Contrib.Extensions;


namespace Weather.DAL.Models
{
  [Table("Favorites")]
  public class City
  {
    [Dapper.Contrib.Extensions.Key]
    public int Key { get; set; }
    public string LocalizedName { get; set; }
  }
}
