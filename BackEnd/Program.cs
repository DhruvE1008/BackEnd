using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using IceCreamStore.Data;
using IceCreamStore.Models;
using IceCreamStore.DB;

var builder = WebApplication.CreateBuilder(args);

var connectionString = Environment.GetEnvironmentVariable("IceCreams_ConnectionString") ?? "Data Source=IceCreams.db";
    
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<IceCreamContext>(options => options.UseInMemoryDatabase("items"));
builder.Services.AddSwaggerGen(c =>
{
     c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ice Cream Store", Description = "We hope you love Ice Cream as much as we do!", Version  = "v1"});
});
    

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<IceCreamContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IceCreamShop v1"));
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

// Seed the database
using (var scope = app.Services.CreateScope())
{
   var services = scope.ServiceProvider;
   var dbContext = services.GetRequiredService<IceCreamContext>();
   Db.Initialize(dbContext);
}

app.Run();