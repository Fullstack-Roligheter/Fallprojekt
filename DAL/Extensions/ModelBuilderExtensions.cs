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
                    new User { UserId = 1, Name = "Adam Adamsson", Age = 20, Email = "adam_01@hotmail.com", Password = "password123" },
                    new User { UserId = 2, Name = "Berit Beritsson", Age = 30, Email = "berit_02@msn.com", Password = "password123" }
                );

            builder.Entity<Budget>().HasData //Budget tabell
                (
                    new Budget { BudgetId = 1, StartDate = DateTime.ParseExact("2022-01-15", "yyyy-MM-dd", null), EndDate = DateTime.ParseExact("2022-01-15", "yyyy-MM-dd", null), MaxAmountMoney = 5000 }
                );
        }
    }
}
