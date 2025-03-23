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
using HtmlAgilityPack;
using System.Xml.Linq;
using System.Threading.Channels;

namespace Chromium_Profile_Manager
{
    public partial class ChromiumInstaller : Form
    {
        public static bool IsStillDownloading = false;
        public static string BrowserName = ""; // from input
        public static string BrowserVersion = ""; // from input
        public static List<ChromeChannel> ChromeChannels = new List<ChromeChannel>();
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
            else
            {
                Directory.CreateDirectory(ProfileManager.GlobalChromePath + @$"\{BrowserName}");
            }
                browserpath = ProfileManager.GlobalChromePath + @$"\{BrowserName}";

            #region Validate Input
            if (comboBox1.Name == "Loading...")
            {
                IsStillDownloading = false;
                MessageBox.Show("Please wait until the channels are loaded", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } else if (textBox1.Text == "") {
                IsStillDownloading = false;
                MessageBox.Show("Please Enter the Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } else if (comboBox1.SelectedIndex == -1)
            {
                IsStillDownloading = false;
                MessageBox.Show("Please Select a version", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            #endregion

            // Get Selected Channel
            string searchName = comboBox1.SelectedItem.ToString().Split(" ").First();
            int index = ChromeChannels.FindIndex(c => c.Name == searchName);
            if (index != -1)
            {
                if(ChromeChannels[index].Url == "")
                {
                    IsStillDownloading = false;
                    MessageBox.Show("This channel is not available", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (ChromeChannels[index].Url.Contains("https://"))
                {
                    string chrome = browserpath + @"\chrome-win64.zip"; // Change to your desired path
                    string chromeheadless = browserpath + @"\chrome-headless-shell-win64.zip"; // Change to your desired path

                    // Download Chrome
                    using HttpClient client = new HttpClient();
                    using HttpResponseMessage response = await client.GetAsync(ChromeChannels[index].Url, HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode(); // Ensure request was successful

                    using Stream contentStream = await response.Content.ReadAsStreamAsync();
                    using FileStream fileStream = new FileStream(chrome, FileMode.Create, FileAccess.Write, FileShare.None);

                    await contentStream.CopyToAsync(fileStream);

                    // Download Chrome Headless
                    using HttpClient client2 = new HttpClient();
                    using HttpResponseMessage response2 = await client2.GetAsync(ChromeChannels[index].Url.Replace("chrome-win64.zip","chrome-headless-shell-win64.zip"), HttpCompletionOption.ResponseHeadersRead);
                    response2.EnsureSuccessStatusCode(); // Ensure request was successful

                    using Stream contentStream2 = await response2.Content.ReadAsStreamAsync();
                    using FileStream fileStream2 = new FileStream(chromeheadless, FileMode.Create, FileAccess.Write, FileShare.None);

                    await contentStream2.CopyToAsync(fileStream2);

                    // Extract Chrome
                    System.IO.Compression.ZipFile.ExtractToDirectory(chrome, browserpath);
                    System.IO.Compression.ZipFile.ExtractToDirectory(chromeheadless, browserpath);

                    System.IO.File.Delete(chrome);
                    System.IO.File.Delete(chromeheadless);

                    IsStillDownloading = false;
                    MessageBox.Show("Chromium installed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    return;
                }
            }

            // If the browser is Default, download it
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
            _ = GetUpdatesChannels();
            //comboBox1.SelectedIndex = 0;
            // Create async to check if the download is still in progress
            _ = IsDownloading();
            //Task.Run(() => AnimateProgressBar());
        }

        private async Task GetUpdatesChannels()
        {
            comboBox1.Items.Add("Loading...");
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://googlechromelabs.github.io/chrome-for-testing/");
            var content = await response.Content.ReadAsStringAsync();

            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(content);

            string Name = string.Empty;
            string Url = string.Empty;
            string Version = string.Empty;

            ChromeChannels.Clear();
            comboBox1.Items.Clear();
            ChromeChannels.Add(new ChromeChannel { Name = "Default", Url = "", Version = "(Recomended)" });
            #region Get Stable,Beta,Dev,Canary
            // Stable
            var nodes = htmlDoc.DocumentNode.SelectNodes("//section[@id='stable']/p");

            if (nodes != null)
            {
                foreach (var node in nodes)
                {
                    Version = node.InnerText.Replace("Version: ", "");
                }
                nodes = htmlDoc.DocumentNode.SelectNodes("//section[@id='stable']//code[contains(text(),'chrome-win64.zip')]");

                if (nodes != null)
                {
                    foreach (var node in nodes)
                    {
                        Url = node.InnerText;
                    }
                }
            }
            ChromeChannels.Add(new ChromeChannel { Name = "Stable", Url = Url, Version = Version });
            // Beta
            nodes = htmlDoc.DocumentNode.SelectNodes("//section[@id='beta']/p");

            if (nodes != null)
            {
                foreach (var node in nodes)
                {
                    Version = node.InnerText.Replace("Version: ", "");
                }
                nodes = htmlDoc.DocumentNode.SelectNodes("//section[@id='beta']//code[contains(text(),'chrome-win64.zip')]");

                if (nodes != null)
                {
                    foreach (var node in nodes)
                    {
                        Url = node.InnerText;
                    }
                }
            }
            ChromeChannels.Add(new ChromeChannel { Name = "Beta", Url = Url, Version = Version });

            // Dev
            nodes = htmlDoc.DocumentNode.SelectNodes("//section[@id='dev']/p");

            if (nodes != null)
            {
                foreach (var node in nodes)
                {
                    Version = node.InnerText.Replace("Version: ", "");
                }
                nodes = htmlDoc.DocumentNode.SelectNodes("//section[@id='dev']//code[contains(text(),'chrome-win64.zip')]");

                if (nodes != null)
                {
                    foreach (var node in nodes)
                    {
                        Url = node.InnerText;
                    }
                }
            }
            ChromeChannels.Add(new ChromeChannel { Name = "Dev", Url = Url, Version = Version });

            // Canary
            nodes = htmlDoc.DocumentNode.SelectNodes("//section[@id='canary']/p");

            if (nodes != null)
            {
                foreach (var node in nodes)
                {
                    Version = node.InnerText.Replace("Version: ", "");
                }
                nodes = htmlDoc.DocumentNode.SelectNodes("//section[@id='canary']//code[contains(text(),'chrome-win64.zip')]");

                if (nodes != null)
                {
                    foreach (var node in nodes)
                    {
                        Url = node.InnerText;
                    }
                }
            }
            ChromeChannels.Add(new ChromeChannel { Name = "Canary", Url = Url, Version = Version });

            
            #endregion

            foreach (var channel in ChromeChannels)
            {
                comboBox1.Items.Add(channel.Name + " - " + channel.Version);
            }
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    public class ChromeChannel
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Version { get; set; }
    }
}
