using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs
{
    public class GetExpenseForSpecificBudgetOutputDTO
    {
        public string BudgetName { get; set; }
        public ICollection<GEFSBOExpenseDTO> Expenses { get; set; }
    }
}
