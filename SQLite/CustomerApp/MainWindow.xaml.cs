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
            if (string.IsNullOrWhiteSpace(NameTextBox.Text)) {
                MessageBox.Show("氏名を入力してください");
            } else {
                byte[] binary;
                BitmapEncoder encoder = new PngBitmapEncoder();

                if (PictureBox.Source == null) {
                    binary = null;
                } else {
                    encoder.Frames.Add(BitmapFrame.Create((BitmapImage)PictureBox.Source));

                    using (var ms = new MemoryStream()) {
                        encoder.Save(ms);
                        binary = ms.ToArray();
                    }
                }
                var customer = new Customer() {
                    Name = NameTextBox.Text,
                    Phone = PhoneTextBox.Text,
                    Address = AddressTextBox.Text,
                    Picture = binary
                };

                using (var connection = new SQLiteConnection(App.databasePath)) {
                    connection.CreateTable<Customer>();
                    connection.Insert(customer);
                }
                ReadDatabace();
                CustomerListView.ItemsSource = _Customer;
            }
        }

        private void UpDateButton_Click(object sender, RoutedEventArgs e) {
            byte[] binary;
            BitmapEncoder encoder = new PngBitmapEncoder();

            if (PictureBox.Source == null) {
                binary = null;
            } else {
                encoder.Frames.Add(BitmapFrame.Create((BitmapImage)PictureBox.Source));
                using (var ms = new MemoryStream()) {
                    encoder.Save(ms);
                    binary = ms.ToArray();
                }
            }
            var selected = CustomerListView.SelectedItem as Customer;
            if (selected is null) return;

            using (var connection = new SQLiteConnection(App.databasePath)) {
                connection.CreateTable<Customer>();
                var person = new Customer() {
                    Id = selected.Id,
                    Name = NameTextBox.Text,
                    Phone = PhoneTextBox.Text,
                    Address = AddressTextBox.Text,
                    Picture = binary
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
            var selected = CustomerListView.SelectedItem as Customer;
            if (selected == null) return;
            NameTextBox.Text = selected?.Name;
            PhoneTextBox.Text = selected?.Phone;
            AddressTextBox.Text = selected?.Address;

            if (selected?.Picture == null) {
                PictureBox.Source = null;
            } else {
                BitmapImage bitmapImage = new BitmapImage();
                using (var ms = new MemoryStream(selected?.Picture)) {
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad; // ストリームを閉じた後も画像データを保持する
                    bitmapImage.StreamSource = ms;
                    bitmapImage.EndInit();
                }
                PictureBox.Source = bitmapImage;
            }

        }

        private byte[]? _tempImageBytes = null;

        private void PictureButton_Click(object sender, RoutedEventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            var ret = ofd.ShowDialog();
            if (ret ?? false) {

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
        private void DeletePictureButton_Click(object sender, RoutedEventArgs e) {
            PictureBox.Source = null;
        }       
    }
}