using System.ComponentModel.DataAnnotations;

namespace WebPayroll.Models
{
    public class Bank
    {
        [Key]
        public string BankId { get; set; }  = null!;
        public string BankName { get; set; } = null!;

        // One-to-Many relationship with RekBank
        public ICollection<RekeningBank> RekeningBanks { get; set; }
    }
}