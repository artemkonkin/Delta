using GuideDomain;
using GuideDomain.Guide;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using NoteDomain;
using UserDomain;

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
        /// Guides
        /// </summary>
        public virtual DbSet<GuidesList> GuidesLists { get; set; }
        public virtual DbSet<GuideEntity> GuidesEntities { get; set; }
        public virtual DbSet<GuideCol> GuidesCols { get; set; }
        public virtual DbSet<GuideRow> GuidesRows { get; set; }
        public virtual DbSet<GuideRowColData> GuidesRowsColsData { get; set; }

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