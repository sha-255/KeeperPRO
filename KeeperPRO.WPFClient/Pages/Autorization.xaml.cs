using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Collections.Generic;
using KeeperPRO.WPFClient.DTOs;
using System.Linq;

namespace KeeperPRO.WPFClient.Pages
{
    /// <summary>
    /// Interaction logic for Autorization.xaml
    /// </summary>
    public partial class Autorization : Page
    {
        List<StaffDto> staffs = new List<StaffDto>();

        public Autorization()
        {
            InitializeComponent();
            AutorizationButton.Click += OnAutorizationButtonClick;
        }

        private async void OnAutorizationButtonClick(object sender, RoutedEventArgs e)
        {
            var a = await ApiClient.GetIEnumerableAsync<StaffDto>("api/staffs");
            staffs = a.ToList();
            StaffDto loginedStaff = new();
            try
            {
                if (staffs.Contains(staffs.First(x => x.FullName.Trim() == LoginTextBox.Text))
                    && staffs.Contains(staffs.First(x =>
                    {
                        loginedStaff = x;
                        return x.Code.ToString() == PasswordBox.Password;
                    })))
                {
                    NavigationService.Navigate(new Main(loginedStaff));
                }
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
                LoginTextBox.Clear();
                PasswordBox.Clear();
            }
        }
    }
}