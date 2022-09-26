using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs
{
    public class UserBudgetDTO
    {
        public int  Id { get; set; }
        public string BudgetName { get; set; }
        public DateTime BudgetStartDate { get; set; }
        public DateTime BudgetEndDate { get; set; }
        public decimal? BudgetMaxAmountMoney { get; set; }
    }
}
