using System.Collections.Generic;
using Dapper;
using WpfApp.DataAccess.Models;

namespace WpfApp.DataAccess;

public class HouseDataService : DatabaseService
{
  public IEnumerable<House> GetAll()
  {
    using var connection = GetConnection();
    return connection.Query<House>(
      "select h.id, h.number, h.street_id, count(a.id) 'apartmentsnumber', sum(a.area) 'areasum' from houses h left join apartments a " +
      "on h.id = a.house_id group by h.id, h.number, h.street_id");
  }
}
