namespace NotasSigaa.Turma
{
    [Table("Turmas")]
    public record Turma
    {
        [Key]
        public int COD_TURMA {get; init; }

        public decimal Media {get; init; }

        public string NomeDisciplina {get; init; }
    }
}