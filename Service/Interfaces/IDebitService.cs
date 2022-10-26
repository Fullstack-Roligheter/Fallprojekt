using Service.DTOs;

namespace Service.Interfaces
{
    public interface IDebitService
    {
        void CreateDebit(CreateDebitDTO debit);
        void DeleteDebit(Guid debitId);
        void EditDebit(EditDebitDTO editDebit);
        List<DebitDTO> GetAllDebits();
        List<DebitDTO> GetDebitListForUser(UserIdDTO userId);
        GetExpenseForSpecificBudgetOutputDTO GetDebitsForBudget(GetDebitsDTO input);
        DebitsInCategoryDTO GetDebitsForCategory(GetDebitsDTO input);
    }
}