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
    [Migration("20221207190110_testing")]
    partial class testing
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

            modelBuilder.Entity("DAL.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit");

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
                            IsDefault = true,
                            Name = "Mat"
                        },
                        new
                        {
                            Id = new Guid("b78fd823-20cc-49b2-90c5-6e5df0dadbb3"),
                            IsDefault = true,
                            Name = "Transport"
                        },
                        new
                        {
                            Id = new Guid("2da1939c-8f8f-46f2-819a-3b405311be9d"),
                            IsDefault = true,
                            Name = "Nöje"
                        },
                        new
                        {
                            Id = new Guid("6cbc9ea2-359d-4035-ad23-f597fb12b31a"),
                            IsDefault = true,
                            Name = "Boende"
                        },
                        new
                        {
                            Id = new Guid("6539ea84-9f69-4c84-a66a-6131ef955749"),
                            IsDefault = true,
                            Name = "Hushåll"
                        },
                        new
                        {
                            Id = new Guid("5d6b57f2-aa20-4956-9a01-fb06b26e4221"),
                            IsDefault = true,
                            Name = "Sparande"
                        },
                        new
                        {
                            Id = new Guid("c6e05044-60e3-4759-9aa1-91e0e09c1dbf"),
                            IsDefault = true,
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
                            Id = new Guid("ec20c991-9caf-4be6-ba41-77f00c1ba025"),
                            Amount = 150m,
                            BudgetId = new Guid("d96f9337-0b84-4a79-9977-d27125420898"),
                            Comment = "Mjukisdjur",
                            Date = new DateTime(2022, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1")
                        },
                        new
                        {
                            Id = new Guid("d4ab2bc1-812e-4af1-98b8-28785f308442"),
                            Amount = 7000m,
                            BudgetId = new Guid("496ef686-6b83-4c24-9e0f-d6f51b29fad2"),
                            Comment = "Ny Soffa",
                            Date = new DateTime(2022, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1")
                        },
                        new
                        {
                            Id = new Guid("e9de5e9f-9843-4e7f-a798-86af15c5e349"),
                            Amount = 500m,
                            BudgetId = new Guid("d96f9337-0b84-4a79-9977-d27125420898"),
                            Comment = "Lego",
                            Date = new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1")
                        },
                        new
                        {
                            Id = new Guid("5f73e748-5401-4058-bc6d-e489b963a5c4"),
                            Amount = 850m,
                            BudgetId = new Guid("496ef686-6b83-4c24-9e0f-d6f51b29fad2"),
                            Comment = "Ny Köksbord",
                            Date = new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1")
                        },
                        new
                        {
                            Id = new Guid("7a54d9a4-a0d2-4d15-9b9a-4437809af6a2"),
                            Amount = 1500m,
                            Comment = "Storhandla BBQ",
                            Date = new DateTime(2022, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1")
                        },
                        new
                        {
                            Id = new Guid("ad58ca61-dea4-4535-8d60-6bd434a97a96"),
                            Amount = 2500m,
                            BudgetId = new Guid("fe0219cc-eb57-417e-b07b-87aa2784a92b"),
                            Comment = "Ny Moderkort",
                            Date = new DateTime(2022, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("720892b1-b076-49ec-8ec2-88b73040b351")
                        },
                        new
                        {
                            Id = new Guid("d75f1dca-e8f2-476d-8c27-78c439393bc5"),
                            Amount = 8500m,
                            BudgetId = new Guid("fe0219cc-eb57-417e-b07b-87aa2784a92b"),
                            Comment = "Ny Grafikkort",
                            Date = new DateTime(2022, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("720892b1-b076-49ec-8ec2-88b73040b351")
                        },
                        new
                        {
                            Id = new Guid("6e98adac-870a-4093-abea-a0ac5bb97738"),
                            Amount = 180m,
                            Comment = "Spotify",
                            Date = new DateTime(2022, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("720892b1-b076-49ec-8ec2-88b73040b351")
                        },
                        new
                        {
                            Id = new Guid("dd958a6e-98f1-4d1b-8096-7a4d99046f20"),
                            Amount = 400m,
                            Comment = "Bredband",
                            Date = new DateTime(2022, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("720892b1-b076-49ec-8ec2-88b73040b351")
                        },
                        new
                        {
                            Id = new Guid("1d1923f8-3cdf-4f8b-88f8-379110974182"),
                            Amount = 750m,
                            BudgetId = new Guid("7264a099-8b0e-4953-a548-fa62dd2fad4a"),
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

                    b.ToTable("SavingPlans");
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

            modelBuilder.Entity("DAL.Models.Category", b =>
                {
                    b.HasOne("DAL.User", "User")
                        .WithMany("Categories")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Models.Debit", b =>
                {
                    b.HasOne("DAL.Budget", "Budget")
                        .WithMany("Debits")
                        .HasForeignKey("BudgetId");

                    b.HasOne("DAL.Models.Category", "Category")
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