using KeeperPRO.WPFClient.DTOs;
using System.Windows.Controls;

namespace KeeperPRO.WPFClient.Pages
{
    public partial class Main : Page
    {
        StaffDto StaffDto { get; set; }

        public Main(StaffDto staff)
        {
            InitializeComponent();
            StaffDto = staff;
            ExitToAutorize.Click += OnExitToAutorizeClick;
            Id.Content = StaffDto.Id;
            FullName.Content = StaffDto.FullName;
            Passport.Content = StaffDto.Code;
            Division.Content = StaffDto.Division;
            Department.Content = StaffDto.Department;
        }

        private void OnExitToAutorizeClick(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new Autorization());
        }
    }
}