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
            tbUrl = new TextBox();
            btRssGet = new Button();
            lbTitles = new ListBox();
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            SuspendLayout();
            // 
            // tbUrl
            // 
            tbUrl.BackColor = SystemColors.ActiveCaption;
            tbUrl.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            tbUrl.Location = new Point(12, 12);
            tbUrl.Name = "tbUrl";
            tbUrl.Size = new Size(467, 29);
            tbUrl.TabIndex = 0;
            // 
            // btRssGet
            // 
            btRssGet.BackColor = SystemColors.ButtonFace;
            btRssGet.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btRssGet.Location = new Point(485, 12);
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
            lbTitles.Location = new Point(12, 57);
            lbTitles.Name = "lbTitles";
            lbTitles.Size = new Size(547, 184);
            lbTitles.TabIndex = 2;
            lbTitles.Click += lbTitles_Click;
            // 
            // webView21
            // 
            webView21.AllowExternalDrop = true;
            webView21.BackColor = SystemColors.AppWorkspace;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.White;
            webView21.Location = new Point(12, 260);
            webView21.Name = "webView21";
            webView21.Size = new Size(548, 351);
            webView21.TabIndex = 3;
            webView21.ZoomFactor = 1D;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(577, 618);
            Controls.Add(webView21);
            Controls.Add(lbTitles);
            Controls.Add(btRssGet);
            Controls.Add(tbUrl);
            Name = "Form1";
            Text = "RSSリーダ";
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbUrl;
        private Button btRssGet;
        private ListBox lbTitles;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
    }
}
