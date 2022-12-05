using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi
{
    public class CatalogDbContext : DbContext
    {
        public CatalogDbContext(DbContextOptions<CatalogDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .HasOne(item => item.Category)
                .WithMany(category => category.Items)
                .HasForeignKey(item => item.CategoryId);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Notebooks" });
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 2, Name = "Phones" });

            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 1,
                Name = "MacBook",
                CategoryId = 1
            });

            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 2,
                Name = "Asus",
                CategoryId = 1
            });

            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 3,
                Name = "Iphone",
                CategoryId = 2
            });

            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 4,
                Name = "Nokia",
                CategoryId = 2
            });
        }
    }
}
