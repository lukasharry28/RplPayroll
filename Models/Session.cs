using System.ComponentModel.DataAnnotations;

namespace WebPayroll.Models
{
    public class Session
    {
        [Key]
        public int SessionId { get; set; }
        
        // One-to-Many relationship
        public int AccountId { get; set; }
        public Account Account { get; set; }
        
        public DateTime SessionStart { get; set; }
        public DateTime SessionEnd { get; set; }
        public string Activities { get; set; } = null!;
    }

}