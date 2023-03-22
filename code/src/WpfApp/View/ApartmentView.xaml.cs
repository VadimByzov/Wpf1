using System.Windows.Controls;
using WpfApp.ViewModels;

namespace WpfApp.View;

/// <summary>
/// Логика взаимодействия для ApartmentView.xaml
/// </summary>
public partial class ApartmentView : Page
{
  public ApartmentView()
  {
    InitializeComponent();
    DataContext = new ApartmentViewModel();
  }
}
