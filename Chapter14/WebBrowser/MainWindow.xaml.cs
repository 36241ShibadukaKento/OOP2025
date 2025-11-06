using System.Net.Http;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Security.Policy;
using System.Xml.Linq;

namespace WebBrowser;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

    }

    private void BackButton_Click(object sender, RoutedEventArgs e) {
        if (this.WebView != null && this.WebView.CanGoBack) this.WebView.GoBack();

    }

    private void ForwardButton_Click(object sender, RoutedEventArgs e) {
        if (this.WebView != null && this.WebView.CanGoForward) this.WebView.GoForward();
    }

    private async void GoButton_Click(object sender, RoutedEventArgs e) {
        try {
            var url = AddressBar.Text;
            WebView.Source = new Uri(url);
        }
        catch (Exception) {
        }
    }
}