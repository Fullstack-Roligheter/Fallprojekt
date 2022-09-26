namespace Service.DTOs;

public class DebitDTO
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public string? Comment { get; set; }
    public string? Category { get; set; }
    public string? Budget { get; set; }
    public string? UserFirstName { get; set; }
}