using SmartNFTTools;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
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


namespace SmartNFTTools
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///    

    public partial class About : Window
    {

        IWebProxy proxy;

        public HttpClientHandler clientHandler = new HttpClientHandler();

        public HttpClient client = new HttpClient();

        public About()
        {
            proxy = WebRequest.DefaultWebProxy;
            clientHandler.Proxy = proxy;
            clientHandler.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;

            InitializeComponent();

        }

        // Start Menus Links


        private void twitter_click(object sender, RoutedEventArgs e)
        {
            WebsiteOpen("https://twitter.com/AlturaDesigner");
        }
        private void github_click(object sender, RoutedEventArgs e)
        {
            WebsiteOpen("https://github.com/AlturaDesigner/Smart-NFT-Tools");
        }

        private void nfts_click(object sender, RoutedEventArgs e)
        {
            WebsiteOpen("https://app.alturanft.com/user/0x411c9e886b3ce2237ac8486d62daf173798b541d?view=collections");
        }
        private void docs_click(object sender, RoutedEventArgs e)
        {
            WebsiteOpen("https://github.com/AlturaDesigner/Altura-Developer-Tools");
        }
        private void about_click(object sender, RoutedEventArgs e)
        {
            About about = new About();
            about.Show();
            MainWindow mainwindow = new MainWindow();
            mainwindow.Close();
            this.Close();

        }


        private void itemhistory_click(object sender, RoutedEventArgs e)
        {
            ItemHistory window1 = new ItemHistory();
            window1.Show();
            MainWindow mainwindow = new MainWindow();
            window1.Show();
            mainwindow.Close();
            this.Close();

        }
        private void history_click(object sender, RoutedEventArgs e)
        {
            UserItems itemhistory = new UserItems();
            itemhistory.Show();
            MainWindow mainwindow = new MainWindow();
            mainwindow.Close();
            this.Close();

        }

        private void WebsiteOpen(string url)
        {
            var psi = new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            };
            Process.Start(psi);
        }

        private void new_click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.Show();
            MainWindow mainwindow = new MainWindow();
            window1.Show();
            mainwindow.Close();
            this.Close();

        }
        private void changer_click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            window1.Close();
            this.Close();

        }
        private void airdrop_click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            window1.Close();
            this.Close();

        }
        private void holders_click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            window1.Close();
            this.Close();

        }


        // End Menus Links

        public void TextBlock_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            System.Windows.Clipboard.SetText("0x411c9e886b3ce2237ac8486d62daf173798b541d");

        }

    }
}
