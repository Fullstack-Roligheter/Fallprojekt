namespace Service.DTOs;

public class DeleteBudgetDTO
{
    public Guid BudgetId { get; set; }
    public Guid UserId { get; set; }
}