using DAL.Models;

namespace DAL.Repositories.Interfaces;

public interface IDebitRepo
{
    IList<Debit>? GetAll();
    IList<Debit>? GetAllWithUserId(Guid userId);
    IList<Debit>? GetAllWithCategoryId(Guid catId);
    IList<Debit>? GetAllWithBudgetId(Guid budId);
    Debit? Get(Guid modelId);
    void Create(Debit model);
    void DeleteWithModel(Debit model);
    void UpdateWithModel(Debit model);
    void UpdateMultiple(IList<Debit> debits);
    void DeleteMultiple(IList<Debit> debits);
}