using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Budget
    {
        [Key]
        public int BudgetId { get; set; }
        public string BudgetName { get; set; }
        public DateTime BudgetStartDate { get; set; }
        public DateTime BudgetEndDate { get; set; }
        public decimal? BudgetMaxAmountMoney { get; set; }


        public int UserId { get; set; }
        public User User { get; set; } // Har för mig att (många) sidan ska ha ref <-- Borde inte det vara USER Tabellen som implementerar PlanId som Foreign Key?
                                       // En User kan ha många Budgets ("MÅNGA" SIDAN HÄR)
        public ICollection<Category>? Categories { get; set; } //En Budget kan ha många Categories ("EN" SIDAN HÄR)
    }

}
