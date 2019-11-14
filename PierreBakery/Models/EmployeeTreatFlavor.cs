using System;
using System.ComponentModel.DataAnnotations;
namespace PierreBakery.Models
{
  public class EmployeeTreatFlavor
    {
        public int EmployeeTreatFlavorId { get; set; }
        public int TreatFlavorId { get; set; }
        public int EmployeeId { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode=true)]
        [DataType(DataType.Date)]
        public DateTime CheckDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode=true)]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode=true)]
        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }
        public TreatFlavor TreatFlavors { get; set; }
        public Employee Employee { get; set; }
    }
}
