using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using WpfApp.Commands;
using WpfApp.DataAccess;
using WpfApp.Models;

namespace WpfApp.ViewModels;

public class CityViewModel : ViewModelBase, IViewModel
{
  #region Data

  public int ParentId { get; set; }

  private readonly CityDataService _cityDataService;

  public IEnumerable<City> Cities { get; set; }

  #endregion

  #region Commands

  private ICommand _navigateStreetCommand;

  public ICommand NavigateStreetCommand
  {
    get => _navigateStreetCommand ??= new RelayCommand(x =>
    {
      Switcher.Switch(nameof(StreetViewModel), nameof(CityViewModel), SelectedCity.Id, ParentId);
    },
    x => SelectedCity is not null);
  }

  #endregion

  #region Other

  public CityViewModel()
  {
    _cityDataService = new CityDataService();

    Cities = _cityDataService.GetAll().Select(x => new City
      {
        Id = x.Id,
        Name = x.Name,
        StreetsNumber = x.StreetsNumber
      });
  }

  private City _selectedCity;

  public City SelectedCity
  {
    get => _selectedCity;
    set
    {
      _selectedCity = value;
      OnPropertyChanged(nameof(SelectedCity));
    }
  }

  #endregion
}
