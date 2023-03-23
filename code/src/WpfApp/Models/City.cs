namespace WpfApp.Models;

public class City : ModelBase
{
  private int _id;
  private string? _name;
  private int _streetsNumber;

  public int Id
  {
    get => _id;
    set
    {
      _id = value;
      OnProprtyChanged(nameof(Id));
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

  public int StreetsNumber
  {
    get => _streetsNumber;
    set
    {
      _streetsNumber = value;
      OnProprtyChanged(nameof(StreetsNumber));
    }
  }
}
