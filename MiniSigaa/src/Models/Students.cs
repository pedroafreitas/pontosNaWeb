using System.ComponentModel.DataAnnotations;

namespace MiniSigaa.Models
{
    public class Student
    {
        [Key]
        public int Id {get; init; }

        public decimal Grade1 {get; set; }

        public decimal Grade2 {get; set; }

        public decimal Grade3 {get; set; }

        public bool Aproved {get; set; }
        
        public decimal Grade4 {get; set; }
    }
}