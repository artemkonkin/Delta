using BaseRepositoryLib;
using DbContextLib;
using DirectoryServiceLib;
using DirectoryServiceLib.Interface;
using Microsoft.AspNetCore.Identity;
using RepositoriesLib.Interfaces.Directory;
using RepositoriesLib.Interfaces.Note;
using RepositoriesLib.Repositories.Directory;
using RepositoriesLib.Repositories.Note;
using UnitOfWorkLib;

namespace Delta.Extensions
{
    /// <summary>
    /// Расширение сервисных функций
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Authentication config
        /// </summary>
        /// <param name="services"></param>
        public static void AddAuthConfiguration(this IServiceCollection services)
        {
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });
        }

        /// <summary>
        /// Repositories
        /// </summary>
        /// <param name="services"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public static void AddRepositories(this IServiceCollection services)
        {
            // Repository
            services.AddScoped<Func<AppDbContext>>((provider) => ()
                => provider.GetService<AppDbContext>()
                   ?? throw new InvalidOperationException());
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // Note
            services.AddScoped<INoteRepository, NoteRepository>();

            // Directory
            services.AddScoped<IDirectoryListRepository, DirectoryListRepository>();
            services.AddScoped<IDirectoryEntityRepository, DirectoryEntityRepository>();
            services.AddScoped<IDirectoryRowRepository, DirectoryRowRepository>();
            services.AddScoped<IDirectoryColRepository, DirectoryColRepository>();
            services.AddScoped<IDirectoryRowColDataRepository, DirectoryRowColDataRepository>();
            services.AddScoped<IDirectoryRepository>();
        }

        /// <summary>
        /// Services
        /// </summary>
        /// <param name="services"></param>
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IDirectoryListService, DirectoryListService>();
        }

        /// <summary>
        /// Infrestructure
        /// </summary>
        /// <param name="services"></param>
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<DbFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}