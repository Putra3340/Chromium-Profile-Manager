using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chromium_Profile_Manager
{
    public static class Dev
    {
        public static void WriteLine(string message)
        {
            ProfileManager.console.AppendText(message + "\n");
            System.IO.File.AppendAllText(ProfileManager.LogPath, message + "\n");
        }
    }
}
