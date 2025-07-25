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

            //�R���{�{�b�N�X�̏����ݒ�
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
                tsslbMessage.Text = "";

            }
            catch (Exception) {
                tsslbMessage.Text = "�L����URL������܂���";
                return;
            }
        }

        //�^�C�g������y�[�W�̕\��
        private void lbTitles_Click(object sender, EventArgs e) {
            if (items is null || lbTitles.SelectedItem is null) {
                return;
            } else {
                wvRssLink.Source = new Uri(items[lbTitles.SelectedIndex].Link);
                tsslbMessage.Text = "";

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
            tsslbMessage.Text = "";

        }

        //�}�X�N����
        private void checkMoves() {
            back.Enabled = wvRssLink.CanGoBack;
            advance.Enabled = wvRssLink.CanGoForward;
        }

        //���C�ɓ���o�^
        private void btFavorite_Click(object sender, EventArgs e) {
            //���o�^�̖��O��URL���L������Ă���̏ꍇ�̂ݓo�^
            if (IsValidUrl(cbUrl.Text)) {
                if (urlDict.ContainsKey(tbName.Text) || urlDict.ContainsValue(cbUrl.Text) ||
                    urlDict.ContainsKey(cbUrl.Text) || cbUrl.Text == "") {
                    if (urlDict.ContainsKey(tbName.Text)) {
                        tsslbMessage.Text = "���Ɏg�p����Ă��閼�O�ł�";
                    }
                    if (urlDict.ContainsValue(cbUrl.Text) || urlDict.ContainsKey(cbUrl.Text)) {
                        tsslbMessage.Text = "���ɓo�^����Ă���URL�ł�";
                    }
                } else {
                    //���̂��L������Ă��Ȃ��ꍇ��URL�𖼏̂Ƃ��ĕۑ�
                    if (tbName.Text == "") {
                        tbName.Text = cbUrl.Text;
                    }
                    urlDict.Add(tbName.Text, cbUrl.Text);
                    cbUrl.DataSource = urlDict.Select(k => k.Key).ToList();
                    cbUrl.Text = string.Empty;
                    tbName.Text = string.Empty; //�o�^��ɃR���{�{�b�N�X�A�e�L�X�g�{�b�N�X�̕\����������
                    MessageBox.Show("�o�^���܂����B");
                    tsslbMessage.Text = "";

                }
            } else {
                tsslbMessage.Text = "�L����URL�ł���܂���";
            }
        }

        //���C�ɓ���̍폜
        private void btDelete_Click(object sender, EventArgs e) {
            //���݃R���{�{�b�N�X����I������Ă�����̂��폜
            if (!urlDict.ContainsKey(cbUrl.Text) || cbUrl.Text == "") {
                if (!urlDict.ContainsKey(cbUrl.Text)) {
                    tsslbMessage.Text = "�o�^����Ă��Ȃ�URL�ł�";
                }
            } else {
                urlDict.Remove(cbUrl.SelectedItem.ToString());
                cbUrl.DataSource = urlDict.Select(k => k.Key).ToList();
                cbUrl.Text = string.Empty;
                tbName.Text = string.Empty; //�폜��ɃR���{�{�b�N�X�A�e�L�X�g�{�b�N�X�̕\����������
                MessageBox.Show("�폜���܂����B");
                tsslbMessage.Text = "";

            }
        }

        //�R���{�{�b�N�X�Ɋi�[����Ă��镶����URL���ǂ����̔���
        private string getRssUrl(string url) {
            if (urlDict.ContainsKey(url)) {
                return urlDict[url];
            }
            return url;
        }

        //�F�ݒ�
        private void lbTitles_DrawItem(object sender, DrawItemEventArgs e) {
            var idx = e.Index;                                                      //�`��Ώۂ̍s
            if (idx == -1) return;                                                  //�͈͊O�Ȃ牽�����Ȃ�
            var sts = e.State;                                                      //�Z���̏��
            var fnt = e.Font;                                                       //�t�H���g
            var _bnd = e.Bounds;                                                    //�`��͈�(�I���W�i��)
            var bnd = new RectangleF(_bnd.X, _bnd.Y, _bnd.Width, _bnd.Height);      //�`��͈�(�`��p)
            var txt = (string)lbTitles.Items[idx];                                  //���X�g�{�b�N�X���̕���
            var bsh = new SolidBrush(lbTitles.ForeColor);                           //�����F
            var sel = (DrawItemState.Selected == (sts & DrawItemState.Selected));   //�I���s��
            var odd = (idx % 2 == 1);                                               //��s��
            var fore = Brushes.WhiteSmoke;                                          //�����s�̔w�i�F
            var bak = Brushes.LightGray;                                            //��s�̔w�i�F

            e.DrawBackground();                                                     //�w�i�`��

            //����ڂ̔w�i�F��ς���i�I���s�͏����j
            if (odd && !sel) {
                e.Graphics.FillRectangle(bak, bnd);
            } else if (!odd && !sel) {
                e.Graphics.FillRectangle(fore, bnd);
            }

            //������`��
            e.Graphics.DrawString(txt, fnt, bsh, bnd);
        }

        //url���L�����ǂ����̔���
        public static bool IsValidUrl(string url) {
            Uri? uriResult;
            return Uri.TryCreate(url, UriKind.Absolute, out uriResult) &&
                    (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            //�t�@�C���ۑ�(������)
            try {
                using (var favorite = XmlWriter.Create("FavoriteContents.xml")) {
                    var serializer = new XmlSerializer(urlDict.GetType());
                    serializer.Serialize(favorite, urlDict);
                }
            }
            catch (Exception ex) {
                tsslbMessage.Text = "�t�@�C�������o���G���[";
                MessageBox.Show(ex.Message);
            }
        }
    }
}
