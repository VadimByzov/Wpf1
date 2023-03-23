using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp.Models;

public abstract class ModelBase : INotifyPropertyChanged
{
  public event PropertyChangedEventHandler? PropertyChanged;

  public void OnProprtyChanged([CallerMemberName] string propertyName = "")
  {
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
  }
}
