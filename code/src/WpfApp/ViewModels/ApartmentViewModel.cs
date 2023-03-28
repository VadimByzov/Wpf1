using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using WpfApp.Commands;
using WpfApp.DataAccess;
using WpfApp.Models;

namespace WpfApp.ViewModels;

public class ApartmentViewModel : ViewModelBase, IViewModel
{
  #region Data

  public int ParentId { get; set; }

  private double _lowBorder;

  public double LowBorder
  {
    get => _lowBorder;
    set
    {
      _lowBorder = value;
      OnPropertyChanged(nameof(LowBorder));
    }
  }

  private double _highBorder;

  public double HighBorder
  {
    get => _highBorder;
    set
    {
      _highBorder = value;
      OnPropertyChanged(nameof(HighBorder));
    }
  }

  private readonly ApartmentDataService _apartmentDataService;

  private IEnumerable<Apartment> _defaultApartments;
  private IEnumerable<Apartment> _apartments;

  public IEnumerable<Apartment> Apartments
  {
    get => _apartments ??= GetApartments();
    set
    {
      _apartments = value;
      OnPropertyChanged(nameof(Apartments));
    }
  }

  private IEnumerable<Apartment> GetApartments()
  {
    var apartments = _apartmentDataService.GetAll().Select(x => new Apartment
    {
      Id = x.Id,
      HouseId = x.House_Id,
      Area = x.Area,
    });
    _defaultApartments = apartments.Where(x => x.HouseId == ParentId);
    return _defaultApartments;
  }

  #endregion

  #region Commands

  private ICommand _navigateBack;

  public ICommand NavigateBack
  {
    get => _navigateBack ??= new RelayCommand(x =>
    {
      Switcher.Back();
    });
  }

  private ICommand _filter;

  public ICommand Filter
  {
    get => _filter ??= new RelayCommand(x =>
    {
      Apartments = Apartments.Where(x => x.Area >= LowBorder && x.Area <= HighBorder);
    });
  }

  private ICommand _clearFilter;

  public ICommand ClearFilter
  {
    get => _clearFilter ??= new RelayCommand(x =>
    {
      LowBorder = 0;
      HighBorder = 0;
      Apartments = _defaultApartments;
    });
  }

  #endregion

  #region Other

  public ApartmentViewModel()
  {
    _apartmentDataService = new ApartmentDataService();
  }

  private Apartment _selectedApartment;

  public Apartment SelectedApartment
  {
    get => _selectedApartment;
    set
    {
      _selectedApartment = value;
      OnPropertyChanged(nameof(SelectedApartment));
    }
  }

  #endregion
}
