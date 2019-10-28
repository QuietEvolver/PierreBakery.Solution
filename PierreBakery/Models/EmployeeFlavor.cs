namespace PierreBakery.Models
{
  public class EmployeeFlavor
    {
        public int EmployeeFlavorId { get; set; }
        public int FlavorId { get; set; }
        public int EmployeeId { get; set; }
        public Flavor Flavor { get; set; }
        public Employee Employee { get; set; }
    }
}
