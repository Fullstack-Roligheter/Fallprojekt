namespace Service.DTOs;

public class GetExpenseForSpecificBudgetOutputDTO
{
    public Guid BudgetId { get; set; }
    public string? BudgetName { get; set; }
    public List<GEFSBODebitDTO> Debits { get; set; }
}