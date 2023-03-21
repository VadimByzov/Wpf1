using System.Windows.Controls;
using WpfApp.ViewModels;

namespace WpfApp.View;

/// <summary>
/// Логика взаимодействия для CityView.xaml
/// </summary>
public partial class CityView : Page
{
  public CityView()
  {
    InitializeComponent();
    DataContext = new CityViewModel();
  }
}
