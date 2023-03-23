using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using WpfApp.Commands;
using WpfApp.DataAccess;
using WpfApp.Models;

namespace WpfApp.ViewModels;

public class CityViewModel : ViewModelBase, INotifyPropertyChanged
{
  private RelayCommand? _nextPage;

  public RelayCommand NextPage
  {
    get
    {
      return _nextPage ??= new RelayCommand(obj =>
      {
        
      });
    }
  }

  private readonly CityDataService _cityDataService;

  private City? _selectedCity;

  public City? SelectedCity
  {
    get => _selectedCity;
    set
    {
      _selectedCity = value;
      OnPropertyChanged(nameof(SelectedCity));
    }
  }

  public ObservableCollection<City> Cities { get; set; }

  public CityViewModel()
  {
    _cityDataService = new CityDataService();
    var cities = _cityDataService.GetAll().Select(x => new City 
    {
      Id = x.Id,
      Name = x.Name,
      StreetsNumber = x.StreetsNumber
    });

    Cities = new ObservableCollection<City>(cities);
    //Cities = new ObservableCollection<City>
    //{
    //  new() { Id = 1, Name = "Moscow" },
    //  new() { Id = 2, Name = "Saint-Peterburg" },
    //  new() { Id = 3, Name = "Mock" },
    //  new() { Id = 3, Name = "Mock" },
    //  new() { Id = 3, Name = "Mock" },
    //  new() { Id = 3, Name = "Mock" },
    //  new() { Id = 3, Name = "Mock" },
    //  new() { Id = 3, Name = "Mock" },
    //  new() { Id = 3, Name = "Mock" },
    //  new() { Id = 3, Name = "Mock" },
    //  new() { Id = 3, Name = "Mock" },
    //  new() { Id = 3, Name = "Mock" },
    //  new() { Id = 3, Name = "Mock" },
    //  new() { Id = 3, Name = "Mock" },
    //  new() { Id = 3, Name = "Mock" },
    //  new() { Id = 3, Name = "Mock" },
    //  new() { Id = 3, Name = "Mock" },
    //  new() { Id = 3, Name = "Mock" },
    //  new() { Id = 3, Name = "Mock" },
    //  new() { Id = 3, Name = "Mock" },
    //  new() { Id = 3, Name = "Mock" },
    //  new() { Id = 3, Name = "Mock" },
    //  new() { Id = 3, Name = "Mock" },
    //  new() { Id = 3, Name = "Mock" },
    //  new() { Id = 3, Name = "Mock" },
    //};
  }

  public event PropertyChangedEventHandler? PropertyChanged;

  public void OnPropertyChanged([CallerMemberName] string propertyName = "")
  {
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
  }
}
