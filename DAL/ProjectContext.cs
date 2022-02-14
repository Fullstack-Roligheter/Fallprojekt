using DAL.Extensions;
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
        public DbSet <Budget> Budgets { get; set; }
        public DbSet <Category> Categories { get; set; }
        public DbSet <Expense> Expense { get; set; }
        public DbSet <Category> Category { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            var serverAddress = ".";
            var databaseName = "Fallprojekt_DB2";
            var connectionString = @"Server =" + serverAddress + "; Database =" + databaseName + "; Integrated Security = true;";
            builder
                .UseSqlServer(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Budget>()
                .Property(b => b.BudgetStartDate).HasColumnType("date"); //Vi specifierar att kolumnen "StartDate" har en SQL datatyp av sorten "date"
            modelBuilder.Entity<Budget>()
                .Property(b => b.BudgetEndDate).HasColumnType("date");
            modelBuilder.Entity<Budget>()
                .Property(b => b.BudgetMaxAmountMoney).HasColumnType("money");

            modelBuilder.Entity<Category>()
                .Property(c => c.CategoryMaxAmount).HasColumnType("money");

            modelBuilder.Entity<Expense>()
                .Property(e => e.ExpenseDate).HasColumnType("date");
            modelBuilder.Entity<Expense>()
                .Property(e => e.ExpenseAmount).HasColumnType("money");


            modelBuilder.Entity<Budget>() //En USER kan ha MÅNGA Budgets. FK är Budgets.UserId på MÅNGA sidan
                .HasOne<User>(u => u.User)
                .WithMany(b => b.Budgets)
                .HasForeignKey(b => b.UserId);

            modelBuilder.Entity<Category>()
                .HasOne<Budget>(b => b.Budget)
                .WithMany(c => c.Categories)
                .HasForeignKey(c => c.BudgetId);

            modelBuilder.Entity<Expense>()
                .HasOne<Category>(c => c.Category)
                .WithMany(e => e.Expenses)
                .HasForeignKey(e => e.CategoryId);

            modelBuilder.Entity<User>()
                .Property(u => u.UserAge)
                .HasDefaultValue(0);

            modelBuilder.Seed();
        }
    }
}
