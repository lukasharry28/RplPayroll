using System.ComponentModel.DataAnnotations;

namespace WebPayroll.Models
{
    public class DetailPayroll
    {
        [Key]
        public int DetPayId { get; set; }
        
        public int PayId { get; set; }
        public Payroll Payroll { get; set; } 
    
        public decimal Amount { get; set; }
        public string PayStatus { get; set; } = null!;
        public DateTime PaymentDate { get; set; }

        public ICollection<RetryPayroll> RetryPayrolls { get; set; }
    }
}