using System.ComponentModel.DataAnnotations;

namespace WebPayroll.Models
{
    public class Position
    {
        [Key]
        public string PosId { get; set; } = null!;
        public string DeptId { get; set; } = null!;
        public Department Department { get; set; }
        public string PosName { get; set; } = null!;
    }
}