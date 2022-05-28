using GuideDomain;
using GuideDomain.Guide;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using NoteDomain;
using UserDomain;

namespace DbContextLib
{
    /// <summary>
    /// Data base context
    /// </summary>
    public abstract class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();

            if (!optionsBuilder.IsConfigured ||
                (!optionsBuilder.Options.Extensions.OfType<RelationalOptionsExtension>().Any(ext =>
                     !string.IsNullOrEmpty(ext.ConnectionString) || ext.Connection != null) &&
                 !optionsBuilder.Options.Extensions.Any(ext =>
                     !(ext is RelationalOptionsExtension) && !(ext is CoreOptionsExtension))))
            {
                optionsBuilder.UseSqlServer(@"");
                optionsBuilder.UseLazyLoadingProxies();
            }

            CustomizeConfiguration(ref optionsBuilder);
            base.OnConfiguring(optionsBuilder);
        }

        protected abstract void CustomizeConfiguration(ref DbContextOptionsBuilder optionsBuilder);

        /// <summary>
        /// Notes
        /// </summary>
        public DbSet<NoteEntity> Notes { get; set; }

        /// <summary>
        /// Guides
        /// </summary>
        public virtual DbSet<GuideEntity> GuideEntities { get; set; }
        public virtual DbSet<GuideCol> GuideColls { get; set; }
        public virtual DbSet<GuidesList> GuidesLists { get; set; }
        public virtual DbSet<GuideRow> GuideRows { get; set; }
        public virtual DbSet<GuideRowCollData> GuideRowCollDatas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            GuideEntityMapping(modelBuilder);
            CustomizeGuideEntityMapping(modelBuilder);

            GuideCollMapping(modelBuilder);
            CustomizeGuideCollMapping(modelBuilder);

            GuidesListMapping(modelBuilder);
            CustomizeGuidesListMapping(modelBuilder);

            GuideRowMapping(modelBuilder);
            CustomizeGuideRowMapping(modelBuilder);

            GuideRowCollDataMapping(modelBuilder);
            CustomizeGuideRowCollDataMapping(modelBuilder);

            RelationshipsMapping(modelBuilder);
            CustomizeMapping(ref modelBuilder);
        }

        #region GuideEntity Mapping

        private void GuideEntityMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GuideEntity>().ToTable(@"GuideEntities", @"dbo");
            modelBuilder.Entity<GuideEntity>().Property<Guid>(x => x.Id).HasColumnName(@"Id").IsRequired()
                .ValueGeneratedNever();
            modelBuilder.Entity<GuideEntity>().Property<string>(x => x.Name).HasColumnName(@"Name").IsRequired()
                .ValueGeneratedNever();
            modelBuilder.Entity<GuideEntity>().Property<Guid>(x => x.GuidesListId).HasColumnName(@"GuidesListId")
                .ValueGeneratedNever();
            modelBuilder.Entity<GuideEntity>().HasKey(@"Id");
        }

        private void CustomizeGuideEntityMapping(ModelBuilder modelBuilder)
        {
        }

        #endregion

        #region GuideColl Mapping

        private void GuideCollMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GuideCol>().ToTable(@"GuideColls", @"dbo");
            modelBuilder.Entity<GuideCol>().Property<Guid>(x => x.Id).HasColumnName(@"Id").IsRequired()
                .ValueGeneratedNever();
            modelBuilder.Entity<GuideCol>().Property<string>(x => x.Name).HasColumnName(@"Name").IsRequired()
                .ValueGeneratedNever();
            modelBuilder.Entity<GuideCol>().Property<ItemParameterDataType>(x => x.DataType)
                .HasColumnName(@"DataType").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<GuideCol>().Property<Guid>(x => x.GuideEntityId).HasColumnName(@"GuideEntityId")
                .ValueGeneratedNever();
            modelBuilder.Entity<GuideCol>().HasKey(@"Id");
        }

        private void CustomizeGuideCollMapping(ModelBuilder modelBuilder)
        {
        }

        #endregion

        #region GuidesList Mapping

        private void GuidesListMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GuidesList>().ToTable(@"GuidesLists", @"dbo");
            modelBuilder.Entity<GuidesList>().Property<Guid>(x => x.Id).HasColumnName(@"Id").IsRequired()
                .ValueGeneratedNever();
            modelBuilder.Entity<GuidesList>().Property<string>(x => x.Name).HasColumnName(@"Name").IsRequired()
                .ValueGeneratedNever();
            modelBuilder.Entity<GuidesList>().HasKey(@"Id");
        }

        private void CustomizeGuidesListMapping(ModelBuilder modelBuilder)
        {
        }

        #endregion

        #region GuideRow Mapping

        private void GuideRowMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GuideRow>().ToTable(@"GuideRows", @"dbo");
            modelBuilder.Entity<GuideRow>().Property<Guid>(x => x.Id).HasColumnName(@"Id").IsRequired()
                .ValueGeneratedNever();
            modelBuilder.Entity<GuideRow>().Property<Guid>(x => x.GuideEntityId).HasColumnName(@"GuideEntityId")
                .ValueGeneratedNever();
            modelBuilder.Entity<GuideRow>().HasKey(@"Id");
        }

        private void CustomizeGuideRowMapping(ModelBuilder modelBuilder)
        {
        }

        #endregion

        #region GuideRowCollData Mapping

        private void GuideRowCollDataMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GuideRowCollData>().ToTable(@"GuideRowCollDatas", @"dbo");
            modelBuilder.Entity<GuideRowCollData>().Property<Guid>(x => x.RowId).HasColumnName(@"Id").IsRequired()
                .ValueGeneratedNever();
            modelBuilder.Entity<GuideRowCollData>().Property<Guid>(x => x.RowId).HasColumnName(@"RowId")
                .IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<GuideRowCollData>().Property<Guid>(x => x.CollId).HasColumnName(@"CollId")
                .IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<GuideRowCollData>().Property<object>(x => x.Value).HasColumnName(@"Value").IsRequired()
                .ValueGeneratedNever();
            modelBuilder.Entity<GuideRowCollData>().HasKey(@"Id");
        }

        private void CustomizeGuideRowCollDataMapping(ModelBuilder modelBuilder)
        {
        }

        #endregion

        private void RelationshipsMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GuideEntity>().HasOne(x => x.GuidesList).WithMany(op => op.GuideEntities)
                .OnDelete(DeleteBehavior.Cascade).IsRequired(true).HasForeignKey(@"GuidesListId");

            modelBuilder.Entity<GuideCol>().HasOne(x => x.GuideEntity).WithMany(op => op.GuideCols)
                .OnDelete(DeleteBehavior.Cascade).IsRequired(true).HasForeignKey(@"GuideEntityId");
            modelBuilder.Entity<GuideCol>().HasOne(x => x.GuideRowCollData).WithOne(op => op.GuideCol)
                .IsRequired(true).HasPrincipalKey(typeof(GuideRowCollData), @"CollId")
                .HasForeignKey(typeof(GuideCol), @"Id");

            modelBuilder.Entity<GuideRow>().HasOne(x => x.GuideEntity).WithMany(op => op.GuideRows)
                .OnDelete(DeleteBehavior.Cascade).IsRequired(true).HasForeignKey(@"GuideEntityId");
            modelBuilder.Entity<GuideRow>().HasOne(x => x.GuideRowCollData).WithOne(op => op.GuideRow).IsRequired(true)
                .HasPrincipalKey(typeof(GuideRowCollData), @"RowId").HasForeignKey(typeof(GuideRow), @"Id");

            modelBuilder.Entity<GuideRowCollData>().HasOne(x => x.GuideCol).WithOne(op => op.GuideRowCollData)
                .IsRequired(true).HasPrincipalKey(typeof(GuideRowCollData), @"CollId")
                .HasForeignKey(typeof(GuideCol), @"Id");
            modelBuilder.Entity<GuideRowCollData>().HasOne(x => x.GuideRow).WithOne(op => op.GuideRowCollData)
                .IsRequired(true).HasPrincipalKey(typeof(GuideRowCollData), @"RowId")
                .HasForeignKey(typeof(GuideRow), @"Id");
        }

        private void CustomizeMapping(ref ModelBuilder modelBuilder)
        {
        }

        public bool HasChanges()
        {
            return ChangeTracker.Entries().Any(e =>
                e.State == EntityState.Added ||
                e.State == EntityState.Modified ||
                e.State == EntityState.Deleted);
        }

        private void OnCreated()
        {
        }
    }
}