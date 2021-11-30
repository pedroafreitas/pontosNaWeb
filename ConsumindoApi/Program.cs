using static System.Console;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System;

namespace ConsumindoApi
{
    public class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Acessando a WEB API...");

            var repository = new UsuarioRepository();

            var usuariosTask = repository.GetUsuariosAsync();

            usuariosTask.ContinueWith(task =>
            {
                var usuarios = task.Result;
                foreach(var usuario in usuarios)
                    WriteLine(usuario.ToString());
                    
                Environment.Exit(0);
            },
            TaskContinuationOptions.OnlyOnRanToCompletion
            );

        ReadLine();
        }
    }
}