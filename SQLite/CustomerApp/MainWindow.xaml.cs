using CustomerApp.Data;
using Microsoft.Win32;
using SQLite;
using System.IO;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomerApp {

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private List<Customer> _Customer = new List<Customer>();
        public MainWindow() {
            InitializeComponent();
            ReadDatabace();
            CustomerListView.ItemsSource = _Customer;
        }
        private void ReadDatabace() {
            using (var connection = new SQLiteConnection(App.databasePath)) {
                connection.CreateTable<Customer>();
                _Customer = connection.Table<Customer>().ToList();
            }
        }

        private void NewRegistration_Click(object sender, RoutedEventArgs e) {
            var customer = new Customer() {
                Name = NameTextBox.Text,
                Phone = PhoneTextBox.Text,
                Address = AddressTextBox.Text,
                //Picture = PictureBox.Source
            };

            using (var connection = new SQLiteConnection(App.databasePath)) {
                connection.CreateTable<Customer>();
                connection.Insert(customer);
            }
            ReadDatabace();
            CustomerListView.ItemsSource = _Customer;
        }

        private void UpDateButton_Click(object sender, RoutedEventArgs e) {
            var selectedPerson = CustomerListView.SelectedItem as Customer;
            if (selectedPerson is null) return;

            using (var connection = new SQLiteConnection(App.databasePath)) {
                connection.CreateTable<Customer>();
                var person = new Customer() {
                    Id = selectedPerson.Id,
                    Name = NameTextBox.Text,
                    Phone = PhoneTextBox.Text,
                    Address = AddressTextBox.Text
                };
                connection.Update(person);
                ReadDatabace();
                CustomerListView.ItemsSource = _Customer;
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e) {
            var item = CustomerListView.SelectedItem as Customer;

            if (CustomerListView.SelectedItem == null) {
                MessageBox.Show("行を選択してください");
            } else {
                using (var connection = new SQLiteConnection(App.databasePath)) {
                    connection.CreateTable<Customer>();
                    connection.Delete(item);

                    ReadDatabace();
                    CustomerListView.ItemsSource = _Customer;
                }
            }
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var selectedPerson = CustomerListView.SelectedItem as Customer;
            if (selectedPerson == null) return;
            NameTextBox.Text = selectedPerson?.Name;
            PhoneTextBox.Text = selectedPerson?.Phone;
            AddressTextBox.Text = selectedPerson?.Address;

        }

        private byte[]? _tempImageBytes = null;
        private void PictureButton_Click(object sender, RoutedEventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            var ret =  ofd.ShowDialog();
            if(ret ?? false) {

            }
            ofd.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            if (ofd.ShowDialog() == true) {
                try {
                    string selectedFilePath = ofd.FileName;

                    using (var stream = File.OpenRead(selectedFilePath)) {
                        var bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.CacheOption = BitmapCacheOption.OnLoad;
                        bitmap.StreamSource = stream;
                        bitmap.EndInit();
                        bitmap.Freeze();
                        PictureBox.Source = bitmap;

                    }
                }
                catch (Exception ex) {
                    MessageBox.Show("ファイルの読み込み中エラーが発生しました");
                }
            }
        }
    }
}