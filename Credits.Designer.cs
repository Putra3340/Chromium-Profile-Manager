namespace Chromium_Profile_Manager
{
    partial class Credits
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Credits));
            label1 = new Label();
            groupBox1 = new GroupBox();
            label2 = new Label();
            groupBox2 = new GroupBox();
            linkLabel1 = new LinkLabel();
            label3 = new Label();
            label4 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(30, 29);
            label1.Name = "label1";
            label1.Size = new Size(112, 38);
            label1.TabIndex = 0;
            label1.Text = "Credits";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label2);
            groupBox1.Font = new Font("Dubai", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(30, 98);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(580, 166);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "About this Program";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(29, 44);
            label2.MaximumSize = new Size(550, 0);
            label2.Name = "label2";
            label2.Size = new Size(549, 108);
            label2.TabIndex = 0;
            label2.Text = resources.GetString("label2.Text");
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(linkLabel1);
            groupBox2.Font = new Font("Dubai", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(650, 98);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(195, 166);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "About me";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(37, 67);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(124, 40);
            linkLabel1.TabIndex = 0;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Putra3340";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(565, 7);
            label3.Name = "label3";
            label3.Size = new Size(99, 15);
            label3.TabIndex = 3;
            label3.Text = "Assembly Name :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(565, 29);
            label4.Name = "label4";
            label4.Size = new Size(108, 15);
            label4.TabIndex = 4;
            label4.Text = "Assembly Version : ";
            // 
            // Credits
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(857, 294);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Name = "Credits";
            Text = "Credits";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private Label label2;
        private GroupBox groupBox2;
        private LinkLabel linkLabel1;
        private Label label3;
        private Label label4;
    }
}