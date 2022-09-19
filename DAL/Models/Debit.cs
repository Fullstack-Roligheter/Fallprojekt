using DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class Debit
    {
        [Key] // <-- Kör med Data annotations tills vidare bara för att vara tydlig
        public new Guid Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string? Comment { get; set; }


        public Guid? CategoryId { get; set; }
        public Category? Category { get; set; } // En Category kan ha många Debits ("MÅNGA" SIDAN HÄR)

        public Guid UserId { get; set; }
        public User User { get; set; } // En User kan ha många Debits ("MÅNGA" SIDAN HÄR)

        public Guid? BudgetId { get; set; }
        public Budget? Budget { get; set; } // En Budget kan ha många Debits ("MÅNGA" SIDAN HÄR)
    }

}
