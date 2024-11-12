using System.Runtime.CompilerServices;

namespace WebPayroll.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public string Username { get;  set;} = null!;
        public string Password { get; set; } = null!;
        
        // One-to-One relationship
        public string EmpId { get; set; } = null!;
        public Employee Employee { get; set; } 

        public int FailedLoginAttempts { get; set; } = 0;
        public DateTime? LockoutEndTime { get; set; }
        public string? CurrentOtpCode { get; set; }
        public DateTime? OtpExpiration { get; set; }
    }
}

