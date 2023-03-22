using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp.ViewModels;

class MainViewModel : BaseViewModel, INotifyPropertyChanged
{
  private BaseViewModel? _currentView;

  public BaseViewModel? CurrentViewModel
  {
    get => _currentView;
    set
    {
      _currentView = value;
      OnPropertyChanged(nameof(CurrentViewModel));
    }
  }

  public event PropertyChangedEventHandler? PropertyChanged;

  public void OnPropertyChanged([CallerMemberName] string propertyName = "")
  {
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
  }
}
