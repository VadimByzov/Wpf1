using System.Configuration;
using Microsoft.Data.SqlClient;

namespace WpfApp.DataAccess;

public abstract class DatabaseService
{
  private string _connectionString;

  public DatabaseService()
  {
    _connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
  }

  protected SqlConnection GetConnection()
  {
    return new SqlConnection(_connectionString);
  }
}
