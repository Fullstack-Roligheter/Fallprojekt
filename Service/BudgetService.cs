using DAL;
using DAL.Repositories.Interfaces;
using Service.DTOs;
using Service.Interfaces;

namespace Service;

public class BudgetService : IBudgetService
{
    private readonly IBudgetRepo _budgetRepo;
    private readonly IUserRepo _userRepo;

    public BudgetService(IBudgetRepo budgetRepo, IUserRepo userRepo)
    {
        _budgetRepo = budgetRepo;
        _userRepo = userRepo;
    }

    public IList<BudgetNameDTO>? GetBudgetsForUser(Guid userId)
    {
        var userBudgets = _budgetRepo.GetAll(userId);
        if (userBudgets == null) throw new NullReferenceException();
        var result = userBudgets
            .Select(budget => new BudgetNameDTO()
            {
                BudgetId = budget.Id,
                BudgetName = budget.Name
            }).ToList();

        return result;
    }

    public void CreateBudget(CreateBudgetDTO budget)
    {
        _budgetRepo.Create(new Budget()
        {
            Id = Guid.NewGuid(),
            Name = budget.Name,
            StartDate = budget.StartDate,
            EndDate = budget.EndDate,
            Amount = budget.Amount,
            Comment = budget.Comment,
            UserId = budget.UserId
        });
    }

    public void DeleteBudget(DeleteBudgetDTO input)
    {
        _budgetRepo.Delete(input.BudgetId);
    }

    public void EditBudget(EditBudgetDTO editBudget)
    {
        _budgetRepo.Update(new Budget()
        {
            Id = editBudget.BudgetId,
            Name = editBudget.Name,
            StartDate = editBudget.StartDate,
            EndDate = editBudget.EndDate,
            Amount = editBudget.Amount,
            Comment = editBudget.Comment
        });
    }

    public bool BudgetIdValidation(Guid budgetId)
    {
        var check = _budgetRepo.Get(budgetId);
        return check != null;
    }
}