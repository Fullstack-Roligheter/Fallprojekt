using DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<Category> Categories { get; set; }
        public ICollection<SavingPlan>? SavingPlans { get; set; } //En User kan ha många SavingPlans ("EN" SIDAN HÄR)
        public ICollection<Budget>? Budgets { get; set; } //En User kan ha många Budgets ("EN" SIDAN HÄR)
        public ICollection<Debit>? Debits { get; set; }//En User kan ha många Debits ("EN" SIDAN HÄR)

    }
}
