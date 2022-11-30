namespace Service.DTOs;

public class GetDebitsDTO
{
    public Guid UserId { get; set; }
    public Guid CollectionId { get; set; }
}