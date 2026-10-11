using Avalonia.Controls;
using TempControlAvaloniaUI.ViewModel;

namespace TempControlAvaloniaUI;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }
}