namespace MyBudget.Models;

public class Currency
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Code { get; set; }
    public string? Symbol { get; set; }
    public string? PluralName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public ICollection<Account> Accounts { get; set; }

}
