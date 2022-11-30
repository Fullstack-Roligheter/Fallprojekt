namespace Service.DTOs;

public class SuccessLoginDTO
{
    public Guid UserId { get; set; } 
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}