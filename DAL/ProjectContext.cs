﻿using DAL.Extensions;
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

            modelBuilder.Entity<Budget>()
                .Property(b => b.StartDate).HasColumnType("date");
            modelBuilder.Entity<Budget>()
                .Property(b => b.EndDate).HasColumnType("date");

            modelBuilder.Seed();
        }
    }
}
