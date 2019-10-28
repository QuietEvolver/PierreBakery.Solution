using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PierreBakery.Models
{
    public class PierreBakeryContext : IdentityDbContext<ApplicationUser>
  {
    public virtual DbSet<Employee> Employees { get; set; }
    public DbSet<Flavor> Flavors { get; set; }
    public DbSet<Treat> Treats { get; set; }
    public DbSet<TreatFlavor> TreatFlavor { get; set; }
    public DbSet<Type> Types { get; set; }
    public DbSet<EmployeeType> EmployeeType { get; set; }

    public PierreBakeryContext(DbContextOptions options) : base(options) { }
  }
}
