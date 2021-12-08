namespace NotasSigaa.Repository.Interfaces
{
    public interface IAlunosRepository
    {
        Aluno Create(Aluno aluno);
        
        Aluno Delete(int matricula);

        IEnumerable<Aluno> GetAllAlunos();

        Aluno GetByMatricula(int matricula);

        Aluno GetByName(string primeiroNome);

        Aluno UpdateAluno(Aluno aluno);
    }
}