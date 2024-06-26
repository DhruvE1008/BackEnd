using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;

using IceCreamStore.DB;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("IceCreams") ?? "Data Source=IceCreams.db";
    
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<IceCreamDb>(options => options.UseInMemoryDatabase("items"));
builder.Services.AddSwaggerGen(c =>
{
     c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ice Cream Store", Description = "We hope you love Ice Cream as much as we do!", Version  = "v1"});
});
    
var app = builder.Build();
    
if (app.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI(c =>
   {
      c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ice Cream Store");
   });
}
   
app.MapGet("/iceCreams/{id}", (int id) => IceCreamDB.GetIceCream(id));
app.MapGet("/iceCreams", () => IceCreamDB.GetIceCreams());
app.MapPost("/iceCreams", (IceCream iceCream) => IceCreamDB.CreateIceCream(iceCream));
app.MapPut("/iceCreams", (IceCream iceCream) => IceCreamDB.UpdateIceCream(iceCream));
app.MapDelete("/iceCreams/{id}", (int id) => IceCreamDB.RemoveIceCream(id));
app.MapGet("/pizzas", async (IceCreamDb db) => await db.IceCreams.ToListAsync());
app.MapPost("/pizza", async (IceCreamDb db, IceCream iceCream) =>
{
    await db.IceCreams.AddAsync(iceCream);
    await db.SaveChangesAsync();
    return Results.Created($"/iceCream/{iceCream.Id}", iceCream);
});
app.MapGet("/iceCream/{id}", async (IceCreamDb db, int id) => await db.IceCreams.FindAsync(id));
app.MapPut("/iceCream/{id}", async (IceCreamDb db, IceCream updateiceCream, int id) =>
{
      var iceCream = await db.IceCreams.FindAsync(id);
      if (iceCream is null) return Results.NotFound();
      iceCream.Name = updateiceCream.Name;
      await db.SaveChangesAsync();
      return Results.NoContent();
});
app.MapDelete("/iceCream/{id}", async (IceCreamDb db, int id) =>
{
   var iceCream = await db.IceCreams.FindAsync(id);
   if (iceCream is null)
   {
      return Results.NotFound();
   }
   db.IceCreams.Remove(iceCream);
   await db.SaveChangesAsync();
   return Results.Ok();
});

app.Run();