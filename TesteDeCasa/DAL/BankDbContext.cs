
using Microsoft.EntityFrameworkCore;
using TesteDeCasa.Models;

namespace TesteDeCasa.DAL
{
    public class BankingDbContext : DbContext
    {
        public BankingDbContext(DbContextOptions<BankingDbContext> options) : base(options)
        {
            
        }

        //DbSet
        public DbSet<Account> Accounts {get; init;}
        public DbSet<Transaction> transactions {get; init; }
    }
}