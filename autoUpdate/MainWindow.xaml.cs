using Squirrel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace autoUpdate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        async Task update()
        {
            using (var mgr = new UpdateManager(@"C:\Users\ASUS\Desktop\autoUpdate\autoUpdate\bin\published"))
            {
                await mgr.UpdateApp();
            }
        }

        async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var mgr = await UpdateManager.GitHubUpdateManager("https://github.com/pandare130691/autoUpdateDemo");
                MessageBox.Show(mgr.CurrentlyInstalledVersion().ToString());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
