using System.ComponentModel.DataAnnotations;

namespace NotasSigaa.Turma
{
    public record Turma
    {
        public int COD_TURMA {get; init; }

        public decimal Media {get; init; }

        public string NomeDisciplina {get; init; }
    }
}