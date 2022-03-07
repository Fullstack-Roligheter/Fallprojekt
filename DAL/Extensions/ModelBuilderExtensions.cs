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
                    new Budget { BudgetId = 1, UserId = 1, BudgetName = "Default", BudgetStartDate = DateTime.ParseExact("2022-01-01", "yyyy-MM-dd", null), BudgetEndDate = DateTime.ParseExact("2022-01-31", "yyyy-MM-dd", null), BudgetMaxAmountMoney = 0 },
                    new Budget { BudgetId = 2, UserId = 1, BudgetName = "Vår 2022", BudgetStartDate = DateTime.ParseExact("2022-03-01", "yyyy-MM-dd", null), BudgetEndDate = DateTime.ParseExact("2022-05-31", "yyyy-MM-dd", null), BudgetMaxAmountMoney = 0 },
                    new Budget { BudgetId = 3, UserId = 1, BudgetName = "Sommar 2022", BudgetStartDate = DateTime.ParseExact("2022-06-01", "yyyy-MM-dd", null), BudgetEndDate = DateTime.ParseExact("2022-08-31", "yyyy-MM-dd", null), BudgetMaxAmountMoney = 0 },
                    new Budget { BudgetId = 4, UserId = 2, BudgetName = "Default", BudgetStartDate = DateTime.ParseExact("2022-01-01", "yyyy-MM-dd", null), BudgetEndDate = DateTime.ParseExact("2022-01-31", "yyyy-MM-dd", null), BudgetMaxAmountMoney = 0 }

                );

            builder.Entity<Category>().HasData //Category tabell
                (
                    new Category { CategoryId = 1, CategoryName = "Default", BudgetId = 1, CategoryMaxAmount = 1000 },
                    new Category { CategoryId = 2, CategoryName = "Hem & Hushåll", BudgetId = 1, CategoryMaxAmount = 1500 },
                    new Category { CategoryId = 3, CategoryName = "Home Stuff Vår 2022", BudgetId = 2, CategoryMaxAmount = 1500 },
                    new Category { CategoryId = 4, CategoryName = "Other Stuff Vår 2022", BudgetId = 2, CategoryMaxAmount = 1500 },
                    new Category { CategoryId = 5, CategoryName = "Home Stuff Sommar 2022", BudgetId = 3, CategoryMaxAmount = 1500 },
                    new Category { CategoryId = 6, CategoryName = "Other Stuff Sommar 2022", BudgetId = 3, CategoryMaxAmount = 1500 },
                    new Category { CategoryId = 7, CategoryName = "Default", BudgetId = 4, CategoryMaxAmount = 1000 }

                );

            builder.Entity<Expense>().HasData //Expense tabell
                (
                    new Expense { ExpenseId = 1, ExpenseRecipient = "ICA",      ExpenseAmount = 500, ExpenseDate = DateTime.ParseExact("2022-01-15", "yyyy-MM-dd", null), CategoryId = 1 },
                    new Expense { ExpenseId = 2, ExpenseRecipient = "Hemköp",   ExpenseAmount = 250, ExpenseDate = DateTime.ParseExact("2022-01-17", "yyyy-MM-dd", null), CategoryId = 1 },
                    new Expense { ExpenseId = 3, ExpenseRecipient = "Vår HOME ICA 2022", ExpenseAmount = 250, ExpenseDate = DateTime.ParseExact("2022-03-02", "yyyy-MM-dd", null), CategoryId = 3 },
                    new Expense { ExpenseId = 4, ExpenseRecipient = "Vår HOME IKEA 2022", ExpenseAmount = 250, ExpenseDate = DateTime.ParseExact("2022-03-04", "yyyy-MM-dd", null), CategoryId = 3 },
                    new Expense { ExpenseId = 5, ExpenseRecipient = "Vår OTHER Hemköp 2022", ExpenseAmount = 250, ExpenseDate = DateTime.ParseExact("2022-03-05", "yyyy-MM-dd", null), CategoryId = 4 },
                    new Expense { ExpenseId = 6, ExpenseRecipient = "Vår OTHER ICA 2022", ExpenseAmount = 250, ExpenseDate = DateTime.ParseExact("2022-03-06", "yyyy-MM-dd", null), CategoryId = 4 },
                    new Expense { ExpenseId = 7, ExpenseRecipient = "Sommar HOME ICA 2022", ExpenseAmount = 250, ExpenseDate = DateTime.ParseExact("2022-03-07", "yyyy-MM-dd", null), CategoryId = 5 },
                    new Expense { ExpenseId = 8, ExpenseRecipient = "Sommar HOME IKEA 2022", ExpenseAmount = 250, ExpenseDate = DateTime.ParseExact("2022-03-08", "yyyy-MM-dd", null), CategoryId = 5 },
                    new Expense { ExpenseId = 9, ExpenseRecipient = "Sommar OTHER Hemköp 2022", ExpenseAmount = 250, ExpenseDate = DateTime.ParseExact("2022-03-09", "yyyy-MM-dd", null), CategoryId = 6 },
                    new Expense { ExpenseId = 10, ExpenseRecipient = "Sommar OTHER ICA 2022", ExpenseAmount = 250, ExpenseDate = DateTime.ParseExact("2022-03-10", "yyyy-MM-dd", null), CategoryId = 6 }
                );
        }
    }
}