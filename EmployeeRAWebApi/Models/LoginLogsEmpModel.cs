namespace EmployeeRAWebApi.Models
{
    public class LoginLogsEmpModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime? LogoutTime { get; set; } // nullable
    }
}
