using Microsoft.AspNetCore.Mvc;
using WebPayroll.Models;
using System.Diagnostics;
using WebPayroll.Data;
using System.Threading.Tasks;

namespace WebPayroll.Controllers
{
    [Route("company")]
    public class CompanyController : Controller
    {
        private readonly ILogger<CompanyController> _logger;
        private readonly ICompany _companyData;

        public CompanyController(ILogger<CompanyController> logger, ICompany companyData)
        {
            _logger = logger;
            _companyData = companyData;
        }

        // GET: /company
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Company> companies = await _companyData.GetCompaniesWithBankDetails();
            return View(companies);
        }


        // GET: Company/Details/{id}
        public async Task<IActionResult> Details(string id)
        {
            var company = await _companyData.GetCompanyById(id);  // Await the async method
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        // GET: Company/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Company/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Company company)
        {
            if (ModelState.IsValid)
            {
                await _companyData.AddCompany(company);  // Await the async method
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        // GET: Company/Edit/{id}
        public async Task<IActionResult> Edit(string id)
        {
            var company = await _companyData.GetCompanyById(id);  // Await the async method
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        // POST: Company/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Company company)
        {
            if (id != company.CmpId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _companyData.UpdateCompany(company);  // Await the async method
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        // GET: Company/Delete/{id}
        public async Task<IActionResult> Delete(string id)
        {
            var company = await _companyData.GetCompanyById(id);  // Await the async method
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        // POST: Company/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _companyData.DeleteCompany(id);  // Await the async method
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
