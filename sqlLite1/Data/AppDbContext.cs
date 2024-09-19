using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sqlLite1.Models;

namespace sqlLite1.Data
{
    internal class AppDbContext : DbContext
    {
        public AppDbContext()
            : base() { }

        public DbSet<Human> Humans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("Data Source=app.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                .Entity<Human>()
                .HasMany(h => h.CreatedTasks)
                .WithOne(t => t.From)
                .HasForeignKey(t => t.FromId);
            modelBuilder
                .Entity<Human>()
                .HasMany(h => h.AssignedTasks)
                .WithOne(t => t.To)
                .HasForeignKey(t => t.ToId);
            modelBuilder
                .Entity<Human>()
                .HasData(
                    new Human
                    {
                        HumanId = 1,
                        FirstName = "Ivan",
                        LastName = "Metaje",
                    },
                    new Human
                    {
                        HumanId = 2,
                        FirstName = "Petr",
                        LastName = "Novak",
                    },
                    new Human
                    {
                        HumanId = 3,
                        FirstName = "Pavel",
                        LastName = "Dvorak",
                    }
                );
        }
    }
}
