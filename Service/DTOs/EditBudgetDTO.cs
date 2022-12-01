namespace Service.DTOs;

public class EditBudgetDTO
{
    public Guid BudgetId { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal? Amount { get; set; }
    public string? Comment { get; set; }

    public Guid UserId { get; set; }
}