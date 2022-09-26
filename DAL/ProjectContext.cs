using DAL.Extensions;
using DAL.Models;
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
        public DbSet <User> Users { get; set; } //Lägg tabeller här
        public DbSet <Budget> Budgets { get; set; }
        public DbSet <Category> Categories { get; set; }
        public DbSet <Debit> Debits { get; set; }
        public DbSet<SavingPlan> Savingplans { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {

            var serverAddress = "localhost\\SQLEXPRESS";
            var databaseName = "Fallprojekt_DB_v2";
            var connectionString = @"Server =" + serverAddress + "; Database =" + databaseName + "; Integrated Security = true;";
            builder
                .UseSqlServer(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Budget>()
                .Property(b => b.StartDate).HasColumnType("date");
            modelBuilder.Entity<Budget>()
                .Property(b => b.EndDate).HasColumnType("date");
            modelBuilder.Entity<Budget>()
                .Property(b => b.Amount).HasColumnType("money");

            modelBuilder.Entity<Debit>()
                .Property(e => e.Date).HasColumnType("date");
            modelBuilder.Entity<Debit>()
                .Property(e => e.Amount).HasColumnType("money");

            modelBuilder.Entity<SavingPlan>()
                .Property(e => e.StartDate).HasColumnType("date");
            modelBuilder.Entity<SavingPlan>()
               .Property(e => e.EndDate).HasColumnType("date");


            modelBuilder.Entity<Budget>() //En USER kan ha MÅNGA Budgets. FK är Budgets.UserId på MÅNGA sidan
                .HasOne<User>(u => u.User)
                .WithMany(b => b.Budgets)
                .HasForeignKey(b => b.UserId);

            modelBuilder.Entity<Category>()
                .HasOne<User>(u => u.User)
                .WithMany(c => c.Categories)
                .HasForeignKey(c => c.UserId);

            //modelBuilder.Entity<Debit>()
            //    .HasOne<Category>(c => c.Category)
            //    .WithMany(d => d.Debits)
            //    .HasForeignKey(d => d.CategoryId);

            modelBuilder.Entity<Debit>()
                .HasOne<Budget>(b => b.Budget)
                .WithMany(d => d.Debits)
                .HasForeignKey(d => d.BudgetId);

            modelBuilder.Entity<Debit>()
                .HasOne<User>(u => u.User)
                .WithMany(d => d.Debits)
                .HasForeignKey(d => d.UserId);

            modelBuilder.Seed();
        }
    }
}
