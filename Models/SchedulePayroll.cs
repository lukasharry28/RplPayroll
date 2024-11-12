using System.ComponentModel.DataAnnotations;

namespace WebPayroll.Models
{
    public class SchedulePayroll
    {
        [Key]
        public int ScdId { get; set; }
        
        // One-to-Many relationship
        public string CmpId { get; set; }  = null!;
        public Company Company { get; set; }

        public string PayrollFrekens { get; set; }  = null!;
        public DateTime PayrollDate { get; set; }
        public DateTime DateCreate { get; set; }

        public ICollection<Payroll> Payrolls { get; set; }
    }

}