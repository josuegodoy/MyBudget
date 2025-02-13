using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyBudget.Models;
using System.Collections.Generic;

namespace MyBudget.Data
{
    public class MyBudgetContext : IdentityDbContext<IdentityUser>
    {
        public MyBudgetContext(DbContextOptions<MyBudgetContext> options)
            : base(options)
        {
        }

        public DbSet<MyBudget.Models.User> User { get; set; } = default!;
        public DbSet<MyBudget.Models.Account> Account { get; set; } = default!;
        public DbSet<MyBudget.Models.AccountType> AccountType { get; set; } = default!;
        public DbSet<MyBudget.Models.Currency> Currency { get; set; } = default!;
        public DbSet<MyBudget.Models.Category> Category { get; set; } = default!;
        public DbSet<MyBudget.Models.Record> Record { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Account>()
                .Property(u => u.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity<AccountType>()
                .Property(u => u.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity<Category>()
               .Property(u => u.CreatedAt)
               .HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity<Currency>()
                .Property(u => u.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity<Record>()
               .Property(u => u.CreatedAt)
               .HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity<User>()
                .Property(u => u.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Record>()
                .HasOne(r => r.Category)
                .WithMany(c => c.Records)
                .HasForeignKey(r => r.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Record>()
                .HasOne(r => r.FromAccount)
                .WithMany(c => c.ExpenseRecords)
                .HasForeignKey(r => r.FromAccountId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Record>()
               .HasOne(r => r.ToAccount)
               .WithMany(c => c.IncomeRecords)
               .HasForeignKey(r => r.ToAccountId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Account>()
                .HasOne(r => r.User)
                .WithMany(c => c.Accounts)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Account>()
               .HasOne(r => r.Currency)
               .WithMany(c => c.Accounts)
               .HasForeignKey(r => r.CurrencyId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Account>()
               .HasOne(r => r.AccountType)
               .WithMany(c => c.Accounts)
               .HasForeignKey(r => r.AccountTypeId)
               .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
