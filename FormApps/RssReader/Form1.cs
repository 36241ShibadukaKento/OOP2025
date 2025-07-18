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

        //タイトルからページの表示
        private void lbTitles_Click(object sender, EventArgs e) {
            wvRssLink.Source = new Uri(items[ lbTitles.SelectedIndex ].Link);
        }

        private void back_Click(object sender, EventArgs e) {
            if (this.wvRssLink != null && this.wvRssLink.CanGoBack) this.wvRssLink.GoBack();
        }

        private void advance_Click(object sender, EventArgs e) {
            if (this.wvRssLink != null && this.wvRssLink.CanGoForward) this.wvRssLink.GoForward();
        }
    }
}
