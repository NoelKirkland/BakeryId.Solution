using System.Collections.Generic;

public namespace Bakery.Models
{
  public class Flavor
  {
    public Flavor()
    {
      this.Treat = HashSet<FlavorTreat>();
    }

    public int FlavorId { get; set; }
    public string Name { get; set; }
    public virtual ICollections<FlavorTreat> Flavors { get; set; }
  }
}