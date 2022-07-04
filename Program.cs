using Microsoft.EntityFrameworkCore;
using Proj1.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Electricity_BillContext>(value =>

    value.UseSqlServer(builder.Configuration.GetConnectionString("Electricity_BillContext") ?? throw new InvalidOperationException("Connection string 'Electricity_BillContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Bill/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Bill}/{action=Index}/{id?}");

app.Run();



//  (localdb)\\mssqllocaldb