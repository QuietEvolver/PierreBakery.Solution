namespace PierreBakery.Models
{
  public class TreatFlavor
    {
      
        public int TreatFlavorId { get; set; }
        public int TreatId { get; set; }
        // public string Name { get; set; }
        public int FlavorId { get; set; }
        // public string Title { get; set; }
        public Treat Treat { get; set; }
        public Flavor Flavor { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
