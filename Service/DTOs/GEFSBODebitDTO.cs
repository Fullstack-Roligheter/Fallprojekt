namespace Service.DTOs;

public class GEFSBODebitDTO
{
    public Guid ExpenseId { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string? Comment { get; set; }
    public string? CategoryName { get; set; }
    public Guid? CategoryId { get; set; }
}