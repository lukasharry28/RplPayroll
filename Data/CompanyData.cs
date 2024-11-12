using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPayroll.Models;

namespace WebPayroll.Data
{
    public class CompanyData : ICompany
{
    private readonly ApplicationDbContext _db;

    public CompanyData(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Company>> GetCompany()
    {
        return await _db.Companies.OrderBy(c => c.CmpName).ToListAsync();
    }

    public async Task<IEnumerable<Company>> GetCompaniesWithBankDetails()
    {
        return await _db.Companies
            .Include(c => c.RekeningBank) // Include relasi RekeningBank
            .OrderBy(c => c.CmpName)
            .ToListAsync();
    }

    public async Task<Company> GetCompanyById(string id)
    {
        return await _db.Companies
            .Include(c => c.RekeningBank)
            .FirstOrDefaultAsync(c => c.CmpId == id);
    }

    public async Task AddCompany(Company company)
    {
        _db.Companies.Add(company);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateCompany(Company company)
    {
        _db.Companies.Update(company);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteCompany(string id)
    {
        var company = await GetCompanyById(id);
        if (company != null)
        {
            _db.Companies.Remove(company);
            await _db.SaveChangesAsync();
        }
    }

    // Implementasi untuk properti Employees, Departments, dan Positions
    public IQueryable<Employee> Employees => _db.Employees;
    public IQueryable<Department> Departments => _db.Departments;
    public IQueryable<Position> Positions => _db.Positions;
    }
}
