namespace Service.DTOs;

public class CreateDebitDTO
{
    public DateTime Date { get; set; }
    public int Amount { get; set; }
    public string? Comment { get; set; }

    public Guid UserId { get; set; }
    public Guid? CategoryId { get; set; }
    public Guid? BudgetId { get; set; }
}