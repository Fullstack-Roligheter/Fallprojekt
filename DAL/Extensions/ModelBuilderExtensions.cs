using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Extensions;

internal static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder builder)
    {
        var userGuidOne = new Guid("ce43e8a5-b655-435f-9dee-f0df2ee936c1"); //adam
        var userGuidTwo = new Guid("720892b1-b076-49ec-8ec2-88b73040b351"); //berit

        var budgetGuidOne = new Guid("496ef686-6b83-4c24-9e0f-d6f51b29fad2");
        var budgetGuidTwo = new Guid("d96f9337-0b84-4a79-9977-d27125420898");
        var budgetGuidThree = new Guid("fe0219cc-eb57-417e-b07b-87aa2784a92b");
        var budgetGuidFour = new Guid("7264a099-8b0e-4953-a548-fa62dd2fad4a");

        var categoryGuidOne = new Guid("5959ed9c-f081-45e6-ae2e-aa102c3e5a46");
        var categoryGuidTwo = new Guid("b78fd823-20cc-49b2-90c5-6e5df0dadbb3");
        var categoryGuidThree = new Guid("2da1939c-8f8f-46f2-819a-3b405311be9d");
        var categoryGuidFour = new Guid("6cbc9ea2-359d-4035-ad23-f597fb12b31a");
        var categoryGuidFive = new Guid("6539ea84-9f69-4c84-a66a-6131ef955749");
        var categoryGuidSix = new Guid("5d6b57f2-aa20-4956-9a01-fb06b26e4221");
        var categoryGuidSeven = new Guid("c6e05044-60e3-4759-9aa1-91e0e09c1dbf");
        
        var userCategoryOne = new Guid("583aca7b-aff4-4f2d-b76b-5c74112ff699");
        var userCategoryTwo = new Guid("2d06e9df-8df0-44a3-84ca-ad8db8703188");
        var userCategoryThree = new Guid("e004e107-dfd6-4ffa-8b47-39a8d0b62df7");
        var userCategoryFour = new Guid("3c9100af-5ed9-48cc-8fdd-8b6839bfddb6");
        var userCategoryFive = new Guid("0dddc255-e362-4b71-8177-14a9df9e5373");
        var userCategorySix = new Guid("efbf7bb5-ac81-4bf2-a5cd-3e66c2171186");
        var userCategorySeven = new Guid("1ce05fc8-29b2-4ce6-af6c-5eee53bfd3a5");
        var userCategoryEight = new Guid("c229efe0-45cd-46bb-ab96-d9de8588ea0f");
  

        builder.Entity<User>().HasData //User tabell
        (
            new User { Id = userGuidOne, FirstName = "Adam", LastName = "Adamsson", Email = "adam_01@hotmail.com", Password = "123" },
            new User { Id = userGuidTwo, FirstName = "Berit", LastName = "Beritsdotter", Email = "berit_02@msn.com", Password = "123" }
        );

        builder.Entity<Budget>().HasData //Budget tabell
        (
            new Budget { Id = budgetGuidOne, UserId = userGuidOne, Name = "Nya möbler", StartDate = DateTime.ParseExact("2022-04-01", "yyyy-MM-dd", null), EndDate = DateTime.ParseExact("2022-12-01", "yyyy-MM-dd", null), Amount = 6000 },
            new Budget { Id = budgetGuidTwo, UserId = userGuidOne, Name = "Julklappar", StartDate = DateTime.ParseExact("2022-09-01", "yyyy-MM-dd", null), EndDate = DateTime.ParseExact("2022-12-01", "yyyy-MM-dd", null), Amount = 3000 },
            new Budget { Id = budgetGuidThree, UserId = userGuidTwo, Name = "Ny Dator", StartDate = DateTime.ParseExact("2022-05-01", "yyyy-MM-dd", null), EndDate = DateTime.ParseExact("2023-04-30", "yyyy-MM-dd", null), Amount = 12000 },
            new Budget { Id = budgetGuidFour, UserId = userGuidTwo, Name = "Film o Pizza kväll", StartDate = DateTime.ParseExact("2022-10-14", "yyyy-MM-dd", null), EndDate = DateTime.ParseExact("2022-10-14", "yyyy-MM-dd", null), Amount = 1000 }

        );

        builder.Entity<Category>().HasData //Category tabell
        (
            new Category { Id = categoryGuidOne, Name = "Mat", },                               //Default Kategori
            new Category { Id = categoryGuidTwo, Name = "Transport", },                         //Default Kategori
            new Category { Id = categoryGuidThree, Name = "Nöje", },                            //Default Kategori
            new Category { Id = categoryGuidFour, Name = "Boende", },                           //Default Kategori
            new Category { Id = categoryGuidFive, Name = "Hushåll", },                          //Default Kategori
            new Category { Id = categoryGuidSix, Name = "Sparande", },                          //Default Kategori
            new Category { Id = categoryGuidSeven, Name = "Övrigt", }                           //Default Kategori

        );
       
        builder.Entity<UserCategories>().HasData //Category tabell
        (
            new UserCategories { Id = userCategoryOne, Name = "Leksaker", UserId = userGuidOne },    //bara adam
            new UserCategories { Id = userCategoryTwo, Name = "Bilar", UserId = userGuidTwo },        //bara berit
            new UserCategories { Id = userCategoryThree, Name = "Kryssningar", UserId = userGuidTwo }, //bara berit
            new UserCategories { Id = userCategoryFour, Name = "Flygresor", UserId = userGuidTwo }, //bara berit
            new UserCategories { Id = userCategoryFive, Name = "Husköp", UserId = userGuidTwo }, //bara berit
            new UserCategories { Id = userCategorySix, Name = "Papegojfoder", UserId = userGuidTwo }, //bara berit
            new UserCategories { Id = userCategorySeven, Name = "Hundleksaker", UserId = userGuidTwo }, //bara berit
            new UserCategories { Id = userCategoryEight, Name = "Hemsaker", UserId = userGuidOne }    //bara adam
        );

        builder.Entity<Debit>().HasData //Debit tabell
        (
            //adam
            new Debit { Id = Guid.NewGuid(), Comment = "Mjukisdjur",      Amount = 150, Date = DateTime.ParseExact("2022-09-15", "yyyy-MM-dd", null), UserId = userGuidOne, BudgetId = budgetGuidTwo, CategoryId = categoryGuidTwo },
            new Debit { Id = Guid.NewGuid(), Comment = "Ny Soffa",   Amount = 7000, Date = DateTime.ParseExact("2022-01-17", "yyyy-MM-dd", null), UserId = userGuidOne, BudgetId = budgetGuidOne, CategoryId = categoryGuidFive},
            new Debit { Id = Guid.NewGuid(), Comment = "Lego", Amount = 500, Date = DateTime.ParseExact("2022-03-02", "yyyy-MM-dd", null), UserId = userGuidOne, BudgetId = budgetGuidTwo, CategoryId = categoryGuidTwo},
            new Debit { Id = Guid.NewGuid(), Comment = "Ny Köksbord", Amount = 850, Date = DateTime.ParseExact("2022-03-04", "yyyy-MM-dd", null), UserId = userGuidOne, BudgetId = budgetGuidOne, CategoryId = categoryGuidFive},
            new Debit { Id = Guid.NewGuid(), Comment = "Storhandla BBQ", Amount = 1500, Date = DateTime.ParseExact("2022-03-05", "yyyy-MM-dd", null), UserId = userGuidOne, BudgetId = null, CategoryId  = categoryGuidOne},

            //berit
            new Debit { Id = Guid.NewGuid(), Comment = "Ny Moderkort", Amount = 2500, Date = DateTime.ParseExact("2022-03-06", "yyyy-MM-dd", null), UserId = userGuidTwo, BudgetId = budgetGuidThree, CategoryId = categoryGuidThree },
            new Debit { Id = Guid.NewGuid(), Comment = "Ny Grafikkort", Amount = 8500, Date = DateTime.ParseExact("2022-03-07", "yyyy-MM-dd", null), UserId = userGuidTwo, BudgetId = budgetGuidThree, CategoryId = categoryGuidThree },
            new Debit { Id = Guid.NewGuid(), Comment = "Spotify", Amount = 180, Date = DateTime.ParseExact("2022-03-08", "yyyy-MM-dd", null), UserId = userGuidTwo, BudgetId = null, CategoryId = categoryGuidFour },
            new Debit { Id = Guid.NewGuid(), Comment = "Bredband", Amount = 400, Date = DateTime.ParseExact("2022-03-09", "yyyy-MM-dd", null), UserId = userGuidTwo, BudgetId = null, CategoryId = categoryGuidFour },
            new Debit { Id = Guid.NewGuid(), Comment = "Film o Pizza kväll", Amount = 750, Date = DateTime.ParseExact("2022-03-10", "yyyy-MM-dd", null), UserId = userGuidTwo, BudgetId = budgetGuidFour, CategoryId = categoryGuidThree }
        );
    }
}