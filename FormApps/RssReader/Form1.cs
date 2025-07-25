using System.Net;
using System.Security.Policy;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace RssReader {
    public partial class Form1 : Form {

        private List<ItemData> items;

        Dictionary<string, string> urlDict = new Dictionary<string, string> {
            {"��v", "https://news.yahoo.co.jp/rss/topics/top-picks.xml"},
            {"�G���^��","https://news.yahoo.co.jp/rss/topics/entertainment.xml" }
        };

        public Form1() {
            InitializeComponent();

        }

        //�A�v�����N�������Ƃ��ɌĂ΂��
        private void Form1_Load(object sender, EventArgs e) {
            //�}�X�N�������s��
            back.Enabled = false;
            advance.Enabled = false;

            cbUrl.DataSource = urlDict.Select(k => k.Key).ToList();
            cbUrl.Text = string.Empty;
        }

        //�擾
        private async void btRssGet_Click(object sender, EventArgs e) {
            try {
                using (var hc = new HttpClient()) {

                    XDocument xdoc = XDocument.Parse(await hc.GetStringAsync(getRssUrl(cbUrl.Text)));

                    //RSS����͂��ĕK�v�ȗv�f���擾
                    items = xdoc.Root.Descendants("item")
                         .Select(x => new ItemData {
                             Title = (string?)x.Element("title"),
                             Link = (string?)x.Element("link"),
                         }).ToList();

                }

                //���X�g�{�b�N�X�ɕ\��
                lbTitles.Items.Clear();
                items.ForEach(item => lbTitles.Items.Add(item.Title));
            }
            catch (Exception) {
                return;
            }
        }

        //�^�C�g������y�[�W�̕\��
        private void lbTitles_Click(object sender, EventArgs e) {
            if (items is null || lbTitles.SelectedItem is null) {
                return;
            } else {
                wvRssLink.Source = new Uri(items[lbTitles.SelectedIndex].Link);
            }
        }

        //�y�[�W��1�߂�
        private void back_Click(object sender, EventArgs e) {
            if (this.wvRssLink != null && this.wvRssLink.CanGoBack) this.wvRssLink.GoBack();
        }

        //�y�[�W��1�i�߂�
        private void advance_Click(object sender, EventArgs e) {
            if (this.wvRssLink != null && this.wvRssLink.CanGoForward) this.wvRssLink.GoForward();
        }

        //�y�[�W���؂�ւ��Ƃ��ɌĂ΂��
        private void wvRssLink_SourceChanged(object sender, Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs e) {
            checkMoves();
        }

        //�}�X�N����
        private void checkMoves() {
            back.Enabled = wvRssLink.CanGoBack;
            advance.Enabled = wvRssLink.CanGoForward;
        }

        //���C�ɓ���o�^
        private void btFavorite_Click(object sender, EventArgs e) {
            //���́AURL�Ƃ��ɖ��o�^����URL���L������Ă���̏ꍇ�̂ݓo�^
            if (urlDict.ContainsKey(tbName.Text) || urlDict.ContainsValue(cbUrl.Text) || cbUrl.Text == "") {

            } else {
                //���̂��L������Ă��Ȃ��ꍇ��URL�𖼏̂Ƃ��ĕۑ�
                if (tbName.Text == "") {
                    tbName.Text = cbUrl.Text;
                }
                urlDict.Add(tbName.Text, cbUrl.Text);
                cbUrl.DataSource = urlDict.Select(k => k.Key).ToList();
                cbUrl.Text = string.Empty;
                tbName.Text = string.Empty; //�o�^��ɃR���{�{�b�N�X�A�e�L�X�g�{�b�N�X�̕\����������
            }
        }

        //���C�ɓ���̍폜
        private void btDelete_Click(object sender, EventArgs e) {
            if (urlDict.ContainsKey(cbUrl.Text) || cbUrl.Text == "") {

            } else {
                //�o�^�ς݂̏ꍇ�폜


                cbUrl.Text = string.Empty;
                tbName.Text = string.Empty; //�o�^��ɃR���{�{�b�N�X�A�e�L�X�g�{�b�N�X�̕\����������
            }
        }

        //�R���{�{�b�N�X�Ɋi�[����Ă��镶����URL���ǂ����̔���
        private string getRssUrl(string url) {
            if (urlDict.ContainsKey(url)) {
                return urlDict[url];
            }
            return url;
        }
    }
}
