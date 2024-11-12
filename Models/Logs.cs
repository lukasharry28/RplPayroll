using System.ComponentModel.DataAnnotations;

namespace WebPayroll.Models
{
    public class Logs
    {
        [Key]
        public int LogId { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        
        public DateTime LoginTime { get; set; }
        public DateTime LogoutTime { get; set; }
        
        // One-to-One relationship
        public int SessionId { get; set; }
        public Session Session { get; set; }
    }
}