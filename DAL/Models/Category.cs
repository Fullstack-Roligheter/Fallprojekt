using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Category
    {
        [Key] // <-- Kör med Data annotations tills vidare bara för att vara tydlig
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public decimal CategoryMaxAmount { get; set; }


        public int BudgetId { get; set; }
        public Budget Budget { get; set; } // En Budget kan ha många Categories ("MÅNGA" SIDAN HÄR)

        public ICollection<Expense>? Expenses { get; set; } //En Category kan ha många Expenses ("EN" SIDAN HÄR)

    }

}
