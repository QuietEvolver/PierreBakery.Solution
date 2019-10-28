using System.Collections.Generic;
namespace PierreBakery.Models
{
  public class Type
  {
    public Type()
    {
      this.Employees = new HashSet<EmployeeType>();
    }
    public int TypeId { get; set; }
    public int FlavorId { get; set; }
    public Flavor Flavor { get; set; }
    public Employee Employee { get; set; }

    public ICollection<EmployeeType> Employees { get;}
    public virtual ApplicationUser User { get; set; }
  }
}
