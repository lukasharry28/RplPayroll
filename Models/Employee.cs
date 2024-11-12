using System.ComponentModel.DataAnnotations;

namespace WebPayroll.Models
{
    public class Employee
    {
        [Key]
        public string EmpId { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public DateTime Birthday { get; set; }
        public string Religion { get; set; } = null!;
        public string CityId { get; set; } = null!;
        public City City { get; set; }
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string RekBankId { get; set; } = null!;
        public DateTime HireDate { get; set; }
        
        // One-to-Many relationship
        public string CmpId { get; set; } = null!;
        public Company Company { get; set; }
        
        public string PosId { get; set; } = null!;
        public Position Position { get; set; }

        public string ImageName { get; set; } = null!;

        // One-to-One relationship
        public Account Account { get; set; }

        public ICollection<Payroll> Payrolls { get; set; }
    }
}