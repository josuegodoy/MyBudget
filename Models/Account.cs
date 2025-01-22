using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBudget.Models;

public class Account
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal InitialBalance { get; set; } = 0;
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal CurrentBalance { get; set; } = 0;
    public string? Color { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public int UserId { get; set; }
    public int AccountTypeId { get; set; }
    public int CurrencyId { get; set; }
    public User User { get; set; }
    public AccountType AccountType { get; set; }
    public Currency Currency { get; set; }

    public virtual ICollection<Record> IncomeRecords { get; set; }
    public virtual ICollection<Record> ExpenseRecords { get; set; }
}
