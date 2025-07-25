using System.Net;
using System.Security.Policy;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace RssReader {
    public partial class Form1 : Form {

        private List<ItemData> items;

        Dictionary<string, string> urlDict = new Dictionary<string, string> {
            {"主要", "https://news.yahoo.co.jp/rss/topics/top-picks.xml"},
            {"エンタメ","https://news.yahoo.co.jp/rss/topics/entertainment.xml" }
        };

        public Form1() {
            InitializeComponent();

        }

        //アプリが起動したときに呼ばれる
        private void Form1_Load(object sender, EventArgs e) {
            //マスク処理を行う
            back.Enabled = false;
            advance.Enabled = false;

            cbUrl.DataSource = urlDict.Select(k => k.Key).ToList();
            cbUrl.Text = string.Empty;
        }

        //取得
        private async void btRssGet_Click(object sender, EventArgs e) {
            try {
                using (var hc = new HttpClient()) {

                    XDocument xdoc = XDocument.Parse(await hc.GetStringAsync(getRssUrl(cbUrl.Text)));

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

        //ページが切り替わるときに呼ばれる
        private void wvRssLink_SourceChanged(object sender, Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs e) {
            checkMoves();
        }

        //マスク処理
        private void checkMoves() {
            back.Enabled = wvRssLink.CanGoBack;
            advance.Enabled = wvRssLink.CanGoForward;
        }

        //お気に入り登録
        private void btFavorite_Click(object sender, EventArgs e) {
            //名称、URLともに未登録かつURLが記入されているの場合のみ登録
            if (urlDict.ContainsKey(tbName.Text) || urlDict.ContainsValue(cbUrl.Text) || cbUrl.Text == "") {

            } else {
                //名称が記入されていない場合はURLを名称として保存
                if (tbName.Text == "") {
                    tbName.Text = cbUrl.Text;
                }
                urlDict.Add(tbName.Text, cbUrl.Text);
                cbUrl.DataSource = urlDict.Select(k => k.Key).ToList();
                cbUrl.Text = string.Empty;
                tbName.Text = string.Empty; //登録後にコンボボックス、テキストボックスの表示を初期化
            }
        }

        //お気に入りの削除
        private void btDelete_Click(object sender, EventArgs e) {
            if (urlDict.ContainsKey(cbUrl.Text) || cbUrl.Text == "") {

            } else {
                //登録済みの場合削除


                cbUrl.Text = string.Empty;
                tbName.Text = string.Empty; //登録後にコンボボックス、テキストボックスの表示を初期化
            }
        }

        //コンボボックスに格納されている文字列がURLかどうかの判別
        private string getRssUrl(string url) {
            if (urlDict.ContainsKey(url)) {
                return urlDict[url];
            }
            return url;
        }
    }
}
