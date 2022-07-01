using BaseRepositoryLib;
using DbContextLib;
using DirectoriesLib.Directory;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RepositoriesLib;
using RepositoriesLib.Interfaces;
using RepositoriesLib.Interfaces.Directory;
using UnitOfWorkLib;
using UserDomain;

// Δ Delta

var builder = WebApplication.CreateBuilder(args);
var conStrBuilder = new SqlConnectionStringBuilder(builder.Configuration.GetConnectionString("DeltaConnectionString"));
var connection = conStrBuilder.ConnectionString;

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connection));
builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AppDbContext>();

// MVC

builder.Services.AddControllersWithViews();

// REPOSITORIES

builder.Services.AddScoped<Func<AppDbContext>>((provider) => ()
    => provider.GetService<AppDbContext>()
       ?? throw new InvalidOperationException());
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IDirectoryListRepository, DirectoryListRepository>();
builder.Services.AddScoped<INoteRepository, NoteRepository>();
builder.Services.AddScoped<DbFactory>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// SERVICES

builder.Services.AddTransient<IDirectoryListService, DirectoryListService>();

// APP

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