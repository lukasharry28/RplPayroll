using System.ComponentModel.DataAnnotations;

namespace WebPayroll.Models
{
    public class City
    {
        [Key]
        public string CityId { get; set; } = null!;
        public string CityName { get; set; } = null!;
        public string CountryId { get; set; } = null!;
        
        public Country Country { get; set; }
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
        public ICollection<Company> Companies { get; set; } = new List<Company>();
    }
}