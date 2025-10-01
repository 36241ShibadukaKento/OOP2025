using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ColorChecker {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        public ObservableCollection<MyColor> colorsList = new ObservableCollection<MyColor>();
        MyColor currentColor = new MyColor { Color = Color.FromRgb(0, 0, 0), Name = "Black" };   //現在の色情報
        public MainWindow() {
            InitializeComponent();
            listBox.ItemsSource = colorsList;
            DataContext = GetColorList();
        }

        //すべてのスライダーから呼ばれるイベントハンドラ
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {

            //メッセージをリセット
            label.Content = null;

            //colorAreaの色(背景色)は、スライダーで指定したRGBの色を表示する
            byte rbyte = (byte)rSlider.Value;
            byte gbyte = (byte)gSlider.Value;
            byte bbyte = (byte)bSlider.Value;

            var mycolor = new MyColor { Color = Color.FromRgb(rbyte, gbyte, bbyte), Name = null };
            //comboBoxに存在するなら名前を変更
            mycolor.Name = ((MyColor[])DataContext).Where(c => c.Color.R == rbyte && c.Color.G == gbyte && c.Color.B == bbyte).Select(x => x.Name).FirstOrDefault();
            
            //透明と白が混在しているため、透明は白とみなす
            if(mycolor.Name == "Transparent") {
                mycolor.Name = "White";
            }

            currentColor = mycolor;
            colorArea.Background = new SolidColorBrush(mycolor.Color);
            
            //スライダーで指定された色が既存の色ならコンボボックスも変更、そうでないならコンボボックスを未指定の状態に戻す
            if (currentColor.Name != null) {
                Combo.SelectedItem = currentColor;
            } else {
                Combo.SelectedValue = -1;
            }
        }

        //STOOKをクリックして呼ばれるイぺントハンドラ
        private void StockButton_Click(object sender, RoutedEventArgs e) {
            var colorToList = new MyColor {
                Color = currentColor.Color,
                Name = currentColor.Name
            };

            //すでに保存されている場合は保存しない
            if (!colorsList.Contains(colorToList)) {
                colorsList.Add(colorToList);
                label.Content = "登録しました。";
            } else {
                label.Content = "既に登録されています。"; 
            }
        }

        //DELETEをクリックして呼ばれるイベントハンドラ
        private void DeleteButton_Click(object sender, RoutedEventArgs e) {
            if (listBox.SelectedItem != null) {
                colorsList.Remove((MyColor)listBox.SelectedItem);
                label.Content = "削除しました。";
            } else {
                label.Content = "削除対象を指定してください。";
            }
        }

        //コンボボックスに変更があった場合呼ばれるイベントハンドラ
        private void Combo_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (((ComboBox)sender).SelectedIndex != -1) {
                var mycolor = (MyColor)((ComboBox)sender).SelectedItem;
                setSliderValue(mycolor.Color);
                currentColor = mycolor;
            }
        }

        //リストボックス内のアイテムを選択したときに呼ばれるイベントハンドラ
        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (((ListBox)sender).SelectedIndex != -1) {
                var mycolor = (MyColor)((ListBox)sender).SelectedItem;
                setSliderValue(mycolor.Color);
                currentColor = mycolor;
            }
        }


        private void setSliderValue(Color color) {
            rSlider.Value = color.R;
            gSlider.Value = color.G;
            bSlider.Value = color.B;
        }

        private MyColor[] GetColorList() {
            return typeof(Colors).GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Select(i => new MyColor() { Color = (Color)i.GetValue(null), Name = i.Name }).ToArray();
        }

        //起動時に呼び出されるイベントハンドラ
        private void Window_Loaded(object sender, RoutedEventArgs e) {
            //メッセージをリセット
            label.Content = null;

            Combo.SelectedItem = currentColor;
        }
    }
}

