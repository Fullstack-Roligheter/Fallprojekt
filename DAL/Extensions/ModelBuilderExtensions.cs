using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Extensions
{
    internal static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<User>().HasData //User tabell
                (
                    new User { UserId = 1, UserName = "adam", UserAge = 20, UserEmail = "adam_01@hotmail.com", UserPassword = "123" },
                    new User { UserId = 2, UserName = "berit", UserAge = 30, UserEmail = "berit_02@msn.com", UserPassword = "123" }
                );

            builder.Entity<Budget>().HasData //Budget tabell
                (
                    new Budget { BudgetId = 1, UserId = 1, BudgetName = "Default", BudgetStartDate = DateTime.ParseExact("2022-01-01", "yyyy-MM-dd", null), BudgetEndDate = DateTime.ParseExact("2022-01-31", "yyyy-MM-dd", null), BudgetMaxAmountMoney = 0 }
                );

            builder.Entity<Category>().HasData //Category tabell
                (
                    new Category { CategoryId = 1, CategoryName = "Default", BudgetId = 1, CategoryMaxAmount = 1000 },
                    new Category { CategoryId = 2, CategoryName = "Hem & Hushåll", BudgetId = 1, CategoryMaxAmount = 1500 }
                );

            builder.Entity<Expense>().HasData //Expense tabell
                (
                    new Expense { ExpenseId = 1, ExpenseRecipient = "ICA",      ExpenseAmount = 500, ExpenseDate = DateTime.ParseExact("2022-01-15", "yyyy-MM-dd", null), CategoryId = 1 },
                    new Expense { ExpenseId = 2, ExpenseRecipient = "Hemköp",   ExpenseAmount = 250, ExpenseDate = DateTime.ParseExact("2022-01-17", "yyyy-MM-dd", null), CategoryId = 1 }
                );
        }
    }
}
