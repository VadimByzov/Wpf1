using System.Collections.Generic;
using Dapper;
using WpfApp.DataAccess.Models;

namespace WpfApp.DataAccess;

public class ApartmentDataService : DatabaseService
{
  public IEnumerable<Apartment> GetAll()
  {
    using var connection = GetConnection();
    return connection.Query<Apartment>("select * from apartments");
  }
}
