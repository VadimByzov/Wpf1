using System.Windows.Controls;
using WpfApp.ViewModels;

namespace WpfApp.View;

/// <summary>
/// Логика взаимодействия для StreetView.xaml
/// </summary>
public partial class StreetView : Page
{
  public StreetView()
  {
    InitializeComponent();
    DataContext = new StreetViewModel();
  }
}
