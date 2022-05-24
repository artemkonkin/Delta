using DbContextLib;
using Delta.Extensions;
using Microsoft.EntityFrameworkCore;
using UserDomain;
using static Delta.Extensions.AppServiceCollection;

// Δ Delta

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var connectionString = builder.Configuration.GetConnectionString("DeltaContextConnection") ?? throw new InvalidOperationException("Connection string 'DeltaContextConnection' not found.");
var ext = new AppServiceCollection();

AddDatabase(configuration, builder);
AddRepositories(builder);
AddServices(builder);

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
