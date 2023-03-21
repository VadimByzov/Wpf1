using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp.Models;

public class Apartment : INotifyPropertyChanged
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

  public event PropertyChangedEventHandler? PropertyChanged;

  public void OnProprtyChanged([CallerMemberName] string propertyName = "")
  {
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
  }
}
