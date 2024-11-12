using Microsoft.EntityFrameworkCore;
using WebPayroll.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // DbSet untuk masing-masing entitas dalam sistem
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<Logs> Logs { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Bank> Banks { get; set; }
    public DbSet<RekeningBank> RekeningBanks { get; set; }
    public DbSet<Payroll> Payrolls { get; set; }
    public DbSet<DetailPayroll> DetailPayrolls { get; set; }
    public DbSet<SchedulePayroll> SchedulePayrolls { get; set; }
    public DbSet<RetryPayroll> RetryPayrolls { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Konfigurasi relasi antara Employee dan Account (One-to-One)
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Account)
            .WithOne(a => a.Employee)
            .HasForeignKey<Account>(a => a.EmpId)
            .OnDelete(DeleteBehavior.Cascade);


        // Relasi antara Employee dan Company (One-to-Many)
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Company)
            .WithMany(c => c.Employees)
            .HasForeignKey(e => e.CmpId);

        // Relasi antara Position dan Department (One-to-Many)
        modelBuilder.Entity<Position>()
            .HasOne(p => p.Department)
            .WithMany(d => d.Positions)
            .HasForeignKey(p => p.DeptId);

        // Relasi antara City dan Country (One-to-Many)
        modelBuilder.Entity<City>()
            .HasOne(ci => ci.Country)
            .WithMany(co => co.Cities)
            .HasForeignKey(ci => ci.CountryId);

        // Relasi antara RekeningBank dan Bank (One-to-Many)
        modelBuilder.Entity<RekeningBank>()
            .HasOne(rb => rb.Bank)
            .WithMany(b => b.RekeningBanks)
            .HasForeignKey(rb => rb.BankId)
            .HasPrincipalKey(b => b.BankId);

        // Relasi antara SchedulePayroll dan Company (One-to-Many)
        modelBuilder.Entity<SchedulePayroll>()
            .HasOne(sp => sp.Company)
            .WithMany(c => c.SchedulePayrolls)
            .HasForeignKey(sp => sp.CmpId);

        // Relasi antara Payroll dan Employee (One-to-Many)
        modelBuilder.Entity<Payroll>()
            .HasOne(p => p.Employee)
            .WithMany(e => e.Payrolls)
            .HasForeignKey(p => p.EmpId);

        // Relasi antara Payroll dan SchedulePayroll (One-to-Many)
        modelBuilder.Entity<Payroll>()
            .HasOne(p => p.SchedulePayroll)
            .WithMany(sp => sp.Payrolls)
            .HasForeignKey(p => p.ScdId);

        // Relasi antara DetailPayroll dan Payroll (One-to-Many)
        modelBuilder.Entity<DetailPayroll>()
            .HasOne(dp => dp.Payroll)
            .WithMany(p => p.DetailPayrolls)
            .HasForeignKey(dp => dp.PayId);

        // Relasi antara RetryPayroll dan DetailPayroll (One-to-Many)
        modelBuilder.Entity<RetryPayroll>()
            .HasOne(rp => rp.DetailPayroll)
            .WithMany(dp => dp.RetryPayrolls)
            .HasForeignKey(rp => rp.DetPayId);

        modelBuilder.Entity<Company>()
            .HasOne(c => c.City)
            .WithMany(ct => ct.Companies)
            .HasForeignKey(c => c.CityId);
    }
}
