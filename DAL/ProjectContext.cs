using DAL.Extensions;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DAL;

public class ProjectContext : DbContext
{
    public DbSet <User> Users { get; set; }
    public DbSet <Budget> Budgets { get; set; }
    public DbSet <Category> Categories { get; set; }
    public DbSet <Debit> Debits { get; set; }
    public DbSet<SavingPlan> SavingPlans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        var serverAddress = "localhost\\SQLEXPRESS";
        var databaseName = "Fallprojekt_DB_v3";
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


        modelBuilder.Entity<Budget>()
            .HasOne(u => u.User)
            .WithMany(b => b.Budgets)
            .HasForeignKey(b => b.UserId);

        modelBuilder.Entity<Category>()
            .HasOne(u => u.User)
            .WithMany(c => c.Categories)
            .HasForeignKey(c => c.UserId);

        modelBuilder.Entity<Debit>()
            .HasOne(b => b.Budget)
            .WithMany(d => d.Debits)
            .HasForeignKey(d => d.BudgetId);

        modelBuilder.Entity<Debit>()
            .HasOne(u => u.User)
            .WithMany(d => d.Debits)
            .HasForeignKey(d => d.UserId);

        modelBuilder.Seed();
    }
}