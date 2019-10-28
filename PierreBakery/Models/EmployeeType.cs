using System;
using System.ComponentModel.DataAnnotations;
namespace PierreBakery.Models
{
  public class EmployeeType
    {
        public int EmployeeTypeId { get; set; }
        public int TypeId { get; set; }
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
        public Type Type { get; set; }
        public Employee Employee { get; set; }
    }
}
