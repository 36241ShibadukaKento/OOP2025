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
using System.Threading.Tasks;

namespace WebBrowser;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window {
    public MainWindow() {
        InitializeComponent();
        InitializeAsync();
    }

    private async Task InitializeAsync() {
        await WebView.EnsureCoreWebView2Async();    //非同期にしてブラウザを初期化する
        WebView.CoreWebView2.NavigationStarting += CoreWebView2_NavigationStarting;
        WebView.CoreWebView2.NavigationCompleted += CoreWebView2_NavigationCompleted;
    }

    //読み込み開始時にプログレスバーを表示
    private void CoreWebView2_NavigationStarting(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationStartingEventArgs e) {
        LoadingBar.Visibility = Visibility.Visible;
        LoadingBar.IsIndeterminate = true;
    }
    //読み込み終了時にプログレスバーを非表示
    private void CoreWebView2_NavigationCompleted(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e) {
        LoadingBar.Visibility = Visibility.Collapsed;
        LoadingBar.IsIndeterminate = false;
    }


    private void BackButton_Click(object sender, RoutedEventArgs e) {
        if (this.WebView != null && this.WebView.CanGoBack) this.WebView.GoBack();

    }

    private void ForwardButton_Click(object sender, RoutedEventArgs e) {
        if (this.WebView != null && this.WebView.CanGoForward) this.WebView.GoForward();
    }

    private void GoButton_Click(object sender, RoutedEventArgs e) {
        var url = AddressBar.Text.Trim();
        if (string.IsNullOrWhiteSpace(url)) return;
        WebView.Source = new Uri(url);
    }
}