using System.Collections.Generic;

public namespace Bakery.Models
{
  public class Treat
  {
    public Treat()
    {
      this.Flavor = Hashset<FlavorTreat>();
    }

    public int TreatId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<FlavorTreat> Flavors { get; set; }
  }
}