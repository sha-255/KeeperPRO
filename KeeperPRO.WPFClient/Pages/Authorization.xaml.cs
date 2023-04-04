using KeeperPRO.WPFClient.Pages;
using System.Windows;
using System.Windows.Controls;

namespace KeeperPRO.WPFClient
{
    /// <summary>
    /// Interaction logic for Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public Authorization()
        {
            InitializeComponent();
            AuthorizationButton.Click += AuthorizationButtonClick;
        }

        private void AuthorizationButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AccessControl());
        }
    }
}
