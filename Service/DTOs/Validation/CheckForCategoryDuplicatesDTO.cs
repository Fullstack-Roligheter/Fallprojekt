namespace Service.DTOs;

public class CheckForCategoryDuplicatesDTO
{
    public Guid Id { get; set; }
    public Guid? UserId { get; set; }
    public string CategoryName { get; set; }
}