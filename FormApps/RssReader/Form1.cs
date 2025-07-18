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

                //RSS����͂��ĕK�v�ȗv�f���擾
                items = xdoc.Root.Descendants("item")
                     .Select(x => new ItemData {
                         Title = (string?)x.Element("title"),
                         Link = (string?)x.Element("link"),
                     }).ToList();
                setCombo(tbUrl.Text);
            }

            //���X�g�{�b�N�X�ɕ\��
            lbTitles.Items.Clear();
            items.ForEach(item => lbTitles.Items.Add(item.Title));
        }

        //�^�C�g������y�[�W�̕\��
        private void lbTitles_Click(object sender, EventArgs e) {
                wvRssLink.Source = new Uri(items[lbTitles.SelectedIndex].Link);
        }

        //�y�[�W��1�߂�
        private void back_Click(object sender, EventArgs e) {
            if (this.wvRssLink != null && this.wvRssLink.CanGoBack) this.wvRssLink.GoBack();
        }

        //�y�[�W��1�i�߂�
        private void advance_Click(object sender, EventArgs e) {
            if (this.wvRssLink != null && this.wvRssLink.CanGoForward) this.wvRssLink.GoForward();
        }

        //�R���{�{�b�N�X�Ɍ���������\��
        private void setCombo(string pageName) {
            //���ɓo�^�ς݂��m�F
            if (tbUrl.Items.Contains(pageName) || pageName == "") {

            } else {
                //���o�^�̏ꍇ�o�^
                tbUrl.Items.Add(pageName);
            }
        }
    }
}
