using Microsoft.UI.Xaml.Controls;

using TestRelativePanelDrop.ViewModels;

namespace TestRelativePanelDrop.Views;

public sealed partial class MainPage : Page
{
    public MainViewModel ViewModel
    {
        get;
    }

    public MainPage()
    {
        ViewModel = App.GetService<MainViewModel>();
        InitializeComponent();
    }
}
