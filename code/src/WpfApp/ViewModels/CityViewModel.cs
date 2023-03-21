using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using WpfApp.Commands;
using WpfApp.View;

namespace WpfApp.ViewModels;

public class CityViewModel : INotifyPropertyChanged
{
  private RelayCommand _nextPage;

  public RelayCommand NextPage
  {
    get
    {
      return _nextPage ??= new RelayCommand(obj =>
      {
        var frame = obj as Frame;
        frame.Navigate(typeof(StreetView));
      });
    }
  }

  public CityViewModel()
  {

  }

  public event PropertyChangedEventHandler? PropertyChanged;

  public void OnPropertyChanged([CallerMemberName] string propertyName = "")
  {
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
  }
}
