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
    [Migration("20221013132340_Initial")]
    partial class Initial
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
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("Amount")
                        .HasColumnType("money");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Budgets");

                    b.HasData(
                        new
                        {
                            Id = new Guid("496ef686-6b83-4c24-9e0f-d6f51b29fad2"),
                            Amount = 6000m,
                            EndDate = new DateTime(2022, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Nya möbler",
                            StartDate = new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1")
                        },
                        new
                        {
                            Id = new Guid("d96f9337-0b84-4a79-9977-d27125420898"),
                            Amount = 3000m,
                            EndDate = new DateTime(2022, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Julklappar",
                            StartDate = new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1")
                        },
                        new
                        {
                            Id = new Guid("fe0219cc-eb57-417e-b07b-87aa2784a92b"),
                            Amount = 12000m,
                            EndDate = new DateTime(2023, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Ny Dator",
                            StartDate = new DateTime(2022, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("720892b1-b076-49ec-8ec2-88b73040b351")
                        },
                        new
                        {
                            Id = new Guid("7264a099-8b0e-4953-a548-fa62dd2fad4a"),
                            Amount = 1000m,
                            EndDate = new DateTime(2022, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Film o Pizza kväll",
                            StartDate = new DateTime(2022, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("720892b1-b076-49ec-8ec2-88b73040b351")
                        });
                });

            modelBuilder.Entity("DAL.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5959ed9c-f081-45e6-ae2e-aa102c3e5a46"),
                            Name = "Mat"
                        },
                        new
                        {
                            Id = new Guid("b78fd823-20cc-49b2-90c5-6e5df0dadbb3"),
                            Name = "Transport"
                        },
                        new
                        {
                            Id = new Guid("2da1939c-8f8f-46f2-819a-3b405311be9d"),
                            Name = "Nöje"
                        },
                        new
                        {
                            Id = new Guid("6cbc9ea2-359d-4035-ad23-f597fb12b31a"),
                            Name = "Boende"
                        },
                        new
                        {
                            Id = new Guid("6539ea84-9f69-4c84-a66a-6131ef955749"),
                            Name = "Hushåll"
                        },
                        new
                        {
                            Id = new Guid("5d6b57f2-aa20-4956-9a01-fb06b26e4221"),
                            Name = "Sparande"
                        },
                        new
                        {
                            Id = new Guid("c6e05044-60e3-4759-9aa1-91e0e09c1dbf"),
                            Name = "Övrigt"
                        });
                });

            modelBuilder.Entity("DAL.Models.Debit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("money");

                    b.Property<Guid?>("BudgetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BudgetId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Debits");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e06441d9-b58c-4161-91cd-bc2a96a9bca9"),
                            Amount = 150m,
                            BudgetId = new Guid("d96f9337-0b84-4a79-9977-d27125420898"),
                            CategoryId = new Guid("b78fd823-20cc-49b2-90c5-6e5df0dadbb3"),
                            Comment = "Mjukisdjur",
                            Date = new DateTime(2022, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1")
                        },
                        new
                        {
                            Id = new Guid("9d4c1326-5f52-4cfb-81d0-29247854516c"),
                            Amount = 7000m,
                            BudgetId = new Guid("496ef686-6b83-4c24-9e0f-d6f51b29fad2"),
                            CategoryId = new Guid("6539ea84-9f69-4c84-a66a-6131ef955749"),
                            Comment = "Ny Soffa",
                            Date = new DateTime(2022, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1")
                        },
                        new
                        {
                            Id = new Guid("444c6cdd-c2ab-4d35-a4a4-018ce8e4ebf6"),
                            Amount = 500m,
                            BudgetId = new Guid("d96f9337-0b84-4a79-9977-d27125420898"),
                            CategoryId = new Guid("b78fd823-20cc-49b2-90c5-6e5df0dadbb3"),
                            Comment = "Lego",
                            Date = new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1")
                        },
                        new
                        {
                            Id = new Guid("d77e1ec4-8aee-4abe-902c-2537052e6e32"),
                            Amount = 850m,
                            BudgetId = new Guid("496ef686-6b83-4c24-9e0f-d6f51b29fad2"),
                            CategoryId = new Guid("6539ea84-9f69-4c84-a66a-6131ef955749"),
                            Comment = "Ny Köksbord",
                            Date = new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1")
                        },
                        new
                        {
                            Id = new Guid("a16e4528-c9c9-48e6-9e11-3141e2e97142"),
                            Amount = 1500m,
                            CategoryId = new Guid("5959ed9c-f081-45e6-ae2e-aa102c3e5a46"),
                            Comment = "Storhandla BBQ",
                            Date = new DateTime(2022, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1")
                        },
                        new
                        {
                            Id = new Guid("4124cc4a-63c6-4d44-bc47-73d680e739cd"),
                            Amount = 2500m,
                            BudgetId = new Guid("fe0219cc-eb57-417e-b07b-87aa2784a92b"),
                            CategoryId = new Guid("2da1939c-8f8f-46f2-819a-3b405311be9d"),
                            Comment = "Ny Moderkort",
                            Date = new DateTime(2022, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("720892b1-b076-49ec-8ec2-88b73040b351")
                        },
                        new
                        {
                            Id = new Guid("1fefd8b4-64b6-46d8-9396-1c2a51d15f85"),
                            Amount = 8500m,
                            BudgetId = new Guid("fe0219cc-eb57-417e-b07b-87aa2784a92b"),
                            CategoryId = new Guid("2da1939c-8f8f-46f2-819a-3b405311be9d"),
                            Comment = "Ny Grafikkort",
                            Date = new DateTime(2022, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("720892b1-b076-49ec-8ec2-88b73040b351")
                        },
                        new
                        {
                            Id = new Guid("379e752c-46e6-47ec-9a5d-346258ccc8f2"),
                            Amount = 180m,
                            CategoryId = new Guid("6cbc9ea2-359d-4035-ad23-f597fb12b31a"),
                            Comment = "Spotify",
                            Date = new DateTime(2022, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("720892b1-b076-49ec-8ec2-88b73040b351")
                        },
                        new
                        {
                            Id = new Guid("2f4543fe-9d93-40b5-a01c-8128e1e9a051"),
                            Amount = 400m,
                            CategoryId = new Guid("6cbc9ea2-359d-4035-ad23-f597fb12b31a"),
                            Comment = "Bredband",
                            Date = new DateTime(2022, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("720892b1-b076-49ec-8ec2-88b73040b351")
                        },
                        new
                        {
                            Id = new Guid("26842a1b-3585-4fdb-b1f2-7c363a667435"),
                            Amount = 750m,
                            BudgetId = new Guid("7264a099-8b0e-4953-a548-fa62dd2fad4a"),
                            CategoryId = new Guid("2da1939c-8f8f-46f2-819a-3b405311be9d"),
                            Comment = "Film o Pizza kväll",
                            Date = new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("720892b1-b076-49ec-8ec2-88b73040b351")
                        });
                });

            modelBuilder.Entity("DAL.Models.SavingPlan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Savingplans");
                });

            modelBuilder.Entity("DAL.Models.UserCategories", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserCategories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("583aca7b-aff4-4f2d-b76b-5c74112ff699"),
                            Name = "Leksaker",
                            UserId = new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1")
                        },
                        new
                        {
                            Id = new Guid("2d06e9df-8df0-44a3-84ca-ad8db8703188"),
                            Name = "Bilar",
                            UserId = new Guid("720892b1-b076-49ec-8ec2-88b73040b351")
                        },
                        new
                        {
                            Id = new Guid("e004e107-dfd6-4ffa-8b47-39a8d0b62df7"),
                            Name = "Kryssningar",
                            UserId = new Guid("720892b1-b076-49ec-8ec2-88b73040b351")
                        },
                        new
                        {
                            Id = new Guid("3c9100af-5ed9-48cc-8fdd-8b6839bfddb6"),
                            Name = "Flygresor",
                            UserId = new Guid("720892b1-b076-49ec-8ec2-88b73040b351")
                        },
                        new
                        {
                            Id = new Guid("0dddc255-e362-4b71-8177-14a9df9e5373"),
                            Name = "Husköp",
                            UserId = new Guid("720892b1-b076-49ec-8ec2-88b73040b351")
                        },
                        new
                        {
                            Id = new Guid("efbf7bb5-ac81-4bf2-a5cd-3e66c2171186"),
                            Name = "Papegojfoder",
                            UserId = new Guid("720892b1-b076-49ec-8ec2-88b73040b351")
                        },
                        new
                        {
                            Id = new Guid("1ce05fc8-29b2-4ce6-af6c-5eee53bfd3a5"),
                            Name = "Hundleksaker",
                            UserId = new Guid("720892b1-b076-49ec-8ec2-88b73040b351")
                        },
                        new
                        {
                            Id = new Guid("c229efe0-45cd-46bb-ab96-d9de8588ea0f"),
                            Name = "Hemsaker",
                            UserId = new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1")
                        });
                });

            modelBuilder.Entity("DAL.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1"),
                            Email = "adam_01@hotmail.com",
                            FirstName = "Adam",
                            LastName = "Adamsson",
                            Password = "123"
                        },
                        new
                        {
                            Id = new Guid("720892b1-b076-49ec-8ec2-88b73040b351"),
                            Email = "berit_02@msn.com",
                            FirstName = "Berit",
                            LastName = "Beritsdotter",
                            Password = "123"
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
                    b.HasOne("DAL.User", "User")
                        .WithMany("Categories")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Models.Debit", b =>
                {
                    b.HasOne("DAL.Budget", "Budget")
                        .WithMany("Debits")
                        .HasForeignKey("BudgetId");

                    b.HasOne("DAL.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("DAL.User", "User")
                        .WithMany("Debits")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Budget");

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Models.SavingPlan", b =>
                {
                    b.HasOne("DAL.User", "User")
                        .WithMany("SavingPlans")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Models.UserCategories", b =>
                {
                    b.HasOne("DAL.User", "User")
                        .WithMany("UserCategories")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Budget", b =>
                {
                    b.Navigation("Debits");
                });

            modelBuilder.Entity("DAL.User", b =>
                {
                    b.Navigation("Budgets");

                    b.Navigation("Categories");

                    b.Navigation("Debits");

                    b.Navigation("SavingPlans");

                    b.Navigation("UserCategories");
                });
#pragma warning restore 612, 618
        }
    }
}