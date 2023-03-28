namespace WpfApp.Models;

public class House : ModelBase
{
  private int _id;
  private int _streetId;
  private string _number;
  private int _apartmentsNumber;
  private double _areaSum;

  public int Id
  {
    get => _id;
    set
    {
      _id = value;
      OnProprtyChanged(nameof(Id));
    }
  }

  public int StreetId
  {
    get => _streetId;
    set
    {
      _streetId = value;
      OnProprtyChanged(nameof(StreetId));
    }
  }

  public string Number
  {
    get => _number;
    set
    {
      _number = value;
      OnProprtyChanged(nameof(Number));
    }
  }

  public int ApartmentsNumber
  {
    get => _apartmentsNumber;
    set
    {
      _apartmentsNumber = value;
      OnProprtyChanged(nameof(ApartmentsNumber));
    }
  }

  public double AreaSum
  {
    get => _areaSum;
    set
    {
      _areaSum = value;
      OnProprtyChanged(nameof(AreaSum));
    }
  }
}
