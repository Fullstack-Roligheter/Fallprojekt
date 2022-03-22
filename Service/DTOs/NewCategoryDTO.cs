using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs
{
    public class NewCategoryDTO
    {
        public int UserId { get; set; }
        public int BudgetId { get; set; }
        public string CategoryName { get; set; }
        public decimal CategoryMaxAmount { get; set; } = 0;
    }
}
