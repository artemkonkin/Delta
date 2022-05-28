﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 28.05.2022 19:44:56
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.ComponentModel;
using System.Reflection;
using System.Data.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using GuideDomain;

namespace DbContextLib
{

    public partial class Model : DbContext
    {

        public Model() :
            base()
        {
            OnCreated();
        }

        public Model(DbContextOptions<Model> options) :
            base(options)
        {
            OnCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured ||
                (!optionsBuilder.Options.Extensions.OfType<RelationalOptionsExtension>().Any(ext => !string.IsNullOrEmpty(ext.ConnectionString) || ext.Connection != null) &&
                 !optionsBuilder.Options.Extensions.Any(ext => !(ext is RelationalOptionsExtension) && !(ext is CoreOptionsExtension))))
            {
                optionsBuilder.UseSqlServer(@"");
                optionsBuilder.UseLazyLoadingProxies();
            }
            CustomizeConfiguration(ref optionsBuilder);
            base.OnConfiguring(optionsBuilder);
        }

        partial void CustomizeConfiguration(ref DbContextOptionsBuilder optionsBuilder);

        public virtual DbSet<GuideEntity> GuideEntities
        {
            get;
            set;
        }

        public virtual DbSet<GuideColl> GuideColls
        {
            get;
            set;
        }

        public virtual DbSet<GuidesList> GuidesLists
        {
            get;
            set;
        }

        public virtual DbSet<GuideRow> GuideRows
        {
            get;
            set;
        }

        public virtual DbSet<GuideRowCollData> GuideRowCollDatas
        {
            get;
            set;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.GuideEntityMapping(modelBuilder);
            this.CustomizeGuideEntityMapping(modelBuilder);

            this.GuideCollMapping(modelBuilder);
            this.CustomizeGuideCollMapping(modelBuilder);

            this.GuidesListMapping(modelBuilder);
            this.CustomizeGuidesListMapping(modelBuilder);

            this.GuideRowMapping(modelBuilder);
            this.CustomizeGuideRowMapping(modelBuilder);

            this.GuideRowCollDataMapping(modelBuilder);
            this.CustomizeGuideRowCollDataMapping(modelBuilder);

            RelationshipsMapping(modelBuilder);
            CustomizeMapping(ref modelBuilder);
        }

        #region GuideEntity Mapping

