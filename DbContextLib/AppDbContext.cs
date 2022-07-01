using DirectoryDomain;
using DirectoryDomain.Directory;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NoteDomain;
using UserDomain;
using DirectoryRowColData = DirectoryDomain.ViewModels.DirectoryRowColData;

namespace DbContextLib
{
    /// <summary>
    /// Data base context
    /// </summary>
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Notes
        /// </summary>
        public DbSet<NoteEntity> Notes { get; set; }

        /// <summary>
        /// Directories
        /// </summary>
        public virtual DbSet<DirectoriesList> DirectoriesLists { get; set; }
        public virtual DbSet<DirectoryEntity> DirectoriesEntities { get; set; }
        public virtual DbSet<DirectoryCol> DirectoriesCols { get; set; }
        public virtual DbSet<DirectoryRow> DirectoriesRows { get; set; }
        public virtual DbSet<DirectoryRowColData> DirectoriesRowsColsData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}