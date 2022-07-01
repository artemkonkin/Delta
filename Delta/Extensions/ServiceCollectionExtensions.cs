using BaseRepositoryLib;
using DbContextLib;
using DirectoriesLib;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RepositoriesLib;
using RepositoriesLib.Interfaces;
using RepositoriesLib.Interfaces.Directory;
using UnitOfWorkLib;
using UserDomain;

namespace Delta.Extensions
{
    /// <summary>
    /// Расширение сервисных функций
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Настройка соединения с базой данных
        /// </summary>
        /// <param name="services"> Коллекция сервисов </param>
        /// <param name="configuration"> Конфигуратор </param>
        /// <returns></returns>
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var conStrBuilder = new SqlConnectionStringBuilder(configuration.GetConnectionString("DeltaConnectionString"));
            var connection = conStrBuilder.ConnectionString;

            services.AddDbContext<AppDbContext>(options => { options.UseSqlServer(connection); });
            services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<AppDbContext>();

            services.AddControllersWithViews();

            return services;
        }

        /// <summary>
        /// Добавление репозиториев
        /// </summary>
        /// <param name="services"> Коллекция сервисов </param>
        /// <returns></returns>
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<Func<AppDbContext>>((provider) => ()
                => provider.GetService<AppDbContext>()
                   ?? throw new InvalidOperationException());

            services.AddScoped<DbFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IDirectoryListRepository, DirectoryListRepository>();
            services.AddScoped<INoteRepository, NoteRepository>();

            return services;
        }

        /// <summary>
        /// Добавить сервисы
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<NotesService>();
            // services.AddScoped<DirectoryListService>();

            return services;
        }
    }
}