namespace Service.DTOs;

public class DebitsInCategoryDTO
{
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; }
    public List<DebitItemInCategoryListDTO> Debits { get; set; }
}