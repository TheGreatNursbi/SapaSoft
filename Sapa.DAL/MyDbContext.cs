using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Sapa.DAL.Models;

namespace Sapa.DAL
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Builder>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("PK_Builder");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasColumnType("nvarchar(100)");

                entity.Property(e => e.Name)
                   .IsRequired()
                   .HasColumnName("name")
                   .HasColumnType("nvarchar(100)");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasColumnName("isdeleted")
                    .HasColumnType("bit")
                    .HasDefaultValue(false);

                entity.Property(e => e.ActivityStartDate)
                    .IsRequired()
                    .HasColumnName("activitystartdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.BIN)
                    .IsRequired()
                    .HasColumnName("BIN")
                    .HasColumnType("varchar(100)");

                entity.HasData(
                    new Builder
                    {
                        Id = 1,
                        Name = "BI Group",
                        BIN = "1234-4567-7894-1236",
                        ActivityStartDate = DateTime.Today,
                        Address = "Yrghyz 11",
                        IsDeleted = false
                    });
            });

            modelBuilder.Entity<Building>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_Building");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasColumnType("nvarchar(100)");

                entity.Property(e => e.Height)
                    .IsRequired()
                    .HasColumnName("height")
                    .HasColumnType("int");

                entity.Property(e => e.Floors)
                    .IsRequired()
                    .HasColumnName("floors")
                    .HasColumnType("int");

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasColumnName("price")
                    .HasColumnType("int");

                entity.Property(e => e.Name)
                   .IsRequired()
                   .HasColumnName("name")
                   .HasColumnType("nvarchar(100)");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasColumnName("isdeleted")
                    .HasColumnType("bit")
                    .HasDefaultValue(false);

                entity.HasOne<Builder>(s => s.Builder)
                    .WithMany(g => g.Buildings)
                    .HasForeignKey(s => s.BuilderId);

                entity.HasData(
                    new Building
                    {
                        Id = 1,
                        Name = "Shanyrak",
                        Height = 100,
                        Floors = 20,
                        Address = "Imanbayeva",
                        Price = 150000,
                        IsDeleted = false,
                        BuilderId = 1
                    });
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=localhost;initial catalog=sapasoftware_testdb;integrated security=True;");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Builder> Builders { get; set; }
        public DbSet<Building> Buildings { get; set; }
    }
}
