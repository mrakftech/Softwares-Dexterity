using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using DexterityApp.Contracts.Views;
using DexterityApp.ViewModels;
using Syncfusion.SfSkinManager;
using Syncfusion.UI.Xaml.NavigationDrawer;
using Syncfusion.Windows.Shared;

namespace DexterityApp.Views
{
    public partial class ShellWindow : ChromelessWindow, IShellWindow
    {
        public string themeName = App.Current.Properties["Theme"]?.ToString();
        public ShellViewModel _ShellViewModel;

        public ShellWindow(ShellViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            _ShellViewModel = viewModel;

            themeName = themeName == null ? "Windows11Light" : themeName;
            SfSkinManager.SetTheme(this, new Theme(themeName));
            if (this is ShellWindow)
            {
                if ((this as ShellWindow) != null && ((this as ShellWindow).Content is SfNavigationDrawer) && ((this as ShellWindow).Content as SfNavigationDrawer) != null && (((this as ShellWindow).Content as SfNavigationDrawer).ContentView) as Frame != null)
                {

                    SfSkinManager.SetTheme((((this as ShellWindow).Content as SfNavigationDrawer).ContentView) as Frame, new Theme(themeName));
                    SfSkinManager.SetTheme((this as ShellWindow).Content as SfNavigationDrawer, new Theme(themeName));
                }
            }
        }

        public Frame GetNavigationFrame()
            => shellFrame;

        public void ShowWindow()
            => Show();

        public void CloseWindow()
            => Close();

        private void ChromelessWindow_Closed(object sender, System.EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
    public class MyObservableCollection : ObservableCollection<object> { }
}
