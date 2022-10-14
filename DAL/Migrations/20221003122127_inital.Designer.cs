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
    [Migration("20221003122127_inital")]
    partial class inital
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
                        },
                        new
                        {
                            Id = new Guid("583aca7b-aff4-4f2d-b76b-5c74112ff699"),
                            Name = "Leksaker",
                            UserId = new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1")
                        },
                        new
                        {
                            Id = new Guid("2d06e9df-8df0-44a3-84ca-ad8db8703188"),
                            Name = "Nöje",
                            UserId = new Guid("720892b1-b076-49ec-8ec2-88b73040b351")
                        },
                        new
                        {
                            Id = new Guid("e004e107-dfd6-4ffa-8b47-39a8d0b62df7"),
                            Name = "Räkningar",
                            UserId = new Guid("720892b1-b076-49ec-8ec2-88b73040b351")
                        },
                        new
                        {
                            Id = new Guid("3c9100af-5ed9-48cc-8fdd-8b6839bfddb6"),
                            Name = "Hemsaker",
                            UserId = new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1")
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
                            Id = new Guid("180009c3-9a02-47cc-8351-09c72c860be7"),
                            Amount = 150m,
                            BudgetId = new Guid("d96f9337-0b84-4a79-9977-d27125420898"),
                            CategoryId = new Guid("b78fd823-20cc-49b2-90c5-6e5df0dadbb3"),
                            Comment = "Mjukisdjur",
                            Date = new DateTime(2022, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1")
                        },
                        new
                        {
                            Id = new Guid("49352ad7-4aa5-4947-a1d5-13ec1f6e543e"),
                            Amount = 7000m,
                            BudgetId = new Guid("496ef686-6b83-4c24-9e0f-d6f51b29fad2"),
                            CategoryId = new Guid("6539ea84-9f69-4c84-a66a-6131ef955749"),
                            Comment = "Ny Soffa",
                            Date = new DateTime(2022, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1")
                        },
                        new
                        {
                            Id = new Guid("9e15cd08-777d-46e1-b891-6c75a1b646ea"),
                            Amount = 500m,
                            BudgetId = new Guid("d96f9337-0b84-4a79-9977-d27125420898"),
                            CategoryId = new Guid("b78fd823-20cc-49b2-90c5-6e5df0dadbb3"),
                            Comment = "Lego",
                            Date = new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1")
                        },
                        new
                        {
                            Id = new Guid("5a718118-d8da-4006-80ab-a700ce694d57"),
                            Amount = 850m,
                            BudgetId = new Guid("496ef686-6b83-4c24-9e0f-d6f51b29fad2"),
                            CategoryId = new Guid("6539ea84-9f69-4c84-a66a-6131ef955749"),
                            Comment = "Ny Köksbord",
                            Date = new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1")
                        },
                        new
                        {
                            Id = new Guid("d52f9aa3-7ae4-462c-8282-8986aaf24fc1"),
                            Amount = 1500m,
                            CategoryId = new Guid("5959ed9c-f081-45e6-ae2e-aa102c3e5a46"),
                            Comment = "Storhandla BBQ",
                            Date = new DateTime(2022, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1")
                        },
                        new
                        {
                            Id = new Guid("8c76010f-4e2b-4b49-908e-51e413c6e530"),
                            Amount = 2500m,
                            BudgetId = new Guid("fe0219cc-eb57-417e-b07b-87aa2784a92b"),
                            CategoryId = new Guid("2da1939c-8f8f-46f2-819a-3b405311be9d"),
                            Comment = "Ny Moderkort",
                            Date = new DateTime(2022, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("720892b1-b076-49ec-8ec2-88b73040b351")
                        },
                        new
                        {
                            Id = new Guid("f726a427-0d72-4a8f-bdf5-8f8feb23f007"),
                            Amount = 8500m,
                            BudgetId = new Guid("fe0219cc-eb57-417e-b07b-87aa2784a92b"),
                            CategoryId = new Guid("2da1939c-8f8f-46f2-819a-3b405311be9d"),
                            Comment = "Ny Grafikkort",
                            Date = new DateTime(2022, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("720892b1-b076-49ec-8ec2-88b73040b351")
                        },
                        new
                        {
                            Id = new Guid("a75369ac-5456-4ca9-a9e0-32eb7f116118"),
                            Amount = 180m,
                            CategoryId = new Guid("6cbc9ea2-359d-4035-ad23-f597fb12b31a"),
                            Comment = "Spotify",
                            Date = new DateTime(2022, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("720892b1-b076-49ec-8ec2-88b73040b351")
                        },
                        new
                        {
                            Id = new Guid("b712fcc0-0039-413b-b00f-8b3245aa84d6"),
                            Amount = 400m,
                            CategoryId = new Guid("6cbc9ea2-359d-4035-ad23-f597fb12b31a"),
                            Comment = "Bredband",
                            Date = new DateTime(2022, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("720892b1-b076-49ec-8ec2-88b73040b351")
                        },
                        new
                        {
                            Id = new Guid("15cd7b09-3f0e-4dd3-8fb4-72a7c00d7b3a"),
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
                });
#pragma warning restore 612, 618
        }
    }
}