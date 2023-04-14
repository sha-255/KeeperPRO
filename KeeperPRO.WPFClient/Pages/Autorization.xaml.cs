using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using KeeperPRO.WPFClient.DTOs;

namespace KeeperPRO.WPFClient.Pages
{
    /// <summary>
    /// Interaction logic for Autorization.xaml
    /// </summary>
    public partial class Autorization : Page
    {
        public Autorization()
        {
            InitializeComponent();
            AutorizationButton.Click += OnAutorizationButtonClick;
        }

        private async void OnAutorizationButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var staff = await ApiClient.GetEntityAsync<StaffDto>(
                    $"api/Staffs/code?code={PasswordBox.Password}");
                NavigationService.Navigate(new SecurityManagement(staff));
            }
            catch
            {
                MessageBox.Show(
                    "Такого пользователя не существует",
                    "Авторизация",
                    MessageBoxButton.OK,
                    MessageBoxImage.Exclamation);
            }
            finally
            {
                PasswordBox.Clear();
            }
        }
    }
}