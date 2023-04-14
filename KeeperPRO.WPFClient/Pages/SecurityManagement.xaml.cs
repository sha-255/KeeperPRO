using KeeperPRO.WPFClient.Common.Extensions;
using KeeperPRO.WPFClient.DTOs;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace KeeperPRO.WPFClient.Pages
{
    public partial class SecurityManagement : Page
    {
        private StaffDto StaffDto { get; set; }
        private IEnumerable<UserPersonalVisitDto> Users { get; set; }

        public SecurityManagement(StaffDto staff)
        {
            InitializeComponent();
            StaffDto = staff;
            VerificationListView.Items.Clear();
            ApplyUsersContext();
            ExitToAutorize.Click += (s, a) => NavigationService.Navigate(new Autorization());
            UserNameLabel.Content = StaffDto.FullName.Trim().ToInitials();
        }

        private async void ApplyUsersContext()
            => VerificationListView.ItemsSource = 
            await ApiClient.GetAllEntitysAsync<UserPersonalVisitDto>("api/UserPersonalVisit");
    }
}