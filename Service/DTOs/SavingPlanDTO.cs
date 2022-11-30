namespace Service.DTOs;

public class SavingPlanDTO
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public int Amount { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
}