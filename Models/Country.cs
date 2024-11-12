using System.ComponentModel.DataAnnotations;

namespace WebPayroll.Models
{
    public class Country
    {
        [Key]
        public string CountryId { get; set; } = null!;
        public string CountryName { get; set; } = null!;

        // One-to-Many relationship with City
        public ICollection<City> Cities { get; set; }

        public ICollection<SchedulePayroll> SchedulePayrolls { get; set; }
    }
}