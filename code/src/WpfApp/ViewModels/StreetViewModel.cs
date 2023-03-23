using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using WpfApp.Commands;
using WpfApp.DataAccess;
using WpfApp.Models;

namespace WpfApp.ViewModels;

public class StreetViewModel : ViewModelBase, INotifyPropertyChanged
{
  private RelayCommand? _nextPage;

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

  private readonly StreetDataService _streetDataService;

  public ObservableCollection<Street> Streets { get; set; }

  public StreetViewModel()
  {
    _streetDataService = new StreetDataService();
    var streets = _streetDataService.GetAll().Select(s => new Street
    {
      Id = s.Id,
      CityId = s.City_Id,
      Name = s.Name,
      HousesNumber = s.HousesNumber
    });
    Streets = new ObservableCollection<Street>(streets);

    //Streets = new ObservableCollection<Street>
    //{
    //  new() { Id = 01, CityId = 1, Name = "Pushkin street" },
    //  new() { Id = 02, CityId = 1, Name = "Pushkin street" },
    //  new() { Id = 03, CityId = 1, Name = "Pushkin street" },
    //  new() { Id = 04, CityId = 1, Name = "Pushkin street" },
    //  new() { Id = 05, CityId = 1, Name = "Pushkin street" },
    //  new() { Id = 06, CityId = 2, Name = "Pushkin street" },
    //  new() { Id = 07, CityId = 2, Name = "Pushkin street" },
    //  new() { Id = 08, CityId = 3, Name = "Pushkin street" },
    //  new() { Id = 09, CityId = 3, Name = "Pushkin street" },
    //  new() { Id = 10, CityId = 3, Name = "Pushkin street" },
    //  new() { Id = 11, CityId = 3, Name = "Pushkin street" },
    //  new() { Id = 12, CityId = 3, Name = "Pushkin street" },
    //};
  }

  public event PropertyChangedEventHandler? PropertyChanged;

  public void OnPropertyChanged([CallerMemberName] string propertyName = "")
  {
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
  }
}
