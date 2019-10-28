using System.Collections.Generic;

namespace PierreBakery.Models
{
    public class Flavor
    {
        public Flavor()
        {
            this.Treats = new HashSet<TreatFlavor>();
        }

        public int FlavorId { get; set; }
        public string Title { get; set; }
        public virtual ApplicationUser User { get; set; }

        public ICollection<TreatFlavor> Treats { get;}
    }
}
