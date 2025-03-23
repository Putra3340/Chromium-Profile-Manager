namespace Chromium_Profile_Manager
{
    partial class ChromiumInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            comboBox1 = new ComboBox();
            label4 = new Label();
            progressBar1 = new ProgressBar();
            label5 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(167, 343);
            button1.Name = "button1";
            button1.Size = new Size(159, 39);
            button1.TabIndex = 0;
            button1.Text = "Install with Latest Version";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.HotTrack;
            label1.Location = new Point(42, 52);
            label1.Name = "label1";
            label1.Size = new Size(259, 31);
            label1.TabIndex = 1;
            label1.Text = "Chromium Installer";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(76, 96);
            label2.Name = "label2";
            label2.Size = new Size(181, 15);
            label2.TabIndex = 2;
            label2.Text = "Create a new Chromium Browser";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(42, 147);
            label3.Name = "label3";
            label3.Size = new Size(73, 15);
            label3.TabIndex = 3;
            label3.Text = "Pick a Name";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(42, 176);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(259, 23);
            textBox1.TabIndex = 4;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(42, 293);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(259, 23);
            comboBox1.TabIndex = 5;
            comboBox1.Text = "Select a Version";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(42, 262);
            label4.Name = "label4";
            label4.Size = new Size(88, 15);
            label4.TabIndex = 6;
            label4.Text = "Select a Version";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(42, 398);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(259, 23);
            progressBar1.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(85, 432);
            label5.Name = "label5";
            label5.Size = new Size(167, 15);
            label5.TabIndex = 8;
            label5.Text = "Download is Still In Progress ...";
            // 
            // ChromiumInstaller
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(338, 458);
            Controls.Add(label5);
            Controls.Add(progressBar1);
            Controls.Add(label4);
            Controls.Add(comboBox1);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "ChromiumInstaller";
            Text = "ChromiumInstaller";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private ComboBox comboBox1;
        private Label label4;
        private ProgressBar progressBar1;
        private Label label5;
    }
}