using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise01_FormApp {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        private async void button1_Click(object sender, EventArgs e) {
            toolStripLabel1.Text = "“Ç‚İ‚İ’†";
            var filePath = "C://Users//infosys//source//repos//OOP2025//Chapter14//‰‰K–â‘è//Exercise01_FormApp//‘–‚êƒƒƒX.txt";
            using (StreamReader reader = new StreamReader(filePath)) {
                string? line;
                while ((line = await reader.ReadLineAsync()) != null) {
                    textBox1.Text += Environment.NewLine + line;
                    await Task.Delay(10);
                }
                toolStripLabel1.Text = "“Ç‚İ‚İI—¹";
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            textBox1.Text = string.Empty;
        }
    }
}