using System.Windows;
using TenkiApp.ViewModel;

namespace TenkiApp {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e) {
            if (DataContext is MainViewModel vm) {
                await vm.InitializeAsync();
            }
        }
    }
}