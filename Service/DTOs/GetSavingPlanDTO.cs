namespace Service.DTOs;

public class GetSavingPlanDTO
{
    public Guid SavingId { get; set; }
    public string Name { get; set; }
    public int Amount { get; set; }
    public string PlanStartDate { get; set; }
    public string PlanEndDate { get; set; }
       
       
}