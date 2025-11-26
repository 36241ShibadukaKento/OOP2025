using System.Globalization;
using System.Net.Http;
using System.Text.Json;
using System.Windows;
using System.Windows.Data;
using TenkiApp.ViewModel;

namespace TenkiApp {

    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            this.DataContext = new MainViewModel();

        }
    }
}