using System.Collections.Generic;

namespace PierreBakery.Models
{
  public class Employee
    {
        public Employee()
        {
            this.Types = new HashSet<EmployeeType>();
        }

        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<EmployeeType> Types { get; set; }
    }
}
