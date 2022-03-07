using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs
{
    public class GetExpenseForSpecificBudgetSortedIntoCategoriesOutputDTO
    {
        public string BudgetName { get; set; }
        public ICollection<GEFSBOCategoryDTO> Categories { get; set; }
    }
}
