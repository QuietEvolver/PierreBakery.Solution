using System.Collections.Generic;
namespace PierreBakery.Models
{
  public class Author
    {
      public Author()
      {
        this.Books = new HashSet<AuthorBook>();
      }
      public int AuthorId { get; set; }
      public string Name { get; set; }

      public ICollection<AuthorBook> Books { get;}
      public virtual ApplicationUser User { get; set; }
    }
}
