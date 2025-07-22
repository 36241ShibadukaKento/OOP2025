namespace RssReader {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            tbUrl = new ComboBox();
            btRssGet = new Button();
            lbTitles = new ListBox();
            wvRssLink = new Microsoft.Web.WebView2.WinForms.WebView2();
            back = new Button();
            advance = new Button();
            ((System.ComponentModel.ISupportInitialize)wvRssLink).BeginInit();
            SuspendLayout();
            // 
            // tbUrl
            // 
            tbUrl.BackColor = SystemColors.ActiveCaption;
            tbUrl.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            tbUrl.Location = new Point(123, 19);
            tbUrl.Name = "tbUrl";
            tbUrl.Size = new Size(467, 29);
            tbUrl.TabIndex = 0;
            // 
            // btRssGet
            // 
            btRssGet.BackColor = SystemColors.ButtonFace;
            btRssGet.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btRssGet.Location = new Point(596, 19);
            btRssGet.Name = "btRssGet";
            btRssGet.Size = new Size(75, 29);
            btRssGet.TabIndex = 1;
            btRssGet.Text = "取得";
            btRssGet.UseVisualStyleBackColor = false;
            btRssGet.Click += btRssGet_Click;
            // 
            // lbTitles
            // 
            lbTitles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbTitles.BackColor = SystemColors.ActiveBorder;
            lbTitles.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lbTitles.FormattingEnabled = true;
            lbTitles.ItemHeight = 20;
            lbTitles.Location = new Point(12, 103);
            lbTitles.Name = "lbTitles";
            lbTitles.Size = new Size(724, 184);
            lbTitles.TabIndex = 2;
            lbTitles.Click += lbTitles_Click;
            // 
            // wvRssLink
            // 
            wvRssLink.AllowExternalDrop = true;
            wvRssLink.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            wvRssLink.BackColor = SystemColors.AppWorkspace;
            wvRssLink.CreationProperties = null;
            wvRssLink.DefaultBackgroundColor = Color.White;
            wvRssLink.ForeColor = Color.Black;
            wvRssLink.Location = new Point(12, 302);
            wvRssLink.Name = "wvRssLink";
            wvRssLink.Size = new Size(724, 296);
            wvRssLink.TabIndex = 3;
            wvRssLink.ZoomFactor = 1D;

            wvRssLink.SourceChanged += wvRssLink_SourceChanged;
            // 
            // back
            // 
            back.Location = new Point(12, 16);
            back.Name = "back";
            back.Size = new Size(43, 32);
            back.TabIndex = 4;
            back.Text = "<<";
            back.UseVisualStyleBackColor = true;
            back.Click += back_Click;
            // 
            // advance
            // 
            advance.Location = new Point(61, 16);
            advance.Name = "advance";
            advance.Size = new Size(43, 32);
            advance.TabIndex = 5;
            advance.Text = ">>";
            advance.UseVisualStyleBackColor = true;
            advance.Click += advance_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(748, 618);
            Controls.Add(advance);
            Controls.Add(back);
            Controls.Add(wvRssLink);
            Controls.Add(lbTitles);
            Controls.Add(btRssGet);
            Controls.Add(tbUrl);
            Name = "Form1";
            Text = "RSSリーダ";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)wvRssLink).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox tbUrl;
        private Button btRssGet;
        private ListBox lbTitles;
        private Microsoft.Web.WebView2.WinForms.WebView2 wvRssLink;
        private Button back;
        private Button advance;
    }
}
