using System.Windows.Controls;

using DexterityApp.Contracts.Views;
using DexterityApp.ViewModels;

using Syncfusion.SfSkinManager;
using Syncfusion.Windows.Shared;

namespace DexterityApp.Views
{
    public partial class ShellDialogWindow : ChromelessWindow, IShellDialogWindow
    {
        public ShellDialogWindow(ShellDialogViewModel viewModel)
        {
            InitializeComponent();
            viewModel.SetResult = OnSetResult;
            DataContext = viewModel;
        }

        public Frame GetDialogFrame()
            => dialogFrame;

        private void OnSetResult(bool? result)
        {
            DialogResult = result;
            Close();
        }
    }
}