        private void GuideEntityMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GuideEntity>().ToTable(@"GuideEntities", @"dbo");
            modelBuilder.Entity<GuideEntity>().Property<System.Guid>(x => x.Id).HasColumnName(@"Id").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<GuideEntity>().Property<string>(x => x.Name).HasColumnName(@"Name").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<GuideEntity>().Property<System.Guid>(x => x.GuidesListId).HasColumnName(@"GuidesListId").ValueGeneratedNever();
            modelBuilder.Entity<GuideEntity>().HasKey(@"Id");
        }

        partial void CustomizeGuideEntityMapping(ModelBuilder modelBuilder);

        #endregion

        #region GuideColl Mapping

        private void GuideCollMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GuideColl>().ToTable(@"GuideColls", @"dbo");
            modelBuilder.Entity<GuideColl>().Property<System.Guid>(x => x.Id).HasColumnName(@"Id").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<GuideColl>().Property<string>(x => x.Name).HasColumnName(@"Name").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<GuideColl>().Property<GuideDomain.ItemParameterDataType>(x => x.DataType).HasColumnName(@"DataType").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<GuideColl>().Property<System.Guid>(x => x.GuideEntityId).HasColumnName(@"GuideEntityId").ValueGeneratedNever();
            modelBuilder.Entity<GuideColl>().HasKey(@"Id");
        }

        partial void CustomizeGuideCollMapping(ModelBuilder modelBuilder);

        #endregion

        #region GuidesList Mapping

        private void GuidesListMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GuidesList>().ToTable(@"GuidesLists", @"dbo");
            modelBuilder.Entity<GuidesList>().Property<System.Guid>(x => x.Id).HasColumnName(@"Id").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<GuidesList>().Property<string>(x => x.Name).HasColumnName(@"Name").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<GuidesList>().HasKey(@"Id");
        }

        partial void CustomizeGuidesListMapping(ModelBuilder modelBuilder);

        #endregion

        #region GuideRow Mapping

        private void GuideRowMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GuideRow>().ToTable(@"GuideRows", @"dbo");
            modelBuilder.Entity<GuideRow>().Property<System.Guid>(x => x.Id).HasColumnName(@"Id").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<GuideRow>().Property<System.Guid>(x => x.GuideEntityId).HasColumnName(@"GuideEntityId").ValueGeneratedNever();
            modelBuilder.Entity<GuideRow>().HasKey(@"Id");
        }

        partial void CustomizeGuideRowMapping(ModelBuilder modelBuilder);

        #endregion

        #region GuideRowCollData Mapping

        private void GuideRowCollDataMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GuideRowCollData>().ToTable(@"GuideRowCollDatas", @"dbo");
            modelBuilder.Entity<GuideRowCollData>().Property<System.Guid>(x => x.Id).HasColumnName(@"Id").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<GuideRowCollData>().Property<System.Guid>(x => x.RowId).HasColumnName(@"RowId").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<GuideRowCollData>().Property<System.Guid>(x => x.CollId).HasColumnName(@"CollId").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<GuideRowCollData>().Property<object>(x => x.Value).HasColumnName(@"Value").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<GuideRowCollData>().HasKey(@"Id");
        }

        partial void CustomizeGuideRowCollDataMapping(ModelBuilder modelBuilder);

        #endregion

        private void RelationshipsMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GuideEntity>().HasOne(x => x.GuidesList).WithMany(op => op.GuideEntities).OnDelete(DeleteBehavior.Cascade).IsRequired(true).HasForeignKey(@"GuidesListId");

            modelBuilder.Entity<GuideColl>().HasOne(x => x.GuideEntity).WithMany(op => op.GuideColls).OnDelete(DeleteBehavior.Cascade).IsRequired(true).HasForeignKey(@"GuideEntityId");
            modelBuilder.Entity<GuideColl>().HasOne(x => x.GuideRowCollData).WithOne(op => op.GuideColl).IsRequired(true).HasPrincipalKey(typeof(GuideRowCollData), @"CollId").HasForeignKey(typeof(GuideColl), @"Id");

            modelBuilder.Entity<GuideRow>().HasOne(x => x.GuideEntity).WithMany(op => op.GuideRows).OnDelete(DeleteBehavior.Cascade).IsRequired(true).HasForeignKey(@"GuideEntityId");
            modelBuilder.Entity<GuideRow>().HasOne(x => x.GuideRowCollData).WithOne(op => op.GuideRow).IsRequired(true).HasPrincipalKey(typeof(GuideRowCollData), @"RowId").HasForeignKey(typeof(GuideRow), @"Id");

            modelBuilder.Entity<GuideRowCollData>().HasOne(x => x.GuideColl).WithOne(op => op.GuideRowCollData).IsRequired(true).HasPrincipalKey(typeof(GuideRowCollData), @"CollId").HasForeignKey(typeof(GuideColl), @"Id");
            modelBuilder.Entity<GuideRowCollData>().HasOne(x => x.GuideRow).WithOne(op => op.GuideRowCollData).IsRequired(true).HasPrincipalKey(typeof(GuideRowCollData), @"RowId").HasForeignKey(typeof(GuideRow), @"Id");
        }

        partial void CustomizeMapping(ref ModelBuilder modelBuilder);

        public bool HasChanges()
        {
            return ChangeTracker.Entries().Any(e => e.State == Microsoft.EntityFrameworkCore.EntityState.Added || e.State == Microsoft.EntityFrameworkCore.EntityState.Modified || e.State == Microsoft.EntityFrameworkCore.EntityState.Deleted);
        }

        partial void OnCreated();
    }
}