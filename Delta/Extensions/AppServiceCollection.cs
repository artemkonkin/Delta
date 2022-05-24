﻿using BaseRepositoryLib;
using DbContextLib;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RepositoriesLib;
using RepositoriesLib.Interfaces;
using ServicesLib;
using UnitOfWorkLib;

namespace Delta.Extensions
{
    public class AppServiceCollection
    {
        public static void AddDatabase(ConfigurationManager configurationManager, WebApplicationBuilder builder)
        {
            var conStrBuilder = new SqlConnectionStringBuilder(configurationManager.GetConnectionString("DbConnectionString"));
            var connection = conStrBuilder.ConnectionString;

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connection));

            builder.Services
                .AddScoped<Func<AppDbContext>>((provider) => ()
                    => provider.GetService<AppDbContext>()
                       ?? throw new InvalidOperationException())
                .AddScoped<DbFactory>()
                .AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void AddRepositories(WebApplicationBuilder builder)
        {
            builder.Services
                .AddScoped(typeof(IRepository<>), typeof(Repository<>))
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<INoteRepository, NoteRepository>();
        }

        public static void AddServices(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<NotesService>();
        }
    }
}