using KeeperPRO.WPFClient.Pages;
using System.Windows;

namespace KeeperPRO.WPFClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Autorization());
        }
    }
}