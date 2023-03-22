using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using WpfApp.Commands;
using WpfApp.Models;

namespace WpfApp.ViewModels;

public class ApartmentViewModel : INotifyPropertyChanged
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

  public ObservableCollection<Apartment> Apartments { get; set; }

  public ApartmentViewModel()
  {
    Apartments = new ObservableCollection<Apartment>
    {
      new() { Id = 01, HouseId = 1, Area = 100.00 },
      new() { Id = 02, HouseId = 1, Area = 045.00 },
      new() { Id = 03, HouseId = 1, Area = 023.00 },
      new() { Id = 04, HouseId = 1, Area = 112.00 },
      new() { Id = 05, HouseId = 1, Area = 141.00 },
      new() { Id = 06, HouseId = 2, Area = 153.00 },
      new() { Id = 07, HouseId = 2, Area = 151.00 },
      new() { Id = 08, HouseId = 3, Area = 054.00 },
      new() { Id = 09, HouseId = 3, Area = 075.00 },
      new() { Id = 10, HouseId = 3, Area = 023.00 },
      new() { Id = 11, HouseId = 3, Area = 042.00 },
      new() { Id = 12, HouseId = 3, Area = 032.00 },
    };
  }

  public event PropertyChangedEventHandler? PropertyChanged;

  public void OnPropertyChanged([CallerMemberName] string propertyName = "")
  {
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
  }
}
