using Service.DTOs;

namespace Service.Interfaces;

public interface IBudgetService
{
    IList<BudgetNameDTO>? GetBudgetsForUser(Guid userId);
    void CreateBudget(CreateBudgetDTO budget);
    void DeleteBudget(DeleteBudgetDTO input);
    void EditBudget(EditBudgetDTO editBudget);
    bool BudgetIdValidation(Guid budgetId);
}