using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using WpfApp.Commands;
using WpfApp.DataAccess;
using WpfApp.Models;

namespace WpfApp.ViewModels;

public class HouseViewModel : ViewModelBase, IViewModel
{
  #region Data

  public int ParentId { get; set; }

  private readonly HouseDataService _houseDataService;

  public IEnumerable<House> Houses
  {
    get => GetHouses();
  }

  private IEnumerable<House> GetHouses()
  {
    var houses = _houseDataService.GetAll().Select(x => new House
    {
      Id = x.Id,
      StreetId = x.Id,
      Number = x.Number,
      ApartmentsNumber = x.ApartmentsNumber,
      AreaSum = x.AreaSum,
    });
    var filtered = houses.Where(x => x.StreetId == ParentId);
    return filtered;
  }

  #endregion

  #region Commands

  private ICommand _navigateApartmentCommand;

  public ICommand NavigateApartmentCommand
  {
    get => _navigateApartmentCommand ??= new RelayCommand(x =>
    {
      Switcher.Switch(nameof(ApartmentViewModel), nameof(HouseViewModel), SelectedHouse.Id);
    },
    x => SelectedHouse is not null);
  }

  private ICommand _navigateBack;

  public ICommand NavigateBack
  {
    get => _navigateBack ??= new RelayCommand(x =>
    {
      Switcher.Back(ParentId);
    });
  }

  #endregion

  #region Other

  public HouseViewModel()
  {
    _houseDataService = new HouseDataService();
  }

  private House _selectedHouse;

  public House SelectedHouse
  {
    get => _selectedHouse;
    set
    {
      _selectedHouse = value;
      OnPropertyChanged(nameof(SelectedHouse));
    }
  }

  #endregion
}
