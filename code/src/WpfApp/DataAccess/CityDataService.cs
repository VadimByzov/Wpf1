using System.Collections.Generic;
using Dapper;
using WpfApp.DataAccess.Models;

namespace WpfApp.DataAccess;

public class CityDataService : DatabaseService
{
  public IEnumerable<City> GetAll()
  {
    using var connection = GetConnection();
    return connection.Query<City>(
      "select c.id, c.name, count(s.city_id) 'streetsnumber' from cities c left join streets s " +
      "on c.id = s.city_id group by c.id, c.name");
  }
}
