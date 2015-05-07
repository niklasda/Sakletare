using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace Silver.Wp7.Pages
{
    public partial class StartPage : PhoneApplicationPage
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private void hyperlinkButtonYears_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/YearsPage.xaml",UriKind.Relative));
        }

        private void hyperlinkButtonPorcelain_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonYears_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/YearsPage.xaml", UriKind.Relative));

        }

        private void buttonPorcelain_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/PorcelainPage.xaml", UriKind.Relative));

        }

        private void buttonEpoques_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/EpoquesPage.xaml", UriKind.Relative));

        }
    }
}