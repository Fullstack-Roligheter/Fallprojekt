using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs
{
    public class GetExpenseForSpecificBudgetOutputDTO
    {
        public Guid BudgetId { get; set; }
        public string? BudgetName { get; set; }
        public List<GEFSBODebitDTO> Debits { get; set; }
    }
}
