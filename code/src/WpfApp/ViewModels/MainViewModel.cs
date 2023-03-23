using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace WpfApp.ViewModels;

class MainViewModel : ViewModelBase, INotifyPropertyChanged
{
  //private object? _currentView;

  //public object? CurrentView
  //{
  //  get => _currentView;
  //  set
  //  {
  //    _currentView = value;
  //    OnPropertyChanged(nameof(CurrentView));
  //  }
  //}

  //private CityViewModel _cityViewModel { get; set; }
  //private StreetViewModel _streetViewModel { get; set; }
  //private HouseViewModel _houseViewModel { get; set; }
  //private ApartmentViewModel _apartmentViewModel { get; set; }

  //public MainViewModel()
  //{
  //  _cityViewModel = new CityViewModel();
  //  _streetViewModel = new StreetViewModel();
  //  _houseViewModel = new HouseViewModel();
  //  _apartmentViewModel = new ApartmentViewModel();

  //  _currentView = _cityViewModel;
  //}

  public MainViewModel(Frame mainFrame)
  {
    _mainFrame = mainFrame;
  }

  public Frame _mainFrame;

  public event PropertyChangedEventHandler? PropertyChanged;

  public void OnPropertyChanged([CallerMemberName] string propertyName = "")
  {
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
  }
}
