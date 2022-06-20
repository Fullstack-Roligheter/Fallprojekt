using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Income
    {
        public int Id { get; set; }
        public string? IncomeName{ get; set; }
        public int Amount { get; set; }
        public DateTime CreateDate { get; set; }
        public int IncomeCategoryId { get; set; }
        public DefaultIncomeCategory? IncomeCategory { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
