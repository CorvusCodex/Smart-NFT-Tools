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

    public partial class Holders : Window
    {

        IWebProxy proxy;

        public HttpClientHandler clientHandler = new HttpClientHandler();

        public HttpClient client = new HttpClient();

        public Holders()
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
                Log("http error");
                Log(e.Message);
                return null;
            }

        }

        private bool TransferItem(string collection, string from, string to, int amount, int index, string apiKey)
        {
            try
            {
                var url = "https://api.alturanft.com/api/v2/item/transfer?apiKey=" + apiKey;

                var httpRequest = (HttpWebRequest)WebRequest.Create(url);
                httpRequest.Method = "POST";

                httpRequest.ContentType = "application/json";

                var data = @"{
                ""address"":""" + collection + @""",
                ""to"":""" + to + @""",
                ""from"":""" + from + @""",
                ""amounts"": [" + amount + @"],
                ""ids"": [" + index + @"]
                }";

                Console.WriteLine(data);

                using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
                {
                    streamWriter.Write(data);
                }

                var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    Console.WriteLine(result);
                }

                Console.WriteLine(httpResponse.StatusCode);
                Console.WriteLine(httpResponse);

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Http Error:" + e.Message);

                return false;
            }

        }

        public void Log(string message)
        {
            LogBox.AppendText("\n" + message);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (chk_SpecificToken.IsChecked == false)
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

        private void btn_ManAirdrop_Click(object sender, RoutedEventArgs e)
        {


            if (!CheckAirDropInfo()) return;

            if (txt_ManAirDropAddress.Text.Length != 42)
            {
                Log("Invalid Address String, should be 42 Characters such as: 0x00000000000000000...");
                return;
            }
            Log("Loading please wait...");
            ManAirDrop();
        }

       


        private async Task ManAirDrop()
        {
            var airDropItem = await GetItem(txt_AirDropCollection.Text, txt_numAirDropToken.Text);

            if (airDropItem == null)
            {
                Log("Cannot retrieve Airdrop item");
                return;
            }

            string msg = $"Are you sure you wish to Airdrop {txt_AmountToAirdrop.Text} {airDropItem.name}(s)\nID: {txt_numAirDropToken.Text} from Collection: {txt_AirDropCollection.Text}\n\n" +
                $"This will be airdropped to {txt_ManAirDropAddress.Text}";
            msg += $"\nPlease ensure you have enough funds in your devevloper wallet, and the airdrop items are currently owned by that wallet. \n\n" +
            $"" +
            $"Once this process starts it cannot be stopped";

            MessageBoxResult result = MessageBox.Show(msg, "Are you sure you wish to AirDrop selected tokens?", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    var addy = new List<string>();
                    addy.Add(txt_ManAirDropAddress.Text);
                    await TaskAirDrop(addy, txt_APIKey.Text, txt_AirDropCollection.Text, txt_AmountToAirdrop.Text, txt_numAirDropToken.Text);
                    Log($"Support Developer by donation 0x411c9e886b3ce2237ac8486d62daf173798b541d or buy my Smart NFT Watch https://app.alturanft.com/collection/56/0x4ddee11d87a535ec71817b558d81bda24f4cac7b");
                    break;
                case MessageBoxResult.No:
                    Log("Cancelling auto airdrop");
                    break;
            }

        }

        private async Task TaskAirDrop(List<string> addresses, string apiKey, string collection, string amount, string token)
        {
            if (addresses == null)
            {
                Log("Addresses = null, cancelling");
                return;
            }
            if (addresses.Count == 0)
            {
                Log("No Addresses found to drop to, cancelling");
                return;
            }

            foreach (string addy in addresses)
            {

                Log("Transferring Item to: " + addy);
                await Task.Delay(10);
                if (!TransferItem(collection, "", addy, int.Parse(amount), int.Parse(token), apiKey))
                {
                    Log($"Error Transferring Item, Cancelling incase of major issues:\n" +
                        $"Collection:{collection}\n" +
                        $"Token: {token}\n" +
                        $"To Addy:{addy}\n" +
                        $"Amount: {amount}\n");
                }
                await Task.Delay(10);
            }
        }

        private bool CheckAirDropInfo()
        {
            if (txt_APIKey.Text == "")
            {
                Log("No API Key Provided..");
                return false;
            }

            if (txt_AirDropCollection.Text.Length != 42)
            {
                Log("Invalid Collection String, should be 42 Characters such as: 0x27970a7fa322bbfefe208dbca7f8130a964c2b12");
                return false;
            }

            if (int.Parse(txt_numAirDropToken.Text) < 1)
            {
                Log("Invalid Airdrop Token - Should be a number greater than 0");
                return false;
            }

            if (int.Parse(txt_numAirDropToken.Text) < 1)
            {
                Log("Invalid Airdrop Amount - Should be a number greater than 0");
                return false;
            }

            return true;
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



        private void WebsiteOpen(string url)
        {
            var psi = new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            };
            Process.Start(psi);
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
