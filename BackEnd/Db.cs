using Microsoft.EntityFrameworkCore;
namespace IceCreamStore.DB; 

 public record IceCream 
 {
   public int Id {get; set;} 
   public string ? Name { get; set; }
 }

 public class IceCreamDB
 {
   private static List<IceCream> _iceCreams = new List<IceCream>()
   {
     new IceCream{ Id=1, Name="Vanilla" },
     new IceCream{ Id=2, Name="Chocolate"},
     new IceCream{ Id=3, Name="Strawberry"}, 
     new IceCream{ Id=4, Name="Hokey Pokey"},
     new IceCream{ Id=5, Name="Butterscotch"},
     new IceCream{ Id=6, Name="Cookies and Cream"},
     new IceCream{ Id=7, Name="Bubblegum"},
     new IceCream{ Id=8, Name="Mint"},
     new IceCream{ Id=9, Name="Neapolitan"}
   };

   public static List<IceCream> GetIceCreams() 
   {
     return _iceCreams;
   } 

   public static IceCream ? GetIceCream(int id) 
   {
     return _iceCreams.SingleOrDefault(iceCream => iceCream.Id == id);
   } 

   public static IceCream CreateIceCream(IceCream iceCream) 
   {
     _iceCreams.Add(iceCream);
     return iceCream;
   }

   public static IceCream UpdateIceCream(IceCream update) 
   {
     _iceCreams = _iceCreams.Select(iceCream =>
     {
       if (iceCream.Id == update.Id)
       {
         iceCream.Name = update.Name;
       }
       return iceCream;
     }).ToList();
     return update;
   }

   public static void RemoveIceCream(int id)
   {
     _iceCreams = _iceCreams.FindAll(pizza => pizza.Id != id).ToList();
   }
 }