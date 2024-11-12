using System.ComponentModel.DataAnnotations;

namespace WebPayroll.Models
{
    public class Department
    {
        [Key]
        public string DeptId { get; set; } = null!;
        public string DeptName { get; set; } = null!;

        // One-to-Many relationship with Position
        public ICollection<Position> Positions { get; set; }
    }
}