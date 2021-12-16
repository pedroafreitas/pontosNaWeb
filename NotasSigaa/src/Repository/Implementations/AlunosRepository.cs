using System.Collections.Generic;
using NotasSigaa.Models;
using NotasSigaa.Repository.Interfaces;

namespace NotasSigaa.Repository
{
    public class AlunosRepository : IAlunosRepository
    {
        private readonly NotasSigaaDbContext _dbContext;

        public AlunosRepository(NotasSigaaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Aluno Create(Aluno aluno)
        {

        }

        public Aluno Delete(int matricula)
        {

        }

        public IEnumerable<Aluno> GetAllAlunos()
        {
            return _dbContext.Alunos.ToList();
        }

        public Aluno GetByMatricula(int matricula)
        {

        }

        public Aluno GetByName(string primeiroNome)
        {

        }

        public Aluno UpdateAluno(Aluno aluno)
        {
            
        }
    }
}