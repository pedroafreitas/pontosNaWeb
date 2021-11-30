using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsumindoApi
{
    public class UsuarioRepository
    {
        HttpClient client = new HttpClient();

        public UsuarioRepository()
        {
            client.BaseAddress = new Uri("https://localhost:5001");

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));          
        }

        public async Task<List<Usuario>> GetUsuariosAsync()
        {
            HttpResponseMessage response = await client.GetAsync("api/usuarios");
            if (response.IsSuccessStatusCode)
            {
                var dados = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Usuario>>(dados) ?? throw new ArgumentNullException();
            }
            return new List<Usuario>();
        }
        
    }
}