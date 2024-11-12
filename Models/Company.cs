using System.ComponentModel.DataAnnotations;

namespace WebPayroll.Models
{
    public class Company
    {
        [Key]
        public string CmpId { get; set; } = null!;
        public string CmpName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string RekBankId { get; set; } = null!;
        public string CityId { get; set; } = null!;
        public City City { get; set; }
        public RekeningBank RekeningBank { get; set; }
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
        public ICollection<SchedulePayroll> SchedulePayrolls { get; set; } = new List<SchedulePayroll>();
    }
}
