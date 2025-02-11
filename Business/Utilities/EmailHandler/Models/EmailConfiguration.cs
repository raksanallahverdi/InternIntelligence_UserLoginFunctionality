namespace Business.Utilities.EmailHandler.Models
{
    public class EmailConfiguration
    {
        public string SmtpServer { get; set; }
        public string UserName { get; set; }
        public int Port { get; set; }
        public string Password { get; set; }
    }
}
