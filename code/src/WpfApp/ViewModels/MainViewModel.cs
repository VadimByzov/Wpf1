using System.Collections.Generic;

namespace WpfApp.ViewModels;

class MainViewModel : ViewModelBase
{
  private Dictionary<string, IViewModel> _viewModels;

  public Dictionary<string, IViewModel> ViewModels
  {
    get => _viewModels;
    private set => _viewModels = value;
  }

  private IViewModel _currentViewModel;

  public IViewModel CurrentViewModel
  {
    get => _currentViewModel;
    set
    {
      _currentViewModel = value;
      OnPropertyChanged(nameof(CurrentViewModel));
    }
  }

  private void ChangeCurrentViewModel(string viewmodel, int id)
  {
    CurrentViewModel = ViewModels[viewmodel];
    CurrentViewModel.ParentId = id;
  }

  private void OnCityVM(int id)
  {
    ChangeCurrentViewModel(nameof(CityViewModel), id);
  }

  private void OnStreetVM(int id)
  {
    ChangeCurrentViewModel(nameof(StreetViewModel), id);
  }

  private void OnHouseVM(int id)
  {
    ChangeCurrentViewModel(nameof(HouseViewModel), id);
  }

  private void OnApartmentVM(int id)
  {
    ChangeCurrentViewModel(nameof(ApartmentViewModel), id);
  }

  public MainViewModel()
  {
    ViewModels = new Dictionary<string, IViewModel>
    {
      { nameof(CityViewModel), new CityViewModel() },
      { nameof(StreetViewModel), new StreetViewModel() },
      { nameof(HouseViewModel), new HouseViewModel() },
      { nameof(ApartmentViewModel), new ApartmentViewModel() },
    };

    CurrentViewModel = ViewModels[nameof(CityViewModel)];

    Switcher.Register(nameof(CityViewModel), OnCityVM);
    Switcher.Register(nameof(StreetViewModel), OnStreetVM);
    Switcher.Register(nameof(HouseViewModel), OnHouseVM);
    Switcher.Register(nameof(ApartmentViewModel), OnApartmentVM);
  }
}
