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
        [Key] // <-- Kör med Data annotations tills vidare bara för att vara tydlig
        public int BudgetId { get; set; }

        //public string Name { get; set; }

        [DataType(DataType.Date)] // <-- För att ta bort DATETIME där timestamp:en inkluderas kan man använda denna för att få enbart DD-MM-YYYY
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public decimal MaxAmountMoney { get; set; }

        //public int UserId { get; set; } <-- Borde inte det vara USER Tabellen som implementerar PlanId som Foreign Key?
    }

}
