using DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class Budget
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal? Amount { get; set; }
        public string? Comment { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
        
        public ICollection<Debit>? Debits { get; set; } //En Budget kan ha många Categories ("EN" SIDAN HÄR)
    }

}
