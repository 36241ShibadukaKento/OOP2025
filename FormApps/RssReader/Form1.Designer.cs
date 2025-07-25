﻿namespace RssReader {
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
            cbUrl = new ComboBox();
            btRssGet = new Button();
            lbTitles = new ListBox();
            wvRssLink = new Microsoft.Web.WebView2.WinForms.WebView2();
            back = new Button();
            advance = new Button();
            btFavorite = new Button();
            btDelete = new Button();
            tbName = new TextBox();
            lbName = new Label();
            statusStrip1 = new StatusStrip();
            tsslbMessage = new ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)wvRssLink).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // cbUrl
            // 
            cbUrl.BackColor = SystemColors.ActiveCaption;
            cbUrl.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            cbUrl.Location = new Point(124, 15);
            cbUrl.Margin = new Padding(4);
            cbUrl.Name = "cbUrl";
            cbUrl.Size = new Size(467, 29);
            cbUrl.TabIndex = 0;
            // 
            // btRssGet
            // 
            btRssGet.BackColor = SystemColors.ButtonFace;
            btRssGet.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btRssGet.Location = new Point(599, 15);
            btRssGet.Margin = new Padding(4);
            btRssGet.Name = "btRssGet";
            btRssGet.Size = new Size(75, 29);
            btRssGet.TabIndex = 1;
            btRssGet.Text = "取得";
            btRssGet.UseVisualStyleBackColor = false;
            btRssGet.Click += btRssGet_Click;
            // 
            // lbTitles
            // 
            lbTitles.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lbTitles.BackColor = SystemColors.ActiveBorder;
            lbTitles.DrawMode = DrawMode.OwnerDrawFixed;
            lbTitles.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lbTitles.FormattingEnabled = true;
            lbTitles.ItemHeight = 20;
            lbTitles.Location = new Point(12, 102);
            lbTitles.Margin = new Padding(4);
            lbTitles.Name = "lbTitles";
            lbTitles.Size = new Size(724, 184);
            lbTitles.TabIndex = 2;
            lbTitles.Click += lbTitles_Click;
            lbTitles.DrawItem += lbTitles_DrawItem;
            // 
            // wvRssLink
            // 
            wvRssLink.AllowExternalDrop = true;
            wvRssLink.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            wvRssLink.BackColor = SystemColors.AppWorkspace;
            wvRssLink.CreationProperties = null;
            wvRssLink.DefaultBackgroundColor = Color.LightGray;
            wvRssLink.ForeColor = Color.Black;
            wvRssLink.Location = new Point(12, 293);
            wvRssLink.Margin = new Padding(4);
            wvRssLink.Name = "wvRssLink";
            wvRssLink.Size = new Size(724, 296);
            wvRssLink.TabIndex = 3;
            wvRssLink.ZoomFactor = 1D;
            wvRssLink.SourceChanged += wvRssLink_SourceChanged;
            // 
            // back
            // 
            back.Location = new Point(12, 13);
            back.Margin = new Padding(4);
            back.Name = "back";
            back.Size = new Size(43, 33);
            back.TabIndex = 4;
            back.Text = "<<";
            back.UseVisualStyleBackColor = true;
            back.Click += back_Click;
            // 
            // advance
            // 
            advance.Font = new Font("Yu Gothic UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            advance.Location = new Point(63, 13);
            advance.Margin = new Padding(4);
            advance.Name = "advance";
            advance.Size = new Size(43, 33);
            advance.TabIndex = 5;
            advance.Text = ">>";
            advance.UseVisualStyleBackColor = true;
            advance.Click += advance_Click;
            // 
            // btFavorite
            // 
            btFavorite.BackColor = SystemColors.ButtonFace;
            btFavorite.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btFavorite.Location = new Point(550, 57);
            btFavorite.Margin = new Padding(4);
            btFavorite.Name = "btFavorite";
            btFavorite.Size = new Size(102, 31);
            btFavorite.TabIndex = 6;
            btFavorite.Text = "お気に入り追加";
            btFavorite.UseVisualStyleBackColor = false;
            btFavorite.Click += btFavorite_Click;
            // 
            // btDelete
            // 
            btDelete.BackColor = SystemColors.ButtonFace;
            btDelete.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btDelete.Location = new Point(660, 57);
            btDelete.Margin = new Padding(4);
            btDelete.Name = "btDelete";
            btDelete.Size = new Size(75, 31);
            btDelete.TabIndex = 7;
            btDelete.Text = "削除";
            btDelete.UseVisualStyleBackColor = false;
            btDelete.Click += btDelete_Click;
            // 
            // tbName
            // 
            tbName.BackColor = SystemColors.ActiveCaption;
            tbName.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            tbName.Location = new Point(350, 59);
            tbName.Margin = new Padding(4);
            tbName.Name = "tbName";
            tbName.Size = new Size(192, 29);
            tbName.TabIndex = 8;
            // 
            // lbName
            // 
            lbName.AutoSize = true;
            lbName.BackColor = SystemColors.ActiveBorder;
            lbName.BorderStyle = BorderStyle.Fixed3D;
            lbName.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lbName.Location = new Point(273, 59);
            lbName.Margin = new Padding(4, 0, 4, 0);
            lbName.Name = "lbName";
            lbName.Size = new Size(69, 19);
            lbName.TabIndex = 9;
            lbName.Text = "登録名称 :";
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { tsslbMessage });
            statusStrip1.Location = new Point(0, 597);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(748, 22);
            statusStrip1.TabIndex = 10;
            statusStrip1.Text = "statusStrip1";
            // 
            // tsslbMessage
            // 
            tsslbMessage.Name = "tsslbMessage";
            tsslbMessage.Size = new Size(77, 17);
            tsslbMessage.Text = "tsslbMessage";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(748, 619);
            Controls.Add(statusStrip1);
            Controls.Add(lbName);
            Controls.Add(tbName);
            Controls.Add(btDelete);
            Controls.Add(btFavorite);
            Controls.Add(advance);
            Controls.Add(back);
            Controls.Add(wvRssLink);
            Controls.Add(lbTitles);
            Controls.Add(btRssGet);
            Controls.Add(cbUrl);
            Font = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 128);
            Margin = new Padding(4);
            Name = "Form1";
            Text = "RSSリーダ";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)wvRssLink).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbUrl;
        private Button btRssGet;
        private ListBox lbTitles;
        private Microsoft.Web.WebView2.WinForms.WebView2 wvRssLink;
        private Button back;
        private Button advance;
        private Button btFavorite;
        private Button btDelete;
        private TextBox tbName;
        private Label lbName;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel tsslbMessage;
    }
}
