using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs
{
    public class GetDebitsForBudgetDTO
    {
        public Guid UserId { get; set; }
        public Guid BudgetId { get; set; }
    }
}
