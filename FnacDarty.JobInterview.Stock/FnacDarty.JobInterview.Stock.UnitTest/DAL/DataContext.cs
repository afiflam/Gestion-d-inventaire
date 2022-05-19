using FnacDarty.JobInterview.Stock.UnitTest.DAL.Models;
using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;
using System;

namespace FnacDarty.JobInterview.Stock.UnitTest.DAL
{
    internal class DataContext : DbContext
    {
        private static DataContext instance = null;
        private static readonly object locker = new object();


        public static DataContext Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (locker)
                    {
                        if (instance == null)
                        {
                            instance = new DataContext();
                        }
                    }
                }
                return instance;
            }
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DataContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Password=*********;Persist Security Info=True;User ID=*******;Initial Catalog=*******;Data Source=***********";
            try
            {
                optionsBuilder.UseSqlServer(connectionString, opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(30).TotalSeconds));
            }
            catch (System.Exception ex)
            {

                throw;
            }

        }

        public DbSet<FluxModel> FluxModels { get; set; }
        public DbSet<InventoryModel> InventoryModels { get; set; }
        public DbSet<ProductModel> ProductModels { get; set; }
        public DbSet<StockModel> StockModels { get; set; }

        public DbSet<FluxProductModel> FluxProductModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FluxModel>().ToTable("Flux");
            modelBuilder.Entity<InventoryModel>().ToTable("Inventory");
            modelBuilder.Entity<ProductModel>().ToTable("Product");
            modelBuilder.Entity<StockModel>().ToTable("Stock");
            modelBuilder.Entity<FluxProductModel>().ToTable("FluxProduct");

            modelBuilder.Entity<FluxProductModel>()
            .HasKey(bc => new { bc.EAN, bc.FluxID });

            modelBuilder.Entity<FluxProductModel>()
                .HasOne(bc => bc.ProductModel)
                .WithMany(b => b.FluxProductModels)
                .HasForeignKey(bc => bc.EAN);

            modelBuilder.Entity<FluxProductModel>()
                .HasOne(bc => bc.FluxModel)
                .WithMany(c => c.FluxProductModels)
                .HasForeignKey(bc => bc.FluxID);
        }
    }
     
}
