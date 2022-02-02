using DAL.Extensions;
using DAL.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProjectContext : DbContext
    {
        public DbSet <User> User { get; set; } //Lägg tabeller här
        public DbSet<Expense> Expense { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            var serverAddress = "localhost\\SQLEXPRESS";
            var databaseName = "Fallprojekt_DB";
            var connectionString = @"Server =" + serverAddress + "; Database =" + databaseName + "; Integrated Security = true;";
            builder
                .UseSqlServer(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.UserId);

            modelBuilder.Seed();
        }
    }
}
