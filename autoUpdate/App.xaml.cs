using Squirrel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace autoUpdate
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            CheckForUpdates();
        }
        private async void CheckForUpdates()
        {
            try
            {
                using (var mgr = await UpdateManager.GitHubUpdateManager("https://github.com/pandare130691/autoUpdateDemo"))
                {
                    var a = mgr.CurrentlyInstalledVersion().ToString();
                    MessageBox.Show(a);
                    var release = await mgr.UpdateApp();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Failed to check Updates: " + e.ToString());
            }
        }
    }
}
