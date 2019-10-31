using System.Collections.Generic;
namespace PierreBakery.Models
{
  public class Kind
  {
    public Kind()
    {
      this.Employees = new HashSet<EmployeeKind>();
    }
    public int KindId { get; set; }
    public int FlavorId { get; set; }
    public Flavor Flavor { get; set; }
    public Employee Employee { get; set; }

    public ICollection<EmployeeKind> Employees { get;}
    public virtual ApplicationUser User { get; set; }
  }
}
