namespace Service.DTOs;

public class DebitItemInCategoryListDTO
{
    public Guid DebitId { get; set; }
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public string? Comment { get; set; }
}