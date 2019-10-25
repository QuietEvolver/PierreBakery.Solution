using System.Collections.Generic;

namespace PierreBakery.Models
{
  public class Patron
    {
        public Patron()
        {
            this.Copies = new HashSet<PatronCopy>();
        }

        public int PatronId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<PatronCopy> Copies { get; set; }
    }
}
