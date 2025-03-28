﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chromium_Profile_Manager
{
    public partial class Credits : Form
    {
        public static string CreditsDescription = "This software is made by PutraRTX. You can visit my website at https://putrartx.my.id";
        public Credits(string description)
        {
            InitializeComponent();
            Assembly assembly = Assembly.GetExecutingAssembly(); // Or specify another assembly
            AssemblyName assemblyName = assembly.GetName();
            label3.Text = assemblyName.Name;
            label4.Text = assemblyName.Version.ToString();
            label2.Text = description;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo("https://putrartx.my.id") { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening link: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
