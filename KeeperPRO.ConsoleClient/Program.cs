using KeeperPRO.Client.Dto;
using KeeperPRO.Common.Exeptions;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace KeeperPRO.Client
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Update();
                Console.ReadKey();
            }
        }

        private static async void Update(string[]? args = null)
        {
            Console.Clear();
            var httpClient = HttpClientCreate();
            CreateHeader("Press \"Enter\" to update\n");
            CreateHeader("Staffs");
            await CreateStaffsTable(httpClient);
            Console.WriteLine();
            CreateHeader("UsersGroupVisit");
            await CreateUserGroupVisitTable(httpClient);
            Console.WriteLine();
            CreateHeader("UsersPersonalVisit");
            await CreateUserPersonalVisitTable(httpClient);
        }

        private static HttpClient HttpClientCreate()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:7170");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient;
        }

        private static void CreateHeader(string value)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(value);
            Console.ResetColor();
        }

        private static async Task CreateStaffsTable(HttpClient httpClient)
        {
            var response = await httpClient.GetAsync("api/staffs");
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                var staffs = await response
                    .Content
                    .ReadFromJsonAsync<IEnumerable<StaffDto>>();
                if (staffs == null)
                    throw new NotFoundExeption<IEnumerable<StaffDto>>();
                foreach (var staff in staffs)
                {
                    var builder = new StringBuilder();
                    builder.Append($"{staff.Id.ToString()} ");
                    builder.Append($"{staff.FullName.CorrectionOfFilling()} ");
                    builder.Append($"/{staff.Department?.CorrectionOfFilling()} ");
                    builder.Append($"{staff.Division?.CorrectionOfFilling()} ");
                    builder.Append($"{staff.Code?.ToString()} ");
                    Console.WriteLine(builder);
                }
            }
            else
            {
                Console.WriteLine(
                    new NotFoundExeption<HttpResponseMessage>().Message);
            }
        }

        private static async Task CreateUserGroupVisitTable(HttpClient httpClient)
        {
            var response = await httpClient.GetAsync("api/usergroupvisit");
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                var staffs = await response.Content.ReadFromJsonAsync<IEnumerable<UserGroupVisitDto>>();
                if (staffs == null)
                    throw new NotFoundExeption<IEnumerable<UserGroupVisitDto>>();
                foreach (var staff in staffs)
                {
                    var builder = new StringBuilder();
                    builder.Append($"{staff.Id.ToString()} ");
                    builder.Append($"{staff.FullName.CorrectionOfFilling()} ");
                    Console.WriteLine(builder);
                }
            }
            else
            {
                Console.WriteLine(
                    new NotFoundExeption<HttpResponseMessage>().Message);
            }
        }

        private static async Task CreateUserPersonalVisitTable(HttpClient httpClient)
        {
            var response = await httpClient.GetAsync("api/userpersonalvisit");
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                var staffs = await response.Content.ReadFromJsonAsync<IEnumerable<UserPersonalVisitDto>>();
                if (staffs == null)
                    throw new NotFoundExeption<IEnumerable<UserPersonalVisitDto>>();
                foreach (var staff in staffs)
                {
                    var builder = new StringBuilder();
                    builder.Append($"{staff.Id.ToString()} ");
                    builder.Append($"{staff.FullName.CorrectionOfFilling()} ");
                    Console.WriteLine(builder);
                }
            }
            else
            {
                Console.WriteLine(
                    new NotFoundExeption<HttpResponseMessage>().Message);
            }
        }

        private static string CorrectionOfFilling(this string value)
        {
            for (var i = value.Length-1; i > 0; i--)
                if (value[i] != ' ')
                    return value.Substring(0, i+1);
            throw new ArgumentException();
        }
    }
}