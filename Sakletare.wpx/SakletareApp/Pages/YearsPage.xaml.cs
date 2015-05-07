using System;
using System.IO;
using System.Net;
using System.Windows;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Net.NetworkInformation;
using Microsoft.Phone.Tasks;
using Silver.Wp7.Logic;

namespace Silver.Wp7.Pages
{
    public partial class YearsPage : PhoneApplicationPage
    {
        public YearsPage()
        {
            InitializeComponent();
        }

        private Uri uriSilver = new Uri("http://www.silverpriset.se");
        private Uri uriGold = new Uri("http://www.guldpriset.se");

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (InternetIsAvailable())
            {
                LoadSilverPrice(uriSilver);
                LoadGoldPrice(uriGold);
            }
        }

        private void hyperlinkButton1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var web = new WebBrowserTask();
                web.Uri = new Uri("http://silverklubben.se/");
                web.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Navigationsfel", MessageBoxButton.OK);
            }
        }

        private bool InternetIsAvailable()
        {
            try
            {
                return NetworkInterface.GetIsNetworkAvailable();
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void LoadSilverPrice(Uri uri)
        {
            var client = new WebClient();
            client.OpenReadCompleted += client_OpenReadSilverCompleted;
            client.OpenReadAsync(uri);
        }

        private void LoadGoldPrice(Uri uri)
        {
            var client = new WebClient();
            client.OpenReadCompleted += client_OpenReadGoldCompleted;
            client.OpenReadAsync(uri);
        }

        private void client_OpenReadSilverCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                return;
            }

            using (TextReader rd = new StreamReader(e.Result))
            {
                string s = rd.ReadToEnd();

                var parser = new HtmlStringParser(s);
                string item = parser.ParseSilver();
                textBlockSilver.Text = item;
            }
        }

        private void client_OpenReadGoldCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                return;
            }

            using (TextReader rd = new StreamReader(e.Result))
            {
                string s = rd.ReadToEnd();

                var parser = new HtmlStringParser(s);
                string item = parser.ParseGold();
                textBlockGold.Text = item;
            }
        }
    }
}