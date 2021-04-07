using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Weather.DAL.Models;

namespace Weather.BL
{
  public class AccuweatherConnector
  {
    string apiKey = ConfigurationManager.AppSettings.Get("ApiKey");

    public List<City> AutocompleteSearch(string query)
    {
      string url = string.Format(ConfigurationManager.AppSettings.Get("AutocompleteURL"), apiKey, query);

      List<City> cities;

      try
      {
        WebClient client = new WebClient();
        string res = client.DownloadString(url);

        //string res = "[{\"Version\":1,\"Key\":\"299429\",\"Type\":\"City\",\"Rank\":25,\"LocalizedName\":\"Jeddah\",\"Country\":{\"ID\":\"SA\",\"LocalizedName\":\"Saudi Arabia\"},\"AdministrativeArea\":{\"ID\":\"02\",\"LocalizedName\":\"Makkah al Mukarramah\"}},{\"Version\":1,\"Key\":\"213225\",\"Type\":\"City\",\"Rank\":30,\"LocalizedName\":\"Jerusalem\",\"Country\":{\"ID\":\"IL\",\"LocalizedName\":\"Israel\"},\"AdministrativeArea\":{\"ID\":\"JM\",\"LocalizedName\":\"Jerusalem\"}},{\"Version\":1,\"Key\":\"223078\",\"Type\":\"City\",\"Rank\":31,\"LocalizedName\":\"Jeonju\",\"Country\":{\"ID\":\"KR\",\"LocalizedName\":\"South Korea\"},\"AdministrativeArea\":{\"ID\":\"45\",\"LocalizedName\":\"Jeollabuk-do\"}},{\"Version\":1,\"Key\":\"224209\",\"Type\":\"City\",\"Rank\":31,\"LocalizedName\":\"Jeju\",\"Country\":{\"ID\":\"KR\",\"LocalizedName\":\"South Korea\"},\"AdministrativeArea\":{\"ID\":\"49\",\"LocalizedName\":\"Jeju-do\"}},{\"Version\":1,\"Key\":\"203179\",\"Type\":\"City\",\"Rank\":35,\"LocalizedName\":\"Jember\",\"Country\":{\"ID\":\"ID\",\"LocalizedName\":\"Indonesia\"},\"AdministrativeArea\":{\"ID\":\"JI\",\"LocalizedName\":\"East Java\"}},{\"Version\":1,\"Key\":\"306735\",\"Type\":\"City\",\"Rank\":42,\"LocalizedName\":\"Jerez de la Frontera\",\"Country\":{\"ID\":\"ES\",\"LocalizedName\":\"Spain\"},\"AdministrativeArea\":{\"ID\":\"AN\",\"LocalizedName\":\"Andalusia\"}},{\"Version\":1,\"Key\":\"223116\",\"Type\":\"City\",\"Rank\":42,\"LocalizedName\":\"Jecheon\",\"Country\":{\"ID\":\"KR\",\"LocalizedName\":\"South Korea\"},\"AdministrativeArea\":{\"ID\":\"43\",\"LocalizedName\":\"Chungcheongbuk-do\"}},{\"Version\":1,\"Key\":\"223080\",\"Type\":\"City\",\"Rank\":42,\"LocalizedName\":\"Jeongeup\",\"Country\":{\"ID\":\"KR\",\"LocalizedName\":\"South Korea\"},\"AdministrativeArea\":{\"ID\":\"45\",\"LocalizedName\":\"Jeollabuk-do\"}},{\"Version\":1,\"Key\":\"171709\",\"Type\":\"City\",\"Rank\":43,\"LocalizedName\":\"Jena\",\"Country\":{\"ID\":\"DE\",\"LocalizedName\":\"Germany\"},\"AdministrativeArea\":{\"ID\":\"TH\",\"LocalizedName\":\"Thuringia\"}},{\"Version\":1,\"Key\":\"3431691\",\"Type\":\"City\",\"Rank\":45,\"LocalizedName\":\"Jebres\",\"Country\":{\"ID\":\"ID\",\"LocalizedName\":\"Indonesia\"},\"AdministrativeArea\":{\"ID\":\"JT\",\"LocalizedName\":\"Central Java\"}}]";

        cities  = JsonConvert.DeserializeObject<List<City>>(res);
      }
      catch (Exception)
      {
        cities = new List<City>();
      }

      return cities;
    }

    public Conditions GetConditions(int locationKey)
    {
      string url = string.Format(ConfigurationManager.AppSettings.Get("ConditionsURL"), locationKey, apiKey);

      Conditions conditions;

      try
      {
        WebClient client = new WebClient();
        string res = client.DownloadString(url);

        //string res = "[{\"LocalObservationDateTime\":\"2021-04-06T06:10:00+09:00\",\"EpochTime\":1617657000,\"WeatherText\":\"Some clouds\",\"WeatherIcon\":36,\"HasPrecipitation\":false,\"PrecipitationType\":null,\"IsDayTime\":false,\"Temperature\":{\"Metric\":{\"Value\":5.8,\"Unit\":\"C\",\"UnitType\":17},\"Imperial\":{\"Value\":42.0,\"Unit\":\"F\",\"UnitType\":18}},\"MobileLink\":\"http://m.accuweather.com/en/kr/jeonju/223078/current-weather/223078?lang=en-us\",\"Link\":\"http://www.accuweather.com/en/kr/jeonju/223078/current-weather/223078?lang=en-us\"}]";

        List<Conditions> ConditionsList = JsonConvert.DeserializeObject<List<Conditions>>(res);

        if (ConditionsList.Count > 0)
          conditions = ConditionsList[0];
        else
          conditions = new Conditions();
      }
      catch (Exception)
      {
        conditions = new Conditions();
      }

      return conditions;
    }
  }
}
