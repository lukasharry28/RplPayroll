using WebPayroll.Models;

namespace WebPayroll.ViewModel
{
    public class CompanyDetailsViewModel
    {
        public IEnumerable<Company> Company { get; set; } // Mengambil daftar perusahaan
        public RekeningBank RekeningBank { get; set; } // Mengambil detail rekening pertama
        public IEnumerable<Employee> Employees { get; set; } // Mengambil semua data Employee
        public IEnumerable<Department> Departments { get; set; } // Mengambil semua data Department
        public IEnumerable<Position> Positions { get; set; } // Mengambil semua data Position

        public IEnumerable<EmployeeCountPerPosition> EmployeeCountPerPosition { get; set; } // Jumlah karyawan per posisi
    }

    // Kelas tambahan untuk menampilkan jumlah karyawan per posisi
    public class EmployeeCountPerPosition
    {
        public string PositionName { get; set; }
        public int EmployeeCount { get; set; }
    }
}
