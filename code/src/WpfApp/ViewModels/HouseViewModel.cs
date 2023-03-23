using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using WpfApp.Commands;
using WpfApp.DataAccess;
using WpfApp.Models;

namespace WpfApp.ViewModels;

public class HouseViewModel : ViewModelBase, INotifyPropertyChanged
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

  private readonly HouseDataService _houseDataService;

  public ObservableCollection<House> Houses { get; set; }

  public HouseViewModel()
  {
    _houseDataService = new HouseDataService();
    var houses = _houseDataService.GetAll().Select(x => new House
    {
      Id = x.Id,
      StreetId = x.Id,
      Number = x.Number,
      ApartmentsNumber = x.ApartmentsNumber,
      AreaSum = x.AreaSum,
    });
    Houses = new ObservableCollection<House>(houses);

    //Houses = new ObservableCollection<House>
    //{
    //  new() { Id = 01, StreetId = 1, Number = "1" },
    //  new() { Id = 02, StreetId = 1, Number = "1" },
    //  new() { Id = 03, StreetId = 1, Number = "1" },
    //  new() { Id = 04, StreetId = 1, Number = "1" },
    //  new() { Id = 05, StreetId = 1, Number = "1" },
    //  new() { Id = 06, StreetId = 2, Number = "1" },
    //  new() { Id = 07, StreetId = 2, Number = "1" },
    //  new() { Id = 08, StreetId = 3, Number = "1" },
    //  new() { Id = 09, StreetId = 3, Number = "1" },
    //  new() { Id = 10, StreetId = 3, Number = "1" },
    //  new() { Id = 11, StreetId = 3, Number = "1" },
    //  new() { Id = 12, StreetId = 3, Number = "1" },
    //};
  }

  public event PropertyChangedEventHandler? PropertyChanged;

  public void OnPropertyChanged([CallerMemberName] string propertyName = "")
  {
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
  }
}
