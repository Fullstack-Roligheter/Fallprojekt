using System.ComponentModel.DataAnnotations;

namespace DAL.Models;

public class SavingPlan
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Amount { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; }

}