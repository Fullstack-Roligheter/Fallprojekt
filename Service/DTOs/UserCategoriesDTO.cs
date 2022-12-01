namespace Service.DTOs;

public class UserCategoriesDTO
{
    public Guid? UserId { get; set; }
    public Guid CategoryId { get; set; }
    public string? CategoryName { get; set; }
}