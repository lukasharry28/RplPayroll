using WebPayroll.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebPayroll.Data
{
    public interface ICompany
    {
        IQueryable<Employee> Employees { get; }
        IQueryable<Department> Departments { get; }
        IQueryable<Position> Positions { get; }

        Task<IEnumerable<Company>> GetCompany();
        Task<Company> GetCompanyById(string id);
        Task AddCompany(Company company);
        Task UpdateCompany(Company company);
        Task DeleteCompany(string id);
        Task<IEnumerable<Company>> GetCompaniesWithBankDetails();
    }
}
