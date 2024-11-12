using System.ComponentModel.DataAnnotations;

namespace WebPayroll.Models
{
    public class Payroll
    {
        [Key]
        public int PayId { get; set; }
        
        public string CmpId { get; set; } = null!;
        public Company Company { get; set; }

        public string EmpId { get; set; } = null!;
        public Employee Employee { get; set; }
        
        public int ScdId { get; set; }
        public SchedulePayroll SchedulePayroll { get; set; }
        public string? Description { get; set; }

        public ICollection<DetailPayroll> DetailPayrolls { get; set; }
    }
}