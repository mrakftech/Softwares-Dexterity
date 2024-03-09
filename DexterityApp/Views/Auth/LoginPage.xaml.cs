using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DexterityApp.Contracts.ViewModels;
using DexterityApp.Contracts.Views;
using DexterityApp.ViewModels.Auth;

namespace DexterityApp.Views.Auth;

public partial class LoginPage : Window, IWindowHandle
{
    public LoginPage()
    {
    }

    public LoginPage(LoginViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
        Loaded += Window_Loaded;
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        if (DataContext is IWindows vm)
        {
            vm.Hide += Hide;
        }
    }

    public void ShowWindow()
        => Show();

    public void CloseWindow()
        => Close();

    public void HideWindow()
        => Close();

    private void UsernameTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        if (!string.IsNullOrEmpty(UsernameTextBox.Text) && UsernameTextBox.Text.Length > 0)
        {
            UserNameTextBlock.Visibility = Visibility.Collapsed;
        }
        else
        {
            UserNameTextBlock.Visibility = Visibility.Visible;
        }
    }

    private void UserNameTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
    {
        UsernameTextBox.Focus();
    }

    private void PasswordTextBlock_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        PasswordText.Focus();
    }

    private void PasswordText_OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        if (!string.IsNullOrEmpty(PasswordText.Password) && PasswordText.Password.Length > 0)
        {
            PasswordTextBlock.Visibility = Visibility.Collapsed;
        }
        else
        {
            PasswordTextBlock.Visibility = Visibility.Visible;
        }
    }


    private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Left)
        {
            this.DragMove();
        }
    }

    private void Image_OnMouseUp(object sender, MouseButtonEventArgs e)
    {
        Application.Current.Shutdown();
    }
}