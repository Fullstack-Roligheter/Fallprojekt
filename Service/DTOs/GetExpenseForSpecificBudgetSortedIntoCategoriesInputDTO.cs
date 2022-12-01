namespace Service.DTOs;

public class GetExpenseForSpecificBudgetSortedIntoCategoriesInputDTO
{
    public int UserId { get; set; }
    public int BudgetId { get; set; }
}