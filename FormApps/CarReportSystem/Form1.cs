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

        //�摜�̑I���A�\��
        private void btPicOpen_Click(object sender, EventArgs e) {
            if (ofdPicFileOpen.ShowDialog() == DialogResult.OK) {
                pbPicture.Image = Image.FromFile(ofdPicFileOpen.FileName);
            }
        }

        //�摜�̍폜
        private void btPicDelete_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }

        //�L�^�̒ǉ�
        private void btRecordAdd_Click(object sender, EventArgs e) {
            tsslbMessage.Text = "";
            if (cbAuthor.Text == "" || cbCarName.Text == "") {
                tsslbMessage.Text = "�L�^�ҁA�Ԗ��������͂ł�";
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

        //���W�I�{�^���̌��ʂ��A��
        private CarReport.MakerGroup getRadioBottomMaker() {
            if (rbToyota.Checked) {
                return CarReport.MakerGroup.�g���^;
            } else if (rbNissan.Checked) {
                return CarReport.MakerGroup.���Y;
            } else if (rbHonda.Checked) {
                return CarReport.MakerGroup.�z���_;
            } else if (rbSubaru.Checked) {
                return CarReport.MakerGroup.�X�o��;
            } else if (rbImport.Checked) {
                return CarReport.MakerGroup.�A����;
            } else if (rbOther.Checked) {
                return CarReport.MakerGroup.���̑�;
            }
            return CarReport.MakerGroup.���L��;
        }

        //���͍��ڂ��N���A
        private void inputItmsAllClear() {
            dtpDate.Value = DateTime.Today;
            cbAuthor.Text = string.Empty;

            rbOther.Checked = true;
            rbOther.Checked = false;

            cbCarName.Text = string.Empty;
            tbReport.Text = string.Empty;
            pbPicture.Image = null;
        }

        //�ꗗ����I�����ĕ\��
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

        //�w�肵�����[�J�[�̃��W�I�{�^�����Z�b�g
        private void setRadioButtomMaker(CarReport.MakerGroup targetMaker) {
            switch (targetMaker) {
                case CarReport.MakerGroup.�g���^:
                    rbToyota.Checked = true;
                    break;
                case CarReport.MakerGroup.���Y:
                    rbNissan.Checked = true;
                    break;
                case CarReport.MakerGroup.�z���_:
                    rbHonda.Checked = true;
                    break;
                case CarReport.MakerGroup.�X�o��:
                    rbSubaru.Checked = true;
                    break;
                case CarReport.MakerGroup.�A����:
                    rbImport.Checked = true;
                    break;
                case CarReport.MakerGroup.���̑�:
                    rbOther.Checked = true;
                    break;
            }
        }

        //�L�^�҂̗������R���{�{�b�N�X�֓o�^
        private void setCbAuthor(string author) {
            //���ɓo�^�ς݂��m�F
            if (cbAuthor.Items.Contains(author) || author == "") {

            } else {
                //���o�^�̏ꍇ�o�^
                cbAuthor.Items.Add(author);
            }
        }

        //�Ԗ��̗������R���{�{�b�N�X�֓o�^
        private void setCbCarName(string carName) {
            //���ɓo�^�ς݂��m�F
            if (cbCarName.Items.Contains(carName) || carName == "") {

            } else {
                //���o�^�̏ꍇ�o�^
                cbCarName.Items.Add(carName);
            }
        }

        /*�V�K���͂̃C�x���g�p���h��*/
        private void btNewRecord_Click(object sender, EventArgs e) {
            inputItmsAllClear();
        }

        /*�C���̃C�x���g�p���h��*/
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
                // dgvRecord.Refresh(); //�f�[�^�O���b�h�r���[�̍X�V
            }
        }

        /*�폜�̃C�x���g�p���h��*/
        private void btRecordDelete_Click(object sender, EventArgs e) {
            //�l��null�̏ꍇ �� �I������Ă��Ȃ��ꍇ �͏������s��Ȃ�
            if (dgvRecord.CurrentCell is null || !dgvRecord.CurrentRow.Selected) {

            } else {
                listCarReports.RemoveAt(dgvRecord.CurrentRow.Index);
            }
        }

        /* �t�@�C�� > �I�� �̃C�x���g�p���h��*/
        private void tsmiExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        /* �w���v > ���̃A�v���ɂ��� �̃C�x���g�p���h��*/
        private void tsmiAbout_Click(object sender, EventArgs e) {
            fmVersion fmv = new fmVersion();
            fmv.ShowDialog();
        }

        /* �t�@�C�� > �F�ݒ� �̃C�x���g�p���h��*/
        private void �F�ݒ�ToolStripMenuItem_Click(object sender, EventArgs e) {
            if (cdColor.ShowDialog() == DialogResult.OK) {
                this.BackColor = cdColor.Color;
            }
        }

        //�ꗗ�\�������݂ɐF�ύX
        private void Form1_Load(object sender, EventArgs e) {
            inputItmsAllClear();
            //���݂ɕύX
            dgvRecord.DefaultCellStyle.BackColor = Color.LightGray;
            dgvRecord.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
        }

        //�t�@�C���I�[�v��
        private void reportOpenFile() {
            if (ofdReportFileOpen.ShowDialog() == DialogResult.OK) {
                try {
                    //�t�V���A�����Ńo�C�i���`������荞��
#pragma warning disable SYSLIB0011 // �^�܂��̓����o�[�����^���ł�
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011 // �^�܂��̓����o�[�����^���ł�
                    using (FileStream fs = File.Open(ofdReportFileOpen.FileName, FileMode.Open, FileAccess.Read)) {

                        listCarReports = (BindingList<CarReport>)bf.Deserialize(fs);
                        dgvRecord.DataSource = listCarReports;

                        cbAuthor.Items.Clear();
                        cbCarName.Items.Clear();
                        //�R���{�{�b�N�X�Ɋi�[
                        foreach (var report in listCarReports) {
                            setCbAuthor(report.Author);
                            setCbCarName(report.CarName);
                        }
                    }
                }
                catch (Exception) {
                    tsslbMessage.Text = "�t�@�C���`�����Ⴂ�܂�";
                }
            }
        }

        //�t�@�C���Z�[�u
        private void reportSaveFile() {
            if (sfdReportFileSave.ShowDialog() == DialogResult.OK) {
                try {
                    //�o�C�i���`���ŃV���A����
#pragma warning disable SYSLIB0011
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011

                    using (FileStream fs = File.Open(
                                    sfdReportFileSave.FileName, FileMode.Create)) {

                        bf.Serialize(fs, listCarReports);
                    }
                }
                catch (Exception ex) {
                    tsslbMessage.Text = "�t�@�C�������o���G���[";
                    MessageBox.Show(ex.Message);
                }
            }
        }
       
        /* �t�@�C�� > �ۑ��̃C�x���g�p���h��*/
        private void �ۑ�ToolStripMenuItem_Click(object sender, EventArgs e) {
            reportSaveFile();
        }
       
        /* �t�@�C�� > �J���̃C�x���g�p���h��*/
        private void �J��ToolStripMenuItem_Click(object sender, EventArgs e) {
            reportOpenFile();
        }
    }
}