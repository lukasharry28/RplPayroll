using System.ComponentModel.DataAnnotations;

namespace WebPayroll.Models
{
    public class RekeningBank
    {
        [Key]
        public string RekBankId { get; set; }  = null!;
        public string BankId { get; set; } = null!;
        
        public Bank Bank { get; set; }
        public DateTime DateCreate { get; set; }
        public decimal Saldo { get; set; }
        public bool ActiveStatus { get; set; }

        public ICollection<Payroll> Payrolls { get; set; }
        public ICollection<Company> Companies { get; set; }
    }
}