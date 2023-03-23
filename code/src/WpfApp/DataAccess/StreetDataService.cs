using System.Collections.Generic;
using Dapper;
using WpfApp.DataAccess.Models;

namespace WpfApp.DataAccess;

public class StreetDataService : DatabaseService
{
  public IEnumerable<Street> GetAll()
  {
    using var connection = GetConnection();
    return connection.Query<Street>(
      "select s.id, s.name, s.city_id, count(h.id) 'housesnumber' from streets s left join houses h " +
      "on s.id = h.street_id group by s.id, s.name, s.city_id");
  }
}
