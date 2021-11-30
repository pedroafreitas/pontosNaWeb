namespace ConsumindoApi
{
    public class Usuario
    {
        public int UsuarioId{get; set; }

        public string? Nome{get; set; }

        public string? Senha{get; set; }

        public string? Email{get; set; }

        public override string ToString()
        {
            return string.Format($"{Nome} - {Email}"); 
        }
    }
}