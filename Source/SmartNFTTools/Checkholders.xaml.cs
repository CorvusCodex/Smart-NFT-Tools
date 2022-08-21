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

    public partial class Checkholders : Window
    {

        IWebProxy proxy;

        public HttpClientHandler clientHandler = new HttpClientHandler();

        public HttpClient client = new HttpClient();

        public Checkholders()
        {
            proxy = WebRequest.DefaultWebProxy;
            clientHandler.Proxy = proxy;
            clientHandler.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;

            InitializeComponent();

            txt_HolderToken.IsEnabled = (bool)chk_SpecificToken.IsChecked;


        }


        private async Task<Items> GetItem(string collection, string tokenId)
        {

            try
            {
                var url = "http://api.alturanft.com/api/external/item?collectionId=" + collection;
                url += "&tokenId=" + tokenId;
                var msg = await client.GetStringAsync(url);

                JObject result = JObject.Parse(msg);

                if (msg.Contains("error")) return null;

                return JsonConvert.DeserializeObject<Items>(result["item"].ToString());

            }
            catch (Exception e)
            {
                Log("Http error");
                Log(e.Message);
                return null;
            }
        }


        private async Task<Dictionary<string, int>> GetHolders(string collection, string tokenId = "")
        {
            Dictionary<string, int> addresses = new Dictionary<string, int>();


            try
            {
                var url = "http://api.alturanft.com/api/external/item?collectionId=" + collection;
                if (tokenId != "") url += "&tokenId=" + tokenId;
                var msg = await client.GetStringAsync(url);

                JObject result = JObject.Parse(msg);

                if (msg.Contains("error")) return null;
                List<Items> simpleItems = new List<Items>();
                if (tokenId == "")
                    simpleItems = JsonConvert.DeserializeObject<List<Items>>(result["items"].ToString());
                else
                {

                    simpleItems.Add(JsonConvert.DeserializeObject<Items>(result["item"].ToString()));
                }


                if (simpleItems != null)
                {
                    if (simpleItems.Count > 0)
                    {
                        Log(simpleItems[0].itemCollectionName);
                    }
                    if (tokenId != "") Log(simpleItems[0].name);
                }

                foreach (Items item in simpleItems)
                {
                    foreach (Holder h in item.holders)
                    {
                        if (!addresses.ContainsKey(h.address))
                        {
                            if (h.address != "0xe29f0b490f0d89ca7acac1c7bed2e07ecad65201" && h.address != "0x000000000000000000000000000000000000dead")
                            {
                                addresses.Add(h.address, h.balance);
                            }
                        }
                        else
                        {

                            addresses[h.address] += h.balance;
                        }
                    }

                }

                foreach (KeyValuePair<string, int> addy in addresses)
                {
                    Log(addy.Value + " - " + addy.Key);
                }

                return addresses;

            }
            catch (Exception e)
            {
                Log("Http error");
                Log(e.Message);
                return null;
            }

        }


        public void Log(string message)
        {
            LogBox.AppendText("\n" + message);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (chk_SpecificToken.IsChecked == true)
                await GetHolders(txt_holdCol.Text, txt_HolderToken.Text);
            else
                await GetHolders(txt_holdCol.Text);
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void chk_SpecificToken_Checked(object sender, RoutedEventArgs e)
        {
            txt_HolderToken.IsEnabled = (bool)chk_SpecificToken.IsChecked;

        }


        //Menus Links


        private void twitter_click(object sender, RoutedEventArgs e)
        {
            WebsiteOpen("https://twitter.com/AlturaDesigner");
        }
        private void github_click(object sender, RoutedEventArgs e)
        {
            WebsiteOpen("https://github.com/AlturaDesigner/");
        }

        private void nfts_click(object sender, RoutedEventArgs e)
        {
            WebsiteOpen("https://app.alturanft.com/user/0x411c9e886b3ce2237ac8486d62daf173798b541d?view=collections");
        }
        private void docs_click(object sender, RoutedEventArgs e)
        {
            WebsiteOpen("https://github.com/AlturaDesigner/Smart-NFT-Tools");
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

        //Menus Links

        public void TextBlock_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            System.Windows.Clipboard.SetText("0x411c9e886b3ce2237ac8486d62daf173798b541d");
            Log("Donation address copied to clipboard. Thank you!");

        }
    }
}
