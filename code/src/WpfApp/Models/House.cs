using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp.Models;

public class House : INotifyPropertyChanged
{
  private int _id;
  private int _streetId;
  private string? _number;

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

  public string? Number
  {
    get => _number;
    set
    {
      _number = value;
      OnProprtyChanged(nameof(Number));
    }
  }

  public event PropertyChangedEventHandler? PropertyChanged;

  public void OnProprtyChanged([CallerMemberName] string propertyName = "")
  {
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
  }
}
