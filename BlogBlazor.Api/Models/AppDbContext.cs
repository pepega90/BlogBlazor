using BlogBlazor.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogBlazor.Api.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Kategori>().HasData(new Kategori
            {
                Id = 1,
                KategoriName = "Programming"
            });

            modelBuilder.Entity<Kategori>().HasData(new Kategori
            {
                Id = 2,
                KategoriName = "Breaking News"
            });
        }
    }
}
