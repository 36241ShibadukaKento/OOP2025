namespace Exercise01_FormApp {
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
            button1 = new Button();
            toolStrip1 = new ToolStrip();
            toolStripLabel1 = new ToolStripLabel();
            textBox1 = new TextBox();
            button2 = new Button();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "表示";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = DockStyle.Bottom;
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel1 });
            toolStrip1.Location = new Point(0, 388);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(550, 25);
            toolStrip1.TabIndex = 2;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(86, 22);
            toolStripLabel1.Text = "toolStripLabel1";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 52);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(526, 320);
            textBox1.TabIndex = 3;
            // 
            // button2
            // 
            button2.Location = new Point(104, 12);
            button2.Name = "button2";
            button2.Size = new Size(88, 23);
            button2.TabIndex = 4;
            button2.Text = "テキストの消去";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(550, 413);
            Controls.Add(button2);
            Controls.Add(textBox1);
            Controls.Add(toolStrip1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabel1;
        private TextBox textBox1;
        private Button button2;
    }
}
