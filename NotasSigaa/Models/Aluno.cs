
namespace NotasSigaa.Models
{
    [Table("Alunos")]
    public record Aluno    
    {
        [Key]
        public int Matricula {get; init; }

        public string PrimeiroNome {get; init; }

        public string Sobrenome {get; init; }

    }
}