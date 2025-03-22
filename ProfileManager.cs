using Chromium_Profile_Manager.Utils;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Chromium_Profile_Manager
{
    public partial class ProfileManager : Form
    {
        // Global Variables
        public static readonly string LogPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Chromium\Logs";
        public static readonly string GlobalConfig = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Chromium\config.dat";
        public static readonly string GlobalChromePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Chromium\Version";
        public static readonly string GlobalProfilePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Chromium\User Data";
        public static readonly string LocalConfigPath = "./localconfig.dat";

        // File Contents
        public static readonly string ConfigFileChromePath = "chromePath=";
        public static readonly string ConfigFileProfilePath = "profilePath=";

        // This is a var that will be saved in the settings file
        public static string chromePath = "";
        public static string profilePath = "";
        public static string profileName = "";

        public static TextBox console = null;
        public BindingList<ChromeProfile> datachromeProfiles = new BindingList<ChromeProfile>();
        public BindingList<ChromeVersion> datachromeVersions = new BindingList<ChromeVersion>();

        #region Functions
        private void CheckAllFiles()
        {
            #region Check if the global settings are valid
            string path = GlobalChromePath;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                Dev.WriteLine($"Created: {path}");
            }
            else
            {
                Dev.WriteLine($"Exists: {path}");
            }
            path = GlobalProfilePath;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                Dev.WriteLine($"Created: {path}");
            }
            else
            {
                Dev.WriteLine($"Exists: {path}");
            }
            if (!File.Exists(GlobalConfig))
            {
                File.Create(GlobalConfig);
                Dev.WriteLine($"Created: {GlobalConfig}");
            }
            else
            {
                Dev.WriteLine($"Exists: {GlobalConfig}");
            }
            if (!File.Exists(LocalConfigPath))
            {
                File.Create(LocalConfigPath);
                Dev.WriteLine($"Created: {LocalConfigPath}");
            }
            else
            {
                Dev.WriteLine($"Exists: {LocalConfigPath}");
            }
            if (!File.Exists(LogPath))
            {
                File.Create(LogPath);
                Dev.WriteLine($"Created: {LogPath}");
            }
            else
            {
                Dev.WriteLine($"Exists: {LogPath}");
            }
            #endregion
        }
        private void LoadLocalConfig()
        {
            // Load the local config file
            string[] lines = File.ReadAllLines(LocalConfigPath);
            foreach (string line in lines)
            {
                if (line.Contains(ConfigFileChromePath))
                {
                    chromePath = line.Replace(ConfigFileChromePath, "");
                    chrome_tbx.Text = chromePath;
                }
                if (line.Contains(ConfigFileProfilePath))
                {
                    profilePath = line.Replace(ConfigFileProfilePath, "");
                    profile_tbx.Text = profilePath;
                }
            }
        }
        private void SaveLocalConfig()
        {
            // Save the local config file
            string[] lines = new string[2];
            lines[0] = ConfigFileChromePath + chromePath;
            lines[1] = ConfigFileProfilePath + profilePath;
            File.WriteAllLines(LocalConfigPath, lines);
        }
        private void ScanChromeVersion()
        {
            datachromeVersions.Clear(); // make sure the list is empty
            string[] directories = Directory.GetDirectories(GlobalChromePath);
            foreach (string directory in directories)
            {
                string name = directory.Replace(GlobalChromePath + "\\", "");
                string path = string.Empty;
                string[] files = Directory.GetFiles(directory, "chrome.exe", SearchOption.AllDirectories);
                if (files.Length > 0)
                {
                    Console.WriteLine("Chrome found at:");
                    foreach (var file in files)
                    {
                        path = file;
                    }
                }
                else
                {
                    Dev.WriteLine($"chrome.exe not found in {directory}.");
                }
                string version = path.Split("\\chrome-win64").First().Split("\\").Last();
                datachromeVersions.Add(new ChromeVersion { Name = name, Version = version, Path = path });
            }
        }
        private void ScanChromeProfiles()
        {
            datachromeProfiles.Clear(); // make sure the list is empty
            string[] directories = Directory.GetDirectories(GlobalProfilePath);
            foreach (string directory in directories)
            {
                string name = directory.Replace(GlobalProfilePath + "\\", "");
                string path = GlobalProfilePath + "\\" + name;
                datachromeProfiles.Add(new ChromeProfile { Name = name, Path = path });
            }
        }
        private static bool CheckProfileName()
        {
            // Check if the profile name is valid
            if (profilePath == "")
            {
                MessageBox.Show("Please select a valid Profile Name");
                return false;
            }
            return true;
        }

        private static bool CheckChromeVersion()
        {
            // Check if the chrome version is valid
            if (chromePath == "")
            {
                MessageBox.Show("Please select a valid Chrome version");
                return false;
            }
            return true;
        }
        #endregion

        public ProfileManager()
        {
            InitializeComponent();
            this.Load += ProfileManager_Load;
        }

        private void apply_button_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure?", "Confirmation",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (!CheckChromeVersion())
                    return;
                if (!CheckProfileName())
                    return;
                SaveLocalConfig();
                MessageBox.Show("Settings Applied");
            }
            else
            {
                return;
            }
        }

        private void chrome_tbx_TextChanged(object sender, EventArgs e)
        {
            chromePath = chrome_tbx.Text;
        }
        private void profile_tbx_TextChanged(object sender, EventArgs e)
        {
            profilePath = profile_tbx.Text;
        }

        private void chromebrowse_btn_Click(object sender, EventArgs e)
        {
            chromefiledialog.ShowDialog();
            chrome_tbx.Text = chromefiledialog.FileName;
        }

        private void profilebrowse_btn_Click(object sender, EventArgs e)
        {
            profilefolderdialog.ShowDialog();
            profile_tbx.Text = profilefolderdialog.SelectedPath;
        }

        private void ProfileManager_Load(object? sender, EventArgs e)
        {
            console = textBox1;
            CheckAllFiles();
            LoadLocalConfig();
            ScanChromeVersion();
            ScanChromeProfiles();
            chrome_tbx.Text = chromePath;

            chromeversion_gridview.DataSource = datachromeVersions;
            profile_gridview.DataSource = datachromeProfiles;
            chromeversion_gridview.Columns["Path"].Visible = false; // Hide column
            profile_gridview.Columns["Path"].Visible = false; // Hide column
            chrome_tbx.Text = "";
            profile_tbx.Text = "";
            #region Delete Table Columns
            // Create a Link Column
            DataGridViewLinkColumn linkColumn = new DataGridViewLinkColumn();
            linkColumn.HeaderText = "Action";
            linkColumn.Name = "ActionColumn";
            linkColumn.Text = "Delete";  // Displayed text
            linkColumn.UseColumnTextForLinkValue = true; // Ensure text appears as a link
            profile_gridview.Columns.Add(linkColumn);

            DataGridViewLinkColumn linkColumn2 = new DataGridViewLinkColumn();
            linkColumn2.HeaderText = "Action";
            linkColumn2.Name = "ActionColumn";
            linkColumn2.Text = "Delete";  // Displayed text
            linkColumn2.UseColumnTextForLinkValue = true; // Ensure text appears as a link
            chromeversion_gridview.Columns.Add(linkColumn2);
            #endregion

        }

        private void chromeversion_gridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == chromeversion_gridview.Columns["ActionColumn"].Index && e.RowIndex >= 0)
                {
                    // Delete This Row and also delete the folder
                    //MessageBox.Show($"Return clicked for {datachromeVersions[e.RowIndex].Version} with path {datachromeVersions[e.RowIndex].Path}");
                    string path = GlobalChromePath + $@"/{datachromeVersions[e.RowIndex].Name}";
                    datachromeVersions.RemoveAt(e.RowIndex);
                    Directory.Delete(path, true);
                }
                else
                {
                    // Update Right Side
                    //MessageBox.Show($"Return clicked for {datachromeVersions[e.RowIndex].Version} with path {datachromeVersions[e.RowIndex].Path}");
                    chrome_tbx.Text = datachromeVersions[e.RowIndex].Path;
                    label2.Text = $"Currently Using : {datachromeVersions[e.RowIndex].Name} - {datachromeVersions[e.RowIndex].Version}";
                }
            }
            catch (Exception ex)
            {
                Dev.WriteLine(ex.Message + "[chromeversion_gridview_CellClick]");
                MessageBox.Show($"Error!!\nIf this keep happening then you should report this error!\n\n {ex.Message}");
            }
        }
        private void profile_gridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == profile_gridview.Columns["ActionColumn"].Index && e.RowIndex >= 0)
                {
                    // Delete This Row and also delete the folder
                    //MessageBox.Show($"Return clicked for {datachromeVersions[e.RowIndex].Version} with path {datachromeVersions[e.RowIndex].Path}");
                    string path = GlobalProfilePath + $@"/{datachromeProfiles[e.RowIndex].Name}";
                    datachromeProfiles.RemoveAt(e.RowIndex);
                    Directory.Delete(path, true);
                }
                else
                {
                    // Update Right Side
                    //MessageBox.Show($"Return clicked for {datachromeVersions[e.RowIndex].Version} with path {datachromeVersions[e.RowIndex].Path}");
                    profile_tbx.Text = datachromeProfiles[e.RowIndex].Path;
                    label3.Text = $"As : {datachromeProfiles[e.RowIndex].Name}";
                }
            }
            catch (Exception ex)
            {
                Dev.WriteLine(ex.Message + "[chromeversion_gridview_CellClick]");
                MessageBox.Show($"Error!!\nIf this keep happening then you should report this error!\n\n {ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void reset_button_Click(object sender, EventArgs e)
        {
            chrome_tbx.Text = "";
            profile_tbx.Text = "";
        }

        private void addchromeversion_btn_Click(object sender, EventArgs e)
        {
            ChromiumInstaller installer = new ChromiumInstaller();
            installer.Show();
        }

        private void renamechromeversion_btn_Click(object sender, EventArgs e)
        {
            var activecell = chromeversion_gridview.CurrentCell;
            if (activecell != null)
            {
                string name = datachromeVersions[activecell.RowIndex].Name;
                string newname = Microsoft.VisualBasic.Interaction.InputBox("Enter the new name for the browser", "Rename Browser", name);
                if (newname != "")
                {
                    string oldpath = GlobalChromePath + $@"/{name}";
                    string newpath = GlobalChromePath + $@"/{newname}";
                    try
                    {
                        Directory.Move(oldpath, newpath);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error Renaming the Browser\n" + ex.Message);
                        return;
                    }
                    datachromeVersions[activecell.RowIndex].Name = newname;

                }
            }
            ScanChromeVersion();
        }

        private void refreshchrome_btn_Click(object sender, EventArgs e)
        {
            ScanChromeVersion();
        }

        private void duplicatechrome_btn_Click(object sender, EventArgs e)
        {
            var activecell = chromeversion_gridview.CurrentCell;
            if (activecell != null)
            {
                string name = datachromeVersions[activecell.RowIndex].Name;
                string newname = Microsoft.VisualBasic.Interaction.InputBox("Enter the new name for the browser", "Duplicate Browser", name);
                if (newname != "")
                {
                    string oldpath = Path.Combine(GlobalChromePath, name);
                    string newpath = Path.Combine(GlobalChromePath, newname);

                    // Recursively copy directory
                    FileOperation.CopyDirectory(oldpath, newpath);

                }
            }
            ScanChromeVersion();
        }

        private void addprofile_btn_Click(object sender, EventArgs e)
        {
            string name = string.Empty;
            string newname = Microsoft.VisualBasic.Interaction.InputBox("Enter the new name for the profile", "Add Profile", name);
            if (newname != "")
            {
                Directory.CreateDirectory(GlobalProfilePath + $@"/{newname}");
            }
            ScanChromeProfiles();
        }

        private void renameprofile_btn_Click(object sender, EventArgs e)
        {
            var activecell = profile_gridview.CurrentCell;
            if (activecell != null)
            {
                string name = datachromeProfiles[activecell.RowIndex].Name;
                string newname = Microsoft.VisualBasic.Interaction.InputBox("Enter the new name for the profile", "Rename Profile", name);
                if (newname != "")
                {
                    string oldpath = GlobalProfilePath + $@"/{name}";
                    string newpath = GlobalProfilePath + $@"/{newname}";
                    try
                    {
                        Directory.Move(oldpath, newpath);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error Renaming the Profile\n" + ex.Message);
                        return;
                    }

                }
            }
            ScanChromeProfiles();
        }

        private void duplicateprofile_btn_Click(object sender, EventArgs e)
        {
            var activecell = profile_gridview.CurrentCell;
            if (activecell != null)
            {
                string name = datachromeProfiles[activecell.RowIndex].Name;
                string newname = Microsoft.VisualBasic.Interaction.InputBox("Enter the new name for the profile", "Duplicate Profile", name);
                if (newname != "")
                {
                    string oldpath = Path.Combine(GlobalProfilePath, name);
                    string newpath = Path.Combine(GlobalProfilePath, newname);
                    try
                    {
                        // Recursively copy directory
                        FileOperation.CopyDirectory(oldpath, newpath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error Copying the Profile\n" + ex.Message);
                        return;
                    }

                }
            }
            ScanChromeProfiles();
        }

        private void refreshprofile_btn_Click(object sender, EventArgs e)
        {
            ScanChromeProfiles();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!CheckChromeVersion())
                return;
            if (!CheckProfileName())
                return;
            SaveLocalConfig();
            this.Close();
        }
    }
    public class ChromeProfile
    {
        public string Name { get; set; }
        public string Path { get; set; }
    }

    public class ChromeVersion
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public string Path { get; set; }
    }
}
