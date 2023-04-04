#pragma warning disable
namespace KeeperPRO.Domain.Data
{
    public class Staff
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string? Division { get; set; }
        public string? Department { get; set; }
        public int? Code { get; set; }
    }
}