using System.Net;
using System.Security.Policy;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
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

            //コンボボックスの初期設定
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
                tsslbMessage.Text = "";

            }
            catch (Exception) {
                tsslbMessage.Text = "有効なURLがありません";
                return;
            }
        }

        //タイトルからページの表示
        private void lbTitles_Click(object sender, EventArgs e) {
            if (items is null || lbTitles.SelectedItem is null) {
                return;
            } else {
                wvRssLink.Source = new Uri(items[lbTitles.SelectedIndex].Link);
                tsslbMessage.Text = "";

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
            tsslbMessage.Text = "";

        }

        //マスク処理
        private void checkMoves() {
            back.Enabled = wvRssLink.CanGoBack;
            advance.Enabled = wvRssLink.CanGoForward;
        }

        //お気に入り登録
        private void btFavorite_Click(object sender, EventArgs e) {
            //未登録の名前のURLが記入されているの場合のみ登録
            if (IsValidUrl(cbUrl.Text)) {
                if (urlDict.ContainsKey(tbName.Text) || urlDict.ContainsValue(cbUrl.Text) ||
                    urlDict.ContainsKey(cbUrl.Text) || cbUrl.Text == "") {
                    if (urlDict.ContainsKey(tbName.Text)) {
                        tsslbMessage.Text = "既に使用されている名前です";
                    }
                    if (urlDict.ContainsValue(cbUrl.Text) || urlDict.ContainsKey(cbUrl.Text)) {
                        tsslbMessage.Text = "既に登録されているURLです";
                    }
                } else {
                    //名称が記入されていない場合はURLを名称として保存
                    if (tbName.Text == "") {
                        tbName.Text = cbUrl.Text;
                    }
                    urlDict.Add(tbName.Text, cbUrl.Text);
                    cbUrl.DataSource = urlDict.Select(k => k.Key).ToList();
                    cbUrl.Text = string.Empty;
                    tbName.Text = string.Empty; //登録後にコンボボックス、テキストボックスの表示を初期化
                    MessageBox.Show("登録しました。");
                    tsslbMessage.Text = "";

                }
            } else {
                tsslbMessage.Text = "有効なURLでありません";
            }
        }

        //お気に入りの削除
        private void btDelete_Click(object sender, EventArgs e) {
            //現在コンボボックスから選択されているものを削除
            if (!urlDict.ContainsKey(cbUrl.Text) || cbUrl.Text == "") {
                if (!urlDict.ContainsKey(cbUrl.Text)) {
                    tsslbMessage.Text = "登録されていないURLです";
                }
            } else {
                urlDict.Remove(cbUrl.SelectedItem.ToString());
                cbUrl.DataSource = urlDict.Select(k => k.Key).ToList();
                cbUrl.Text = string.Empty;
                tbName.Text = string.Empty; //削除後にコンボボックス、テキストボックスの表示を初期化
                MessageBox.Show("削除しました。");
                tsslbMessage.Text = "";

            }
        }

        //コンボボックスに格納されている文字列がURLかどうかの判別
        private string getRssUrl(string url) {
            if (urlDict.ContainsKey(url)) {
                return urlDict[url];
            }
            return url;
        }

        //色設定
        private void lbTitles_DrawItem(object sender, DrawItemEventArgs e) {
            var idx = e.Index;                                                      //描画対象の行
            if (idx == -1) return;                                                  //範囲外なら何もしない
            var sts = e.State;                                                      //セルの状態
            var fnt = e.Font;                                                       //フォント
            var _bnd = e.Bounds;                                                    //描画範囲(オリジナル)
            var bnd = new RectangleF(_bnd.X, _bnd.Y, _bnd.Width, _bnd.Height);      //描画範囲(描画用)
            var txt = (string)lbTitles.Items[idx];                                  //リストボックス内の文字
            var bsh = new SolidBrush(lbTitles.ForeColor);                           //文字色
            var sel = (DrawItemState.Selected == (sts & DrawItemState.Selected));   //選択行か
            var odd = (idx % 2 == 1);                                               //奇数行か
            var fore = Brushes.WhiteSmoke;                                          //偶数行の背景色
            var bak = Brushes.LightGray;                                            //奇数行の背景色

            e.DrawBackground();                                                     //背景描画

            //奇数項目の背景色を変える（選択行は除く）
            if (odd && !sel) {
                e.Graphics.FillRectangle(bak, bnd);
            } else if (!odd && !sel) {
                e.Graphics.FillRectangle(fore, bnd);
            }

            //文字を描画
            e.Graphics.DrawString(txt, fnt, bsh, bnd);
        }

        //urlが有効かどうかの判別
        public static bool IsValidUrl(string url) {
            Uri? uriResult;
            return Uri.TryCreate(url, UriKind.Absolute, out uriResult) &&
                    (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            //ファイル保存(未完成)
            try {
                using (var favorite = XmlWriter.Create("FavoriteContents.xml")) {
                    var serializer = new XmlSerializer(urlDict.GetType());
                    serializer.Serialize(favorite, urlDict);
                }
            }
            catch (Exception ex) {
                tsslbMessage.Text = "ファイル書き出しエラー";
                MessageBox.Show(ex.Message);
            }
        }
    }
}
