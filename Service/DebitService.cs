using Service.DTOs;
using DAL.Models;
using DAL.Repositories.Interfaces;
using Service.Interfaces;

namespace Service;

public class DebitService : IDebitService
{
    private readonly IDebitRepo _debitRepo;
    private readonly ICategoryRepo _categoryRepo;
    private readonly IBudgetRepo _budgetRepo;

    public DebitService(
        IDebitRepo debitRepo, 
        ICategoryRepo categoryRepo,
        IBudgetRepo budgetRepo
        )
    {
        _debitRepo = debitRepo;
        _categoryRepo = categoryRepo;
        _budgetRepo = budgetRepo;
    }

    public IList<DebitDTO> GetAll()
    {
        return (from d in _debitRepo.GetAll()
                select new DebitDTO()
                {
                    Id = d.Id,
                    Date = d.Date,
                    Amount = d.Amount,
                    Comment = d.Comment,
                    Category = d.Category == null ? string.Empty : d.Category.Name,
                    Budget = d.Budget == null ? string.Empty : d.Budget.Name
                }).ToList();
    }

    public IList<DebitDTO> GetAllWithUserId(Guid userId)
    {
        var debits = _debitRepo.GetAllWithUserId(userId);

        if (debits == null)
        {
            throw new NullReferenceException("No Debits Found");
        }

        var result = debits
            .Select(d => new DebitDTO()
            {
                Id = d.Id,
                Date = d.Date,
                Amount = d.Amount,
                Comment = d.Comment,
                Category = d.Category == null ? string.Empty : d.Category.Name,
                Budget = d.Budget == null ? string.Empty : d.Budget.Name
            }).OrderByDescending(x => x.Date).ToList();

        return result;
    }

    public void CreateDebit(CreateDebitDTO debit)
    {
        _debitRepo.Create(new Debit
        {
            Id = Guid.NewGuid(),
            UserId = debit.UserId,
            Date = debit.Date,
            Amount = debit.Amount,
            Comment = debit.Comment,
            CategoryId = debit.CategoryId,
            BudgetId = debit.BudgetId,
        });
    }

    public GetExpenseForSpecificBudgetOutputDTO GetDebitsForBudget(GetDebitsDTO input)
    {
        var debitsList = _debitRepo.GetAllWithBudgetId(input.CollectionId);
        if (debitsList == null) throw new NullReferenceException("No Debits Found for Specified Budget");

        var result = new GetExpenseForSpecificBudgetOutputDTO();
        foreach (var debit in debitsList)
        {
            result.BudgetId = debit.Budget.Id;
            result.BudgetName = debit.Budget.Name;
            result.Debits.Add(new GEFSBODebitDTO()
            {
                Amount = debit.Amount,
                CategoryId = debit.CategoryId,
                CategoryName = debit.Category?.Name,
                Comment = debit.Comment,
                Date = debit.Date,
                ExpenseId = debit.Id
            });
        }
        return result;
    }

    public DebitsInCategoryDTO GetDebitsForCategory(GetDebitsDTO input)
    {
        var debitsList = _debitRepo.GetAllWithCategoryId(input.CollectionId);
        var category = _categoryRepo.Get(input.CollectionId);

        if (debitsList == null || category == null)
        {
            throw new NullReferenceException("No Debits Found for Specified Category");
        }

        var result = new DebitsInCategoryDTO
        {
            CategoryId = category.Id,
            CategoryName = category.Name
        };

        foreach (var debit in debitsList)
        {
            result.Debits.Add(new DebitItemInCategoryListDTO()
            {
                DebitId = debit.Id,
                Date = debit.Date,
                Amount = debit.Amount,
                Comment = debit.Comment,
            });
        }
        return result;
    }

    public void DeleteDebit(Guid debitId)
    {
        var target = _debitRepo.Get(debitId);
        if (target == null)
        {
            throw new NullReferenceException($"No Debit Found with Id: {debitId}");
        }

        _debitRepo.DeleteWithModel(target);
    }

    public void EditDebit(EditDebitDTO editDebit)
    {
        var affectedDebit = _debitRepo.Get(editDebit.DebitId);

        if (affectedDebit == null)
        {
            throw new NullReferenceException($"No Debit Found with Id: {editDebit.DebitId}");
        }

        affectedDebit.Id = editDebit.DebitId;
        affectedDebit.UserId = editDebit.UserId;
        affectedDebit.Date = editDebit.Date;
        affectedDebit.Amount = editDebit.Amount;
        affectedDebit.Comment = editDebit.Comment;
        affectedDebit.CategoryId = editDebit.CategoryId;
        affectedDebit.BudgetId = editDebit.BudgetId;

        _debitRepo.UpdateWithModel(affectedDebit);
    }
}