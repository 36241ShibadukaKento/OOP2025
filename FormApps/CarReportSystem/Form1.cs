using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Data.Common;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace CarReportSystem {
    public partial class Form1 : Form {
        BindingList<CarReport> listCarReports = new BindingList<CarReport>();

        public Form1() {
            InitializeComponent();
            dgvRecord.DataSource = listCarReports;
        }

        //画像の選択、表示
        private void btPicOpen_Click(object sender, EventArgs e) {
            if (ofdPicFileOpen.ShowDialog() == DialogResult.OK) {
                pbPicture.Image = Image.FromFile(ofdPicFileOpen.FileName);
            }
        }

        //画像の削除
        private void btPicDelete_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }

        //記録の追加
        private void btRecordAdd_Click(object sender, EventArgs e) {
            tsslbMessage.Text = "";
            if (cbAuthor.Text == "" || cbCarName.Text == "") {
                tsslbMessage.Text = "記録者、車名が未入力です";
            } else {
                var carReport = new CarReport {
                    Date = dtpDate.Value.Date,
                    Author = cbAuthor.Text,
                    Maker = getRadioBottomMaker(),
                    CarName = cbCarName.Text,
                    Report = tbReport.Text,
                    Picture = pbPicture.Image
                };

                listCarReports.Add(carReport);
                setCbAuthor(cbAuthor.Text);
                setCbCarName(cbCarName.Text);
                inputItmsAllClear();
            }
        }

        //ラジオボタンの結果を帰す
        private CarReport.MakerGroup getRadioBottomMaker() {
            if (rbToyota.Checked) {
                return CarReport.MakerGroup.トヨタ;
            } else if (rbNissan.Checked) {
                return CarReport.MakerGroup.日産;
            } else if (rbHonda.Checked) {
                return CarReport.MakerGroup.ホンダ;
            } else if (rbSubaru.Checked) {
                return CarReport.MakerGroup.スバル;
            } else if (rbImport.Checked) {
                return CarReport.MakerGroup.輸入車;
            } else if (rbOther.Checked) {
                return CarReport.MakerGroup.その他;
            }
            return CarReport.MakerGroup.未記入;
        }

        //入力項目をクリア
        private void inputItmsAllClear() {
            dtpDate.Value = DateTime.Today;
            cbAuthor.Text = string.Empty;

            rbOther.Checked = true;
            rbOther.Checked = false;

            cbCarName.Text = string.Empty;
            tbReport.Text = string.Empty;
            pbPicture.Image = null;
        }

        //一覧から選択して表示
        private void dgvRecord_Click(object sender, EventArgs e) {
            if (dgvRecord.CurrentRow is null) {

            } else {
                dtpDate.Value = (DateTime)dgvRecord.CurrentRow.Cells["Date"].Value;
                cbAuthor.Text = (string)dgvRecord.CurrentRow.Cells["Author"].Value;
                setRadioButtomMaker((CarReport.MakerGroup)dgvRecord.CurrentRow.Cells["Maker"].Value);
                cbCarName.Text = (string)dgvRecord.CurrentRow.Cells["CarName"].Value;
                tbReport.Text = (string)dgvRecord.CurrentRow.Cells["Report"].Value;
                pbPicture.Image = (Image)dgvRecord.CurrentRow.Cells["Picture"].Value;
            }
        }

        //指定したメーカーのラジオボタンをセット
        private void setRadioButtomMaker(CarReport.MakerGroup targetMaker) {
            switch (targetMaker) {
                case CarReport.MakerGroup.トヨタ:
                    rbToyota.Checked = true;
                    break;
                case CarReport.MakerGroup.日産:
                    rbNissan.Checked = true;
                    break;
                case CarReport.MakerGroup.ホンダ:
                    rbHonda.Checked = true;
                    break;
                case CarReport.MakerGroup.スバル:
                    rbSubaru.Checked = true;
                    break;
                case CarReport.MakerGroup.輸入車:
                    rbImport.Checked = true;
                    break;
                case CarReport.MakerGroup.その他:
                    rbOther.Checked = true;
                    break;
            }
        }

        //記録者の履歴をコンボボックスへ登録
        private void setCbAuthor(string author) {
            //既に登録済みか確認
            if (cbAuthor.Items.Contains(author) || author == "") {

            } else {
                //未登録の場合登録
                cbAuthor.Items.Add(author);
            }
        }

        //車名の履歴をコンボボックスへ登録
        private void setCbCarName(string carName) {
            //既に登録済みか確認
            if (cbCarName.Items.Contains(carName) || carName == "") {

            } else {
                //未登録の場合登録
                cbCarName.Items.Add(carName);
            }
        }

        /*新規入力のイベントパンドラ*/
        private void btNewRecord_Click(object sender, EventArgs e) {
            inputItmsAllClear();
        }

        /*修正のイベントパンドラ*/
        private void btRecordModify_Click(object sender, EventArgs e) {
            if (dgvRecord.Rows.Count == 0) {

            } else {
                var carReport = new CarReport {
                    Date = dtpDate.Value.Date,
                    Author = cbAuthor.Text,
                    Maker = getRadioBottomMaker(),
                    CarName = cbCarName.Text,
                    Report = tbReport.Text,
                    Picture = pbPicture.Image
                };
                listCarReports[dgvRecord.CurrentCell.RowIndex] = carReport;
                // dgvRecord.Refresh(); //データグリッドビューの更新
            }
        }

        /*削除のイベントパンドラ*/
        private void btRecordDelete_Click(object sender, EventArgs e) {
            //値がnullの場合 と 選択されていない場合 は処理を行わない
            if (dgvRecord.CurrentCell is null || !dgvRecord.CurrentRow.Selected) {

            } else {
                listCarReports.RemoveAt(dgvRecord.CurrentRow.Index);
            }
        }

        /* ファイル > 終了 のイベントパンドラ*/
        private void tsmiExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        /* ヘルプ > このアプリについて のイベントパンドラ*/
        private void tsmiAbout_Click(object sender, EventArgs e) {
            fmVersion fmv = new fmVersion();
            fmv.ShowDialog();
        }

        /* ファイル > 色設定 のイベントパンドラ*/
        private void 色設定ToolStripMenuItem_Click(object sender, EventArgs e) {
            if (cdColor.ShowDialog() == DialogResult.OK) {
                this.BackColor = cdColor.Color;
            }
        }

        //一覧表示を交互に色変更
        private void Form1_Load(object sender, EventArgs e) {
            inputItmsAllClear();
            //交互に変更
            dgvRecord.DefaultCellStyle.BackColor = Color.LightGray;
            dgvRecord.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
        }

        //ファイルオープン
        private void reportOpenFile() {
            if (ofdReportFileOpen.ShowDialog() == DialogResult.OK) {
                try {
                    //逆シリアル化でバイナリ形式を取り込む
#pragma warning disable SYSLIB0011 // 型またはメンバーが旧型式です
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011 // 型またはメンバーが旧型式です
                    using (FileStream fs = File.Open(ofdReportFileOpen.FileName, FileMode.Open, FileAccess.Read)) {

                        listCarReports = (BindingList<CarReport>)bf.Deserialize(fs);
                        dgvRecord.DataSource = listCarReports;

                        cbAuthor.Items.Clear();
                        cbCarName.Items.Clear();
                        //コンボボックスに格納
                        foreach (var report in listCarReports) {
                            setCbAuthor(report.Author);
                            setCbCarName(report.CarName);
                        }
                    }
                }
                catch (Exception) {
                    tsslbMessage.Text = "ファイル形式が違います";
                }
            }
        }

        //ファイルセーブ
        private void reportSaveFile() {
            if (sfdReportFileSave.ShowDialog() == DialogResult.OK) {
                try {
                    //バイナリ形式でシリアル化
#pragma warning disable SYSLIB0011
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011

                    using (FileStream fs = File.Open(
                                    sfdReportFileSave.FileName, FileMode.Create)) {

                        bf.Serialize(fs, listCarReports);
                    }
                }
                catch (Exception ex) {
                    tsslbMessage.Text = "ファイル書き出しエラー";
                    MessageBox.Show(ex.Message);
                }
            }
        }
       
        /* ファイル > 保存のイベントパンドラ*/
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e) {
            reportSaveFile();
        }
       
        /* ファイル > 開くのイベントパンドラ*/
        private void 開くToolStripMenuItem_Click(object sender, EventArgs e) {
            reportOpenFile();
        }
    }
}