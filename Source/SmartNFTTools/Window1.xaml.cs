using SmartNFTTools;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SmartNFTTools
{


    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        IWebProxy proxy;

        public HttpClientHandler clientHandler = new HttpClientHandler();

        public HttpClient client = new HttpClient();

        public Window1()
        {
            proxy = WebRequest.DefaultWebProxy;
            clientHandler.Proxy = proxy;
            clientHandler.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;

            InitializeComponent();
        }

        public void Log(string message)
        {
            LogBox.AppendText("\n[" + DateTime.Now.ToString("HH:mm") + "]" + message); 
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }


        private async Task TriggerChangeProperties()
        {


            if (!CheckImageChangeInfo()) return;
            Log("Loading please wait...");


            List<Items> items = new List<Items>();
                items = await GetItems(txt_holdCol.Text, txt_itemToken.Text);
           


            if (items != null)
            {
                if (items.Count > 0)
                {
                    var msg = $"You are about to change properties on {items.Count} from {items[0].itemCollectionName}, are you sure you wish to do this?";
                    MessageBoxResult result = MessageBox.Show(msg, "Are you sure you wish to change these properties?", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:

                            await TaskChangeProperties(items, txt_APIKey.Text, txt_PropertyName.Text, txt_PropertValue.Text, txt_holdCol.Text);
                            
                            break;
                        case MessageBoxResult.No:
                            Log("Cancelling property updater.");
                            break;
                    }
                }
            }

        }

        private async Task TaskChangeProperties(List<Items> items, string apiKey, string propertyName, string propertyValue, string collection)
        {
            foreach (Items item in items)
            {
                Log($"Updating NFT: {item.name} - {propertyName} : {propertyValue}");
                Log($"Support Developer by donation 0x411c9e886b3ce2237ac8486d62daf173798b541d or buy my Smart NFT Watch https://app.alturanft.com/collection/56/0x4ddee11d87a535ec71817b558d81bda24f4cac7b");
                await Task.Delay(10);

                if (!(await UpdateStatAsync(apiKey, item.tokenId, collection, propertyName, propertyValue)))
                {
                    Log($"Received an error updating {item.name} at index {item.tokenId} . Please try again.");
                }
            }
        }

        private async Task<bool> UpdateStatAsync(string apiKey, int index, string collection, string propertyName, string propertyValue)
        {

            try
            {

                var url = "https://api.alturanft.com/api/v2/item/update_property?apiKey=" + apiKey;


                var httpRequest = (HttpWebRequest)WebRequest.Create(url);
                httpRequest.Method = "POST";

                httpRequest.ContentType = "application/json";

                var data = @"{
  ""tokenId"":" + index + @",
  ""address"":""" + collection + @""",
  ""propertyName"": """ + propertyName + @""",
  ""propertyValue"": """ + propertyValue + @"""
}";



                using (var streamWriter = new StreamWriter(await httpRequest.GetRequestStreamAsync()))
                {
                    streamWriter.Write(data);
                }

                var httpResponse = (HttpWebResponse)await httpRequest.GetResponseAsync();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }

                Console.WriteLine(httpResponse.StatusCode);

                return true;


            }
            catch (Exception e)
            {
                Console.WriteLine("Http error occurred.");
                Console.WriteLine(e.Message);
                return false;
            }
        }


        private async Task<List<Items>> GetItems(string collection, string tokenId = "")
        {
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

                return simpleItems;
            }
            catch (Exception e)
            {
                Console.WriteLine("Http error occurred.");
                Log(e.Message);
                return null;
            }
        }


        private bool CheckImageChangeInfo()
        {
            if (txt_APIKey.Text == "")
            {
                Log("API Key Not Provided..");
                return false;
            }


            if (txt_PropertyName.Text == "")
            {
                Log("No property Value Provided.");
                return false;
            }

            if (txt_holdCol.Text.Length != 42)
            {
                Log("Invalid Item Collection String, string should contain 42 Characters.");

                return false;
            }

            if (int.Parse(txt_itemToken.Text) < 1)
            {
                Log("Invalid Item Index");
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
        private void about_click(object sender, RoutedEventArgs e)
        {
            About about = new About();
            about.Show();
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





        private void WebsiteOpen(string url)
        {
            var psi = new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            };
            Process.Start(psi);
        }

        
        private void btn_ChangeImage(object sender, RoutedEventArgs e)
        {
            TriggerChangeProperties();
        }

        public void TextBlock_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            System.Windows.Clipboard.SetText("0x411c9e886b3ce2237ac8486d62daf173798b541d");
            Log("Donation address copied to clipboard. Thank you!");

        }
    }
}

