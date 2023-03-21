using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp.Models;

public class Street
{
  private int _id;
  private int _cityId;
  private string? _name;

  public int Id
  {
    get => _id;
    set
    {
      _id = value;
      OnProprtyChanged(nameof(Id));
    }
  }

  public int CityId
  {
    get => _cityId;
    set
    {
      _cityId = value;
      OnProprtyChanged(nameof(CityId));
    }
  }

  public string? Name
  {
    get => _name;
    set
    {
      _name = value;
      OnProprtyChanged(nameof(Name));
    }
  }

  public event PropertyChangedEventHandler? PropertyChanged;

  public void OnProprtyChanged([CallerMemberName] string propertyName = "")
  {
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
  }
}
