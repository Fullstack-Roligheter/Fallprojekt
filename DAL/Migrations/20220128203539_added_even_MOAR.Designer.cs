﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(ProjectContext))]
    [Migration("20220128203539_added_even_MOAR")]
    partial class added_even_MOAR
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DAL.Budget", b =>
                {
                    b.Property<int>("BudgetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BudgetId"), 1L, 1);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("date");

                    b.Property<decimal>("MaxAmountMoney")
                        .HasColumnType("money");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("BudgetId");

                    b.HasIndex("UserId");

                    b.ToTable("Budgets");

                    b.HasData(
                        new
                        {
                            BudgetId = 1,
                            EndDate = new DateTime(2022, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaxAmountMoney = 5000m,
                            Name = "Default",
                            StartDate = new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 1
                        });
                });

            modelBuilder.Entity("DAL.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<int>("BudgetId")
                        .HasColumnType("int");

                    b.Property<decimal>("CategoryMaxAmount")
                        .HasColumnType("money");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.HasIndex("BudgetId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            BudgetId = 1,
                            CategoryMaxAmount = 0m,
                            Name = "Default"
                        });
                });

            modelBuilder.Entity("DAL.Expense", b =>
                {
                    b.Property<int>("ExpenseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExpenseId"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<decimal>("ExpenseAmount")
                        .HasColumnType("money");

                    b.Property<DateTime>("ExpenseDate")
                        .HasColumnType("date");

                    b.Property<string>("ExpenseRecipient")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExpenseId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Expenses");

                    b.HasData(
                        new
                        {
                            ExpenseId = 1,
                            CategoryId = 1,
                            ExpenseAmount = 500m,
                            ExpenseDate = new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ExpenseRecipient = "ICA"
                        },
                        new
                        {
                            ExpenseId = 2,
                            CategoryId = 1,
                            ExpenseAmount = 250m,
                            ExpenseDate = new DateTime(2022, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ExpenseRecipient = "Hemköp"
                        });
                });

            modelBuilder.Entity("DAL.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("UserId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Age = 20,
                            Email = "adam_01@hotmail.com",
                            Name = "Adam Adamsson",
                            Password = "password123"
                        },
                        new
                        {
                            UserId = 2,
                            Age = 30,
                            Email = "berit_02@msn.com",
                            Name = "Berit Beritsson",
                            Password = "password123"
                        });
                });

            modelBuilder.Entity("DAL.Budget", b =>
                {
                    b.HasOne("DAL.User", "User")
                        .WithMany("Budgets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Category", b =>
                {
                    b.HasOne("DAL.Budget", "Budget")
                        .WithMany("Categories")
                        .HasForeignKey("BudgetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Budget");
                });

            modelBuilder.Entity("DAL.Expense", b =>
                {
                    b.HasOne("DAL.Category", "Category")
                        .WithMany("Expenses")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("DAL.Budget", b =>
                {
                    b.Navigation("Categories");
                });

            modelBuilder.Entity("DAL.Category", b =>
                {
                    b.Navigation("Expenses");
                });

            modelBuilder.Entity("DAL.User", b =>
                {
                    b.Navigation("Budgets");
                });
#pragma warning restore 612, 618
        }
    }
}