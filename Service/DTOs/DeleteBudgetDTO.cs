using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs
{
    public class DeleteBudgetDTO
    {
        public Guid BudgetId { get; set; }
        public Guid UserId { get; set; }
    }
}