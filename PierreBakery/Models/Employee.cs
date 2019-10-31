using System.Collections.Generic;

namespace PierreBakery.Models
{
  public class Employee
    {
        public Employee()
        {
            this.Kinds = new HashSet<EmployeeKind>();
        }

        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<EmployeeKind> Kinds { get; set; }
    }
}
