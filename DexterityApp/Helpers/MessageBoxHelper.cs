using System.Windows.Forms;

namespace DexterityApp.Helpers;

public class MessageBoxHelper
{
    public static void ShowSuccessMessage(string message)
    {
        MessageBox.Show(message, @"Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    
    public static void ShowFailMessage(string message)
    {
        MessageBox.Show(message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}