namespace NotasSigaa
{
    [Table("Turmas")]
    public record Turmas
    {
        [Key]
        public int COD_TURMA {get; init; }

        public decimal Media {get; init; }

        public string NomeDisciplina {get; init; }
    }
}