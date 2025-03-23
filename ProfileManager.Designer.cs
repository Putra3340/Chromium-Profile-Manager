namespace Chromium_Profile_Manager
{
    partial class ProfileManager
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            chrome_tbx = new TextBox();
            chromepath_lbl = new Label();
            apply_button = new Button();
            chromefiledialog = new OpenFileDialog();
            chromebrowse_btn = new Button();
            chromeversion_gridview = new DataGridView();
            groupBox1 = new GroupBox();
            navigateprofile_btn = new Button();
            navigatechrome_btn = new Button();
            label3 = new Label();
            label2 = new Label();
            reset_button = new Button();
            profile_tbx = new TextBox();
            profilepath_lbl = new Label();
            profilebrowse_btn = new Button();
            textBox1 = new TextBox();
            button1 = new Button();
            groupBox2 = new GroupBox();
            duplicateprofile_btn = new Button();
            refreshprofile_btn = new Button();
            renameprofile_btn = new Button();
            addprofile_btn = new Button();
            duplicatechrome_btn = new Button();
            refreshchrome_btn = new Button();
            renamechromeversion_btn = new Button();
            addchromeversion_btn = new Button();
            label1 = new Label();
            chromever_lbl = new Label();
            profile_gridview = new DataGridView();
            dbg_button = new Button();
            profilefolderdialog = new FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)chromeversion_gridview).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)profile_gridview).BeginInit();
            SuspendLayout();
            // 
            // chrome_tbx
            // 
            chrome_tbx.Location = new Point(22, 85);
            chrome_tbx.Name = "chrome_tbx";
            chrome_tbx.Size = new Size(208, 23);
            chrome_tbx.TabIndex = 0;
            chrome_tbx.TextChanged += chrome_tbx_TextChanged;
            // 
            // chromepath_lbl
            // 
            chromepath_lbl.AutoSize = true;
            chromepath_lbl.Location = new Point(22, 57);
            chromepath_lbl.Name = "chromepath_lbl";
            chromepath_lbl.Size = new Size(124, 15);
            chromepath_lbl.TabIndex = 2;
            chromepath_lbl.Text = "Chromium Executable";
            // 
            // apply_button
            // 
            apply_button.Location = new Point(51, 291);
            apply_button.Name = "apply_button";
            apply_button.Size = new Size(267, 23);
            apply_button.TabIndex = 3;
            apply_button.Text = "Apply and Save";
            apply_button.UseVisualStyleBackColor = true;
            apply_button.Click += apply_button_Click;
            // 
            // chromefiledialog
            // 
            chromefiledialog.FileName = "chrome.exe";
            chromefiledialog.Filter = "Executable Files (*.exe)|*.exe";
            chromefiledialog.Title = "Select an Executable File";
            // 
            // chromebrowse_btn
            // 
            chromebrowse_btn.Location = new Point(236, 84);
            chromebrowse_btn.Name = "chromebrowse_btn";
            chromebrowse_btn.Size = new Size(75, 23);
            chromebrowse_btn.TabIndex = 4;
            chromebrowse_btn.Text = "Browse";
            chromebrowse_btn.UseVisualStyleBackColor = true;
            chromebrowse_btn.Click += chromebrowse_btn_Click;
            // 
            // chromeversion_gridview
            // 
            chromeversion_gridview.AllowUserToAddRows = false;
            chromeversion_gridview.AllowUserToDeleteRows = false;
            chromeversion_gridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            chromeversion_gridview.BackgroundColor = SystemColors.ControlLight;
            chromeversion_gridview.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            chromeversion_gridview.Location = new Point(17, 39);
            chromeversion_gridview.MultiSelect = false;
            chromeversion_gridview.Name = "chromeversion_gridview";
            chromeversion_gridview.ReadOnly = true;
            chromeversion_gridview.Size = new Size(342, 150);
            chromeversion_gridview.TabIndex = 5;
            chromeversion_gridview.CellClick += chromeversion_gridview_CellClick;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(navigateprofile_btn);
            groupBox1.Controls.Add(navigatechrome_btn);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(reset_button);
            groupBox1.Controls.Add(profile_tbx);
            groupBox1.Controls.Add(profilepath_lbl);
            groupBox1.Controls.Add(profilebrowse_btn);
            groupBox1.Controls.Add(chrome_tbx);
            groupBox1.Controls.Add(chromepath_lbl);
            groupBox1.Controls.Add(apply_button);
            groupBox1.Controls.Add(chromebrowse_btn);
            groupBox1.Location = new Point(454, 41);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(324, 330);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Current App Configuration";
            // 
            // navigateprofile_btn
            // 
            navigateprofile_btn.Location = new Point(22, 258);
            navigateprofile_btn.Name = "navigateprofile_btn";
            navigateprofile_btn.Size = new Size(172, 23);
            navigateprofile_btn.TabIndex = 12;
            navigateprofile_btn.Text = "Open Profile Directory";
            navigateprofile_btn.UseVisualStyleBackColor = true;
            navigateprofile_btn.Click += navigateprofile_btn_Click;
            // 
            // navigatechrome_btn
            // 
            navigatechrome_btn.Location = new Point(22, 227);
            navigatechrome_btn.Name = "navigatechrome_btn";
            navigatechrome_btn.Size = new Size(172, 23);
            navigatechrome_btn.TabIndex = 11;
            navigatechrome_btn.Text = "Open Chromium Directory";
            navigatechrome_btn.UseVisualStyleBackColor = true;
            navigatechrome_btn.Click += navigatechrome_btn_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 138);
            label3.Name = "label3";
            label3.Size = new Size(29, 15);
            label3.TabIndex = 10;
            label3.Text = "As : ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 30);
            label2.Name = "label2";
            label2.Size = new Size(103, 15);
            label2.TabIndex = 9;
            label2.Text = "Currently Using : ?";
            // 
            // reset_button
            // 
            reset_button.Location = new Point(236, 238);
            reset_button.Name = "reset_button";
            reset_button.Size = new Size(75, 23);
            reset_button.TabIndex = 8;
            reset_button.Text = "Clear";
            reset_button.UseVisualStyleBackColor = true;
            reset_button.Click += reset_button_Click;
            // 
            // profile_tbx
            // 
            profile_tbx.Location = new Point(22, 182);
            profile_tbx.Name = "profile_tbx";
            profile_tbx.Size = new Size(208, 23);
            profile_tbx.TabIndex = 5;
            profile_tbx.TextChanged += profile_tbx_TextChanged;
            // 
            // profilepath_lbl
            // 
            profilepath_lbl.AutoSize = true;
            profilepath_lbl.Location = new Point(22, 164);
            profilepath_lbl.Name = "profilepath_lbl";
            profilepath_lbl.Size = new Size(68, 15);
            profilepath_lbl.TabIndex = 6;
            profilepath_lbl.Text = "Profile Path";
            // 
            // profilebrowse_btn
            // 
            profilebrowse_btn.Location = new Point(236, 182);
            profilebrowse_btn.Name = "profilebrowse_btn";
            profilebrowse_btn.Size = new Size(75, 23);
            profilebrowse_btn.TabIndex = 7;
            profilebrowse_btn.Text = "Browse";
            profilebrowse_btn.UseVisualStyleBackColor = true;
            profilebrowse_btn.Click += profilebrowse_btn_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(454, 385);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(324, 71);
            textBox1.TabIndex = 5;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(562, 468);
            button1.Name = "button1";
            button1.Size = new Size(226, 63);
            button1.TabIndex = 5;
            button1.Text = "Confirm and Exit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(duplicateprofile_btn);
            groupBox2.Controls.Add(refreshprofile_btn);
            groupBox2.Controls.Add(renameprofile_btn);
            groupBox2.Controls.Add(addprofile_btn);
            groupBox2.Controls.Add(duplicatechrome_btn);
            groupBox2.Controls.Add(refreshchrome_btn);
            groupBox2.Controls.Add(renamechromeversion_btn);
            groupBox2.Controls.Add(addchromeversion_btn);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(chromever_lbl);
            groupBox2.Controls.Add(profile_gridview);
            groupBox2.Controls.Add(chromeversion_gridview);
            groupBox2.Location = new Point(56, 41);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(383, 490);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Global Configuration";
            // 
            // duplicateprofile_btn
            // 
            duplicateprofile_btn.Location = new Point(198, 447);
            duplicateprofile_btn.Name = "duplicateprofile_btn";
            duplicateprofile_btn.Size = new Size(75, 23);
            duplicateprofile_btn.TabIndex = 16;
            duplicateprofile_btn.Text = "Duplicate";
            duplicateprofile_btn.UseVisualStyleBackColor = true;
            duplicateprofile_btn.Click += duplicateprofile_btn_Click;
            // 
            // refreshprofile_btn
            // 
            refreshprofile_btn.Location = new Point(284, 447);
            refreshprofile_btn.Name = "refreshprofile_btn";
            refreshprofile_btn.Size = new Size(75, 23);
            refreshprofile_btn.TabIndex = 15;
            refreshprofile_btn.Text = "Refresh";
            refreshprofile_btn.UseVisualStyleBackColor = true;
            refreshprofile_btn.Click += refreshprofile_btn_Click;
            // 
            // renameprofile_btn
            // 
            renameprofile_btn.Location = new Point(108, 447);
            renameprofile_btn.Name = "renameprofile_btn";
            renameprofile_btn.Size = new Size(75, 23);
            renameprofile_btn.TabIndex = 14;
            renameprofile_btn.Text = "Rename";
            renameprofile_btn.UseVisualStyleBackColor = true;
            renameprofile_btn.Click += renameprofile_btn_Click;
            // 
            // addprofile_btn
            // 
            addprofile_btn.Location = new Point(17, 447);
            addprofile_btn.Name = "addprofile_btn";
            addprofile_btn.Size = new Size(75, 23);
            addprofile_btn.TabIndex = 13;
            addprofile_btn.Text = "Add";
            addprofile_btn.UseVisualStyleBackColor = true;
            addprofile_btn.Click += addprofile_btn_Click;
            // 
            // duplicatechrome_btn
            // 
            duplicatechrome_btn.Location = new Point(198, 195);
            duplicatechrome_btn.Name = "duplicatechrome_btn";
            duplicatechrome_btn.Size = new Size(75, 23);
            duplicatechrome_btn.TabIndex = 12;
            duplicatechrome_btn.Text = "Duplicate";
            duplicatechrome_btn.UseVisualStyleBackColor = true;
            duplicatechrome_btn.Click += duplicatechrome_btn_Click;
            // 
            // refreshchrome_btn
            // 
            refreshchrome_btn.Location = new Point(284, 195);
            refreshchrome_btn.Name = "refreshchrome_btn";
            refreshchrome_btn.Size = new Size(75, 23);
            refreshchrome_btn.TabIndex = 11;
            refreshchrome_btn.Text = "Refresh";
            refreshchrome_btn.UseVisualStyleBackColor = true;
            refreshchrome_btn.Click += refreshchrome_btn_Click;
            // 
            // renamechromeversion_btn
            // 
            renamechromeversion_btn.Location = new Point(108, 195);
            renamechromeversion_btn.Name = "renamechromeversion_btn";
            renamechromeversion_btn.Size = new Size(75, 23);
            renamechromeversion_btn.TabIndex = 10;
            renamechromeversion_btn.Text = "Rename";
            renamechromeversion_btn.UseVisualStyleBackColor = true;
            renamechromeversion_btn.Click += renamechromeversion_btn_Click;
            // 
            // addchromeversion_btn
            // 
            addchromeversion_btn.Location = new Point(17, 195);
            addchromeversion_btn.Name = "addchromeversion_btn";
            addchromeversion_btn.Size = new Size(75, 23);
            addchromeversion_btn.TabIndex = 9;
            addchromeversion_btn.Text = "Add";
            addchromeversion_btn.UseVisualStyleBackColor = true;
            addchromeversion_btn.Click += addchromeversion_btn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 258);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 8;
            label1.Text = "Profile";
            // 
            // chromever_lbl
            // 
            chromever_lbl.AutoSize = true;
            chromever_lbl.Location = new Point(17, 21);
            chromever_lbl.Name = "chromever_lbl";
            chromever_lbl.Size = new Size(100, 15);
            chromever_lbl.TabIndex = 7;
            chromever_lbl.Text = "Chrome Manager";
            // 
            // profile_gridview
            // 
            profile_gridview.AllowUserToAddRows = false;
            profile_gridview.AllowUserToDeleteRows = false;
            profile_gridview.AllowUserToOrderColumns = true;
            profile_gridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            profile_gridview.BackgroundColor = SystemColors.ControlLight;
            profile_gridview.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            profile_gridview.Location = new Point(17, 291);
            profile_gridview.Name = "profile_gridview";
            profile_gridview.ReadOnly = true;
            profile_gridview.Size = new Size(342, 150);
            profile_gridview.TabIndex = 6;
            profile_gridview.CellClick += profile_gridview_CellClick;
            // 
            // dbg_button
            // 
            dbg_button.Location = new Point(454, 508);
            dbg_button.Name = "dbg_button";
            dbg_button.Size = new Size(75, 23);
            dbg_button.TabIndex = 9;
            dbg_button.Text = "Info";
            dbg_button.UseVisualStyleBackColor = true;
            dbg_button.Click += button2_Click;
            // 
            // ProfileManager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 559);
            Controls.Add(dbg_button);
            Controls.Add(groupBox2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(groupBox1);
            Name = "ProfileManager";
            Text = "Profile Manager";
            ((System.ComponentModel.ISupportInitialize)chromeversion_gridview).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)profile_gridview).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox chrome_tbx;
        private Label chromepath_lbl;
        private Button apply_button;
        private OpenFileDialog chromefiledialog;
        private Button chromebrowse_btn;
        private DataGridView chromeversion_gridview;
        private GroupBox groupBox1;
        private Button button1;
        private GroupBox groupBox2;
        private DataGridView profile_gridview;
        private Label chromever_lbl;
        private Label label1;
        private Button dbg_button;
        private TextBox textBox1;
        private TextBox profile_tbx;
        private Label profilepath_lbl;
        private Button profilebrowse_btn;
        private FolderBrowserDialog profilefolderdialog;
        private Button reset_button;
        private Button addchromeversion_btn;
        private Label label2;
        private Button renamechromeversion_btn;
        private Button refreshchrome_btn;
        private Button duplicatechrome_btn;
        private Button duplicateprofile_btn;
        private Button refreshprofile_btn;
        private Button renameprofile_btn;
        private Button addprofile_btn;
        private Label label3;
        private Button navigatechrome_btn;
        private Button navigateprofile_btn;
    }
}
