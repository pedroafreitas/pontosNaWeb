
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
        public DbSet<Account> Accounts {get; set;}
        public DbSet<Transaction> Transactions {get; set; }
    }
}