using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Expense
    {
        [Key] // <-- Kör med Data annotations tills vidare bara för att vara tydlig
        public int ExpenseId { get; set; }
        public string ExpenseRecipient { get; set; }
        public decimal ExpenseAmount { get; set; }
        public DateTime ExpenseDate { get; set; }





        public int CategoryId { get; set; }
        public Category Category { get; set; } // En Category kan ha många Expense ("MÅNGA" SIDAN HÄR)

    }

}
