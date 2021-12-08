
namespace NotasSigaa.Models
{
    [Table("Alunos")]
    public record Alunos    
    {
        [Key]
        public int Matricula {get; init; }

        public string PrimeiroNome {get; init; }

        public string Sobrenome {get; init; }

    }
}