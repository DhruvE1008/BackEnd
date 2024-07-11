using IceCreamStore.Models;
using IceCreamStore.Data;

namespace IceCreamStore.DB {
 public static class Db
 {
  public static void Initialize(IceCreamContext context) {
    var flavours = new Flavour[] {
      new Flavour { Name = "Vanilla", Type = "IceCream" },
      new Flavour { Name = "Chocolate", Type = "IceCream" },
      new Flavour { Name = "Strawberry", Type = "IceCream" },
      new Flavour { Name = "Hokey Pokey", Type = "IceCream" },
      new Flavour { Name = "Butterscotch", Type = "IceCream" },
      new Flavour { Name = "Cookies and Cream", Type = "IceCream" },
      new Flavour { Name = "Bubblegum", Type = "IceCream" },
      new Flavour { Name = "Mint", Type = "IceCream" },
      new Flavour { Name = "Neapolitan", Type = "IceCream" },
      new Flavour { Name = "Lemonade", Type = "Popsicle" },
      new Flavour { Name = "Apple", Type = "Popsicle" },
      new Flavour { Name = "Orange", Type = "Popsicle" },
      new Flavour { Name = "Pineapple", Type = "Popsicle" },
      new Flavour { Name = "Raspberry", Type = "Popsicle" },
      new Flavour { Name = "Mango", Type = "Popsicle" },
      new Flavour { Name = "Banana", Type = "Popsicle" },
      new Flavour { Name = "Grape", Type = "Popsicle" },
      new Flavour { Name = "Kiwifruit", Type = "Popsicle" },
      new Flavour { Name = "Vanilla", Type = "IceCreamSandwich" },
      new Flavour { Name = "Chocolate", Type = "IceCreamSandwich" },
      new Flavour { Name = "Strawberry", Type = "IceCreamSandwich" },
      new Flavour { Name = "Hokey Pokey", Type = "IceCreamSandwich" },
      new Flavour { Name = "Butterscotch", Type = "IceCreamSandwich" },
      new Flavour { Name = "Cookies and Cream", Type = "IceCreamSandwich" },
      new Flavour { Name = "Bubblegum", Type = "IceCreamSandwich" },
      new Flavour { Name = "Mint", Type = "IceCreamSandwich" },
      new Flavour { Name = "Neapolitan", Type = "IceCreamSandwich" },
    };
            foreach (var flavour in flavours)
            {
                context.Flavours.Add(flavour);
            }

            context.SaveChanges();
        }
 }
}
 