using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PuppeteerSharp;

namespace Chromium_Profile_Manager
{
    public partial class ChromiumInstaller : Form
    {
        public static bool IsStillDownloading = false;
        public static string BrowserName = ""; // from input
        public static string BrowserVersion = ""; // from input
        public ChromiumInstaller()
        {
            InitializeComponent();
            this.Load += ChromiumInstaller_Load;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string browserpath = string.Empty;
            IsStillDownloading = true;
            if (Directory.Exists(ProfileManager.GlobalChromePath + @$"\{BrowserName}")) // To avoid overwriting the existing browser, but ignore canceled download for now
            {
                BrowserName = BrowserName + $"_{EpochUtils.GetCurrentEpoch().ToString()}";
                textBox1.Text = BrowserName;
            }

            browserpath = ProfileManager.GlobalChromePath + @$"\{BrowserName}";
            // Set custom download path
            var browserFetcher = new BrowserFetcher(new BrowserFetcherOptions
            {
                Path = browserpath
            });

            // Download Chromium
            await browserFetcher.DownloadAsync();

            IsStillDownloading = false;
            MessageBox.Show("Chromium installed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
        private void ChromiumInstaller_Load(object sender, EventArgs e)
        {
            // Create async to check if the download is still in progress
            _ = IsDownloading();
            //Task.Run(() => AnimateProgressBar());
        }

        private async Task<bool> IsDownloading()
        {
            while (true)
            {
                if (IsStillDownloading)
                {
                    progressBar1.Visible = true;
                    textBox1.Enabled = false;
                    comboBox1.Enabled = false;
                    button1.Enabled = false;
                    label5.Enabled = true;
                    for (int i = 0; i <= 100; i++)
                    {
                        Invoke((Action)(() => progressBar1.Value = i)); // Update UI safely
                        Thread.Sleep(50); // Adjust speed (lower = faster)
                    }
                }
                else
                {
                    label5.Enabled = false;

                    progressBar1.Visible = false;

                }
                await Task.Delay(1000);
            }

            return false;
        }
        private void AnimateProgressBar()
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            BrowserName = textBox1.Text;
        }
    }
}
