namespace Service.DTOs;

public class FilterByBudgetAndCategoryDTO
{
    public int ExpenseId { get; set; }
    public string? ExpenseRecipient { get; set; }
    public decimal ExpenseAmount { get; set; }
    public string ExpenseDate { get; set; }
    public string? ExpenseComment { get; set; }
}