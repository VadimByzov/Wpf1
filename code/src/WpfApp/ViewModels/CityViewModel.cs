using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfApp.Commands;
using WpfApp.Models;

namespace WpfApp.ViewModels;

public class CityViewModel : BaseViewModel, INotifyPropertyChanged
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
    Cities = new ObservableCollection<City>
    {
      new() { Id = 1, Name = "Moscow" },
      new() { Id = 2, Name = "Saint-Peterburg" },
      new() { Id = 3, Name = "Mock" },
      new() { Id = 3, Name = "Mock" },
      new() { Id = 3, Name = "Mock" },
      new() { Id = 3, Name = "Mock" },
      new() { Id = 3, Name = "Mock" },
      new() { Id = 3, Name = "Mock" },
      new() { Id = 3, Name = "Mock" },
      new() { Id = 3, Name = "Mock" },
      new() { Id = 3, Name = "Mock" },
      new() { Id = 3, Name = "Mock" },
      new() { Id = 3, Name = "Mock" },
      new() { Id = 3, Name = "Mock" },
      new() { Id = 3, Name = "Mock" },
      new() { Id = 3, Name = "Mock" },
      new() { Id = 3, Name = "Mock" },
      new() { Id = 3, Name = "Mock" },
      new() { Id = 3, Name = "Mock" },
      new() { Id = 3, Name = "Mock" },
      new() { Id = 3, Name = "Mock" },
      new() { Id = 3, Name = "Mock" },
      new() { Id = 3, Name = "Mock" },
      new() { Id = 3, Name = "Mock" },
      new() { Id = 3, Name = "Mock" },
    };
  }

  public event PropertyChangedEventHandler? PropertyChanged;

  public void OnPropertyChanged([CallerMemberName] string propertyName = "")
  {
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
  }
}
