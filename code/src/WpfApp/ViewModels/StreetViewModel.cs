using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using WpfApp.Commands;
using WpfApp.Models;

namespace WpfApp.ViewModels;

public class StreetViewModel : INotifyPropertyChanged
{
  private RelayCommand _nextPage;

  public RelayCommand NextPage
  {
    get
    {
      return _nextPage ??= new RelayCommand(obj =>
      {
        var frame = obj as Frame;
      });
    }
  }

  public ObservableCollection<Street> Streets { get; set; }

  public StreetViewModel()
  {
    Streets = new ObservableCollection<Street>
    {
      new() { Id = 01, CityId = 1, Name = "Pushkin street" },
      new() { Id = 02, CityId = 1, Name = "Pushkin street" },
      new() { Id = 03, CityId = 1, Name = "Pushkin street" },
      new() { Id = 04, CityId = 1, Name = "Pushkin street" },
      new() { Id = 05, CityId = 1, Name = "Pushkin street" },
      new() { Id = 06, CityId = 2, Name = "Pushkin street" },
      new() { Id = 07, CityId = 2, Name = "Pushkin street" },
      new() { Id = 08, CityId = 3, Name = "Pushkin street" },
      new() { Id = 09, CityId = 3, Name = "Pushkin street" },
      new() { Id = 10, CityId = 3, Name = "Pushkin street" },
      new() { Id = 11, CityId = 3, Name = "Pushkin street" },
      new() { Id = 12, CityId = 3, Name = "Pushkin street" },
    };
  }

  public event PropertyChangedEventHandler? PropertyChanged;

  public void OnPropertyChanged([CallerMemberName] string propertyName = "")
  {
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
  }
}
