using System.ComponentModel.DataAnnotations;

namespace WebPayroll.Models
{
    public class RetryPayroll
    {
        [Key]
        public int RetryId { get; set; }
        
        public int DetPayId { get; set; }
        public DetailPayroll DetailPayroll { get; set; }
        
        public DateTime RetryDate { get; set; }
        public decimal RetryStatus { get; set; }
    }

}