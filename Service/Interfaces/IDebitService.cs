using Service.DTOs;

namespace Service.Interfaces;

public interface IDebitService
{
    void CreateDebit(CreateDebitDTO debit);
    void DeleteDebit(Guid debitId);
    void EditDebit(EditDebitDTO editDebit);
    IList<DebitDTO> GetAll();
    IList<DebitDTO> GetAllWithUserId(Guid userId);
    GetExpenseForSpecificBudgetOutputDTO GetDebitsForBudget(GetDebitsDTO input);
    DebitsInCategoryDTO GetDebitsForCategory(GetDebitsDTO input);
}