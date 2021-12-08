namespace NotasSigaa.Models
{
    [Table("Historicos")]
    public record Historico
    {
        [Key]
        public int Matricula {get; init; }

        public int COD_TURMA {get; init; }
        
        public decimal Nota1 {get; set; }

        public decimal Nota2 {get; set; }

        public decimal Nota3 {get; set; }

        public decimal Media1 {get; init; }

        public decimal NotaReposicao {get; init; }

        public decimal MediaFinal {get; init; }

        public bool Aprovado {get; init; }
    }
}