using System.ComponentModel.DataAnnotations;

namespace TesteDeCasa.Dtos
{
    public class AuthenticateDto
    {
        [Required]
        [RegularExpression(@"[0][1-9]\d{9}$|^[1-9]\d{9}$")]        
        public string AccountNumber {get; init; }

        [Required]
        public string Pin {get; set; }


    }
}