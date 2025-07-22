using System.Net;
using System.Security.Policy;
using System.Xml.Linq;

namespace RssReader {
    public partial class Form1 : Form {

        private List<ItemData> items;

        public Form1() {
            InitializeComponent();
        }

        private async void btRssGet_Click(object sender, EventArgs e) {
            try {
                using (var hc = new HttpClient()) {
                    XDocument xdoc = XDocument
                    .Parse(await hc.GetStringAsync(tbUrl.Text));

                    //RSSを解析して必要な要素を取得
                    items = xdoc.Root.Descendants("item")
                         .Select(x => new ItemData {
                             Title = (string?)x.Element("title"),
                             Link = (string?)x.Element("link"),
                         }).ToList();

                }

                //リストボックスに表示
                lbTitles.Items.Clear();
                items.ForEach(item => lbTitles.Items.Add(item.Title));
            }
            catch (Exception) {
                return;
            }
        }

        //タイトルからページの表示
        private void lbTitles_Click(object sender, EventArgs e) {
            if (items is null || lbTitles.SelectedItem is null) {
                return;
            } else {
                wvRssLink.Source = new Uri(items[lbTitles.SelectedIndex].Link);
            }
        }

        //ページを1つ戻す
        private void back_Click(object sender, EventArgs e) {
            if (this.wvRssLink != null && this.wvRssLink.CanGoBack) this.wvRssLink.GoBack();
        }

        //ページを1つ進める
        private void advance_Click(object sender, EventArgs e) {
            if (this.wvRssLink != null && this.wvRssLink.CanGoForward) this.wvRssLink.GoForward();
        }

        //コンボボックスにお気に入りを追加
        private void setCombo(string pageName) {
            //既に登録済みか確認
            if (tbUrl.Items.Contains(pageName) || pageName == "") {

            } else {
                //未登録の場合登録
                tbUrl.Items.Add(pageName);
            }
        }


        //ページが切り替わるときに呼ばれる
        private void wvRssLink_SourceChanged(object sender, Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs e) {
            checkMoves();
        }

        //マスク処理
        private void checkMoves() {
            back.Enabled = wvRssLink.CanGoBack;
            advance.Enabled = wvRssLink.CanGoForward;
        }

        //アプリが起動したときに呼ばれる
        private void Form1_Load(object sender, EventArgs e) {
            back.Enabled = false;
            advance.Enabled = false;

        }
    }
}
