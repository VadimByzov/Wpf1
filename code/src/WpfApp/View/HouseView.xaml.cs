using System.Windows.Controls;

using WpfApp.ViewModels;
namespace WpfApp.View;

/// <summary>
/// Логика взаимодействия для HouseView.xaml
/// </summary>
public partial class HouseView : Page
{
  public HouseView()
  {
    InitializeComponent();
    DataContext = new HouseViewModel();
  }
}
