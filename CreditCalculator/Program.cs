using CreditCalculator.Services;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<ICreditCalculator, MainCreditCalculator>();

CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-us");

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Credit}/{action=Basic}");

app.Run();
