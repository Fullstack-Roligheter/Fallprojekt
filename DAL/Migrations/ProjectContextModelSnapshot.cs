﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(ProjectContext))]
    partial class ProjectContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<DateTime>("BudgetEndDate")
                        .HasColumnType("date");

                    b.Property<decimal?>("BudgetMaxAmountMoney")
                        .HasColumnType("money");

                    b.Property<string>("BudgetName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BudgetStartDate")
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
                            BudgetEndDate = new DateTime(2022, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            BudgetMaxAmountMoney = 0m,
                            BudgetName = "Default",
                            BudgetStartDate = new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 1
                        },
                        new
                        {
                            BudgetId = 2,
                            BudgetEndDate = new DateTime(2022, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            BudgetMaxAmountMoney = 0m,
                            BudgetName = "Vår 2022",
                            BudgetStartDate = new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 1
                        },
                        new
                        {
                            BudgetId = 3,
                            BudgetEndDate = new DateTime(2022, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            BudgetMaxAmountMoney = 0m,
                            BudgetName = "Sommar 2022",
                            BudgetStartDate = new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 1
                        },
                        new
                        {
                            BudgetId = 4,
                            BudgetEndDate = new DateTime(2022, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            BudgetMaxAmountMoney = 0m,
                            BudgetName = "Default",
                            BudgetStartDate = new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 2
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

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.HasIndex("BudgetId");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            BudgetId = 1,
                            CategoryMaxAmount = 1000m,
                            CategoryName = "Default"
                        },
                        new
                        {
                            CategoryId = 2,
                            BudgetId = 1,
                            CategoryMaxAmount = 1500m,
                            CategoryName = "Hem & Hushåll"
                        },
                        new
                        {
                            CategoryId = 3,
                            BudgetId = 2,
                            CategoryMaxAmount = 1500m,
                            CategoryName = "Home Stuff Vår 2022"
                        },
                        new
                        {
                            CategoryId = 4,
                            BudgetId = 2,
                            CategoryMaxAmount = 1500m,
                            CategoryName = "Other Stuff Vår 2022"
                        },
                        new
                        {
                            CategoryId = 5,
                            BudgetId = 3,
                            CategoryMaxAmount = 1500m,
                            CategoryName = "Home Stuff Sommar 2022"
                        },
                        new
                        {
                            CategoryId = 6,
                            BudgetId = 3,
                            CategoryMaxAmount = 1500m,
                            CategoryName = "Other Stuff Sommar 2022"
                        },
                        new
                        {
                            CategoryId = 7,
                            BudgetId = 4,
                            CategoryMaxAmount = 1000m,
                            CategoryName = "Default"
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

                    b.Property<string>("ExpenseComment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpenseDate")
                        .HasColumnType("date");

                    b.Property<string>("ExpenseRecipient")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExpenseId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Expense");

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
                        },
                        new
                        {
                            ExpenseId = 3,
                            CategoryId = 3,
                            ExpenseAmount = 250m,
                            ExpenseDate = new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ExpenseRecipient = "Vår HOME ICA 2022"
                        },
                        new
                        {
                            ExpenseId = 4,
                            CategoryId = 3,
                            ExpenseAmount = 250m,
                            ExpenseDate = new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ExpenseRecipient = "Vår HOME IKEA 2022"
                        },
                        new
                        {
                            ExpenseId = 5,
                            CategoryId = 4,
                            ExpenseAmount = 250m,
                            ExpenseDate = new DateTime(2022, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ExpenseRecipient = "Vår OTHER Hemköp 2022"
                        },
                        new
                        {
                            ExpenseId = 6,
                            CategoryId = 4,
                            ExpenseAmount = 250m,
                            ExpenseDate = new DateTime(2022, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ExpenseRecipient = "Vår OTHER ICA 2022"
                        },
                        new
                        {
                            ExpenseId = 7,
                            CategoryId = 5,
                            ExpenseAmount = 250m,
                            ExpenseDate = new DateTime(2022, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ExpenseRecipient = "Sommar HOME ICA 2022"
                        },
                        new
                        {
                            ExpenseId = 8,
                            CategoryId = 5,
                            ExpenseAmount = 250m,
                            ExpenseDate = new DateTime(2022, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ExpenseRecipient = "Sommar HOME IKEA 2022"
                        },
                        new
                        {
                            ExpenseId = 9,
                            CategoryId = 6,
                            ExpenseAmount = 250m,
                            ExpenseDate = new DateTime(2022, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ExpenseRecipient = "Sommar OTHER Hemköp 2022"
                        },
                        new
                        {
                            ExpenseId = 10,
                            CategoryId = 6,
                            ExpenseAmount = 250m,
                            ExpenseDate = new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ExpenseRecipient = "Sommar OTHER ICA 2022"
                        });
                });

            modelBuilder.Entity("DAL.Models.SavingPlan", b =>
                {
                    b.Property<int>("SavingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SavingId"), 1L, 1);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlanEndDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlanStartDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SavingId");

                    b.ToTable("Savingplan");
                });

            modelBuilder.Entity("DAL.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<int>("UserAge")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            UserAge = 20,
                            UserEmail = "adam_01@hotmail.com",
                            UserName = "adam",
                            UserPassword = "123"
                        },
                        new
                        {
                            UserId = 2,
                            UserAge = 30,
                            UserEmail = "berit_02@msn.com",
                            UserName = "berit",
                            UserPassword = "123"
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
