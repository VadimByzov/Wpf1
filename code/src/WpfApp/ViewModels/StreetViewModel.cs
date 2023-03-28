using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using WpfApp.Commands;
using WpfApp.DataAccess;
using WpfApp.Models;

namespace WpfApp.ViewModels;

public class StreetViewModel : ViewModelBase, IViewModel
{
  #region Data

  public int ParentId { get; set; }

  private readonly StreetDataService _streetDataService;

  public IEnumerable<Street> Streets
  {
    get => GetStreets();
  }

  private IEnumerable<Street> GetStreets()
  {
    var streets = _streetDataService.GetAll().Select(s => new Street
    {
      Id = s.Id,
      CityId = s.City_Id,
      Name = s.Name,
      HousesNumber = s.HousesNumber
    });
    var filtered = streets.Where(x => x.CityId == ParentId);
    return filtered;
  }

  #endregion

  #region Commands

  private ICommand _navigateHouseCommand;

  public ICommand NavigateHouseCommand
  {
    get => _navigateHouseCommand ??= new RelayCommand(x =>
    {
      Switcher.Switch(nameof(HouseViewModel), nameof(StreetViewModel), SelectedStreet.Id, ParentId);
    },
    x => SelectedStreet is not null);
  }

  private ICommand _navigateBack;

  public ICommand NavigateBack
  {
    get => _navigateBack ??= new RelayCommand(x =>
    {
      Switcher.Back();
    });
  }

  #endregion

  #region Other

  public StreetViewModel()
  {
    _streetDataService = new StreetDataService();
  }

  private Street _selectedStreet;

  public Street SelectedStreet
  {
    get => _selectedStreet;
    set
    {
      _selectedStreet = value;
      OnPropertyChanged(nameof(SelectedStreet));
    }
  }

  #endregion
}
