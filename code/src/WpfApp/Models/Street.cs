namespace WpfApp.Models;

public class Street : ModelBase
{
  private int _id;
  private int _cityId;
  private string? _name;
  private int _housesNumber;

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

  public int HousesNumber
  {
    get => _housesNumber;
    set
    {
      _housesNumber = value;
      OnProprtyChanged(nameof(HousesNumber));
    }
  }
}
