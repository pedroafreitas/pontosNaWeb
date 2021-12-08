namespace NotasSigaa.DAL
{
    public class NotasSigaaDbContext : DbContext
    {
        public BankingDbContext(DbCotextOptions<NotasSigaaDbContext> options) : base(options)
        {

        }

        public DbSet<Aluno> Alunos {get; set; }
        public DbSet<Historico> Historicos {get; set; }
        public DbSet<Turma> Turmas {get; set; }
    }
}