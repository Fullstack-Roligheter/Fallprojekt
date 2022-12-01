namespace Service.DTOs;

public class GetExpenseForSpecificBudgetSortedIntoCategoriesOutputDTO
{
    public string BudgetName { get; set; }
    public ICollection<DebitsInCategoryDTO> Categories { get; set; }
}