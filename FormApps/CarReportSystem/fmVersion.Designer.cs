﻿namespace CarReportSystem {
    partial class fmVersion {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            btOK = new Button();
            label1 = new Label();
            lbVersion = new Label();
            SuspendLayout();
            // 
            // btOK
            // 
            btOK.FlatStyle = FlatStyle.Flat;
            btOK.Location = new Point(311, 180);
            btOK.Name = "btOK";
            btOK.Size = new Size(94, 46);
            btOK.TabIndex = 0;
            btOK.Text = "OK";
            btOK.UseVisualStyleBackColor = true;
            btOK.Click += btOK_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(208, 30);
            label1.TabIndex = 1;
            label1.Text = "試乗ポート管理システム";
            // 
            // lbVersion
            // 
            lbVersion.AutoSize = true;
            lbVersion.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lbVersion.Location = new Point(309, 19);
            lbVersion.Name = "lbVersion";
            lbVersion.Size = new Size(56, 17);
            lbVersion.TabIndex = 2;
            lbVersion.Text = "Ver.0.0.1";
            // 
            // fmVersion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(417, 238);
            Controls.Add(lbVersion);
            Controls.Add(label1);
            Controls.Add(btOK);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "fmVersion";
            Text = "fmVersion";
            Load += fmVersion_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btOK;
        private Label label1;
        private Label lbVersion;
    }
}