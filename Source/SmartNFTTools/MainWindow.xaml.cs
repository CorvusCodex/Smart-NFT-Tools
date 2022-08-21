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

    public partial class MainWindow : Window
    {

        IWebProxy proxy;

        public HttpClientHandler clientHandler = new HttpClientHandler();

        public HttpClient client = new HttpClient();

        

        public MainWindow()
        {
            
            proxy = WebRequest.DefaultWebProxy;
            clientHandler.Proxy = proxy;
            clientHandler.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;

            InitializeComponent();

        }



        public void Log(string message)
        {
            LogBox.AppendText("\n" + message);
        }


        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        //int iteme = 1;

        private async Task TriggerChangeItem()
        {


            if (!CheckImageChangeInfo()) return;
            Log("Loading...");
            //ButtonSetState(false);



            int parsethis = Int32.Parse(txt_itemToken.Text);

                await TaskChangeImages(parsethis, txt_APIKey.Text, int.Parse(txt_imageIndex.Text), txt_holdCol.Text);
            

        }



        private async Task TaskChangeImages(int iteme, string apiKey, int imageIndex, string collection)
        {
                Log($"Updating NFT: {iteme} to image index {imageIndex}");
               await Task.Delay(10);
            Log($"Image updated.");
            Log($"Support Developer by donation 0x411c9e886b3ce2237ac8486d62daf173798b541d or buy my Smart NFT Watch https://app.alturanft.com/collection/56/0x4ddee11d87a535ec71817b558d81bda24f4cac7b");
            if (!UpdateImage(apiKey, iteme, collection, imageIndex))
                {
                    Log($"Received an error updating {iteme} at index {iteme} cancelling batch");
                }
            Log($"Image updated.");
            Log($"Support Developer by donation 0x411c9e886b3ce2237ac8486d62daf173798b541d or buy my Smart NFT Watch https://app.alturanft.com/collection/56/0x4ddee11d87a535ec71817b558d81bda24f4cac7b");
        }

        private bool UpdateImage(string apiKey, int tokenId, string collection, int imageIndex)
        {
            try
            {
                var url = "https://api.alturanft.com/api/v2/item/update_primary_image?apiKey=" + apiKey;

                var httpRequest = (HttpWebRequest)WebRequest.Create(url);
                httpRequest.Method = "POST";

                httpRequest.ContentType = "application/json";

                var data = @"{
  ""tokenId"":" + tokenId + @",
  ""address"":""" + collection + @""",
  ""imageIndex"": """ + imageIndex + @"""}";


                using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
                {
                    streamWriter.Write(data);
                }

                var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    //  Console.WriteLine(result);
                }

                Console.WriteLine(httpResponse.StatusCode);
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine("Http Error:" + e.Message);
                // Console.WriteLine(e.Data);
                return false;
            }

        }

       


                private bool CheckImageChangeInfo()
        {
            if (txt_APIKey.Text == "")
            {
                Log("Please Provide API Key..");
                return false;
            }

            if (txt_holdCol.Text.Length != 42)
            {
                Log("Invalid Item Collection input. Input must contain e 42 Characters such as: 0x411c9e886b3ce2237ac8486d62daf173798b541d. Please try again");

                return false;
            }

            if (int.Parse(txt_itemToken.Text) < 1)
            {
                Log("Invalid Image Index. Must be a number greater than 0. Please try again.");
                return false;
            }

            return true;
        }


        private void ButtonSetState(bool state)
        {
            btn_AutoAirdrop.IsEnabled = state;
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
            Holders holders = new Holders();
            mainwindow.Close();
            window1.Close();
            holders.Show();
            this.Close();

        }
        private void holders_click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            MainWindow mainwindow = new MainWindow();
            Checkholders checkholders = new Checkholders();
            checkholders.Show();
            mainwindow.Close();
            window1.Close();
            this.Close();

        }

        // Menus Links End

        public void TextBlock_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            System.Windows.Clipboard.SetText("0x411c9e886b3ce2237ac8486d62daf173798b541d");
            Log("Donation address copied to clipboard. Thank you!");

        }

        private void btn_ChangeImage(object sender, RoutedEventArgs e)
        {
            TriggerChangeItem();
        }

    }
}
