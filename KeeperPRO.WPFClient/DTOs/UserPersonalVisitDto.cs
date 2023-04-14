#pragma warning disable
namespace KeeperPRO.WPFClient.DTOs
{
    public class UserPersonalVisitDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BirthdayDate { get; set; }
        public long PassportData { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Appointment { get; set; }
    }
}
