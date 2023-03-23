namespace WpfApp.Models;

public class Apartment : ModelBase
{
  private int _id;
  private int _houseId;
  private double _area;

  public int Id
  {
    get => _id;
    set
    {
      _id = value;
      OnProprtyChanged(nameof(Id));
    }
  }

  public int HouseId
  {
    get => _houseId;
    set
    {
      _houseId = value;
      OnProprtyChanged(nameof(HouseId));
    }
  }

  public double Area
  {
    get => _area;
    set
    {
      _area = value;
      OnProprtyChanged(nameof(Area));
    }
  }
}
