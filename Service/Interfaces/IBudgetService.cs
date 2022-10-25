using Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IBudgetService
    {
        List<BudgetNameDTO> GetBudgetsForUser(UserIdDTO user);
        void CreateBudget(CreateBudgetDTO budget);
        void DeleteBudget(DeleteBudgetDTO input);
        void EditBudget(EditBudgetDTO editBudget);
        bool BudgetIdValidation(Guid budgetId);
    }
}
