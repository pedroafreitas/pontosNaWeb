using System;

namespace Algorithms
{
    public class Program{

        public static void Main(string[] args)
        {
            List<string> descricoes = new();
            descricoes.Add("Parcela Smartphone 12/18");
            descricoes.Add("Parcela Smartphone 02/18");
            descricoes.Add("Parcela Smartphone 03/18");
            List<int> paramss = new List<int>();
            paramss.Add(2);
            paramss.Add(3);

            var listaDeDebitosSelecionados = new List<string>();

            foreach (int parcela in paramss)
            {
                var debito = descricoes
                    .Where(x => int.Parse((x.Split("/")[0])[^2..]) == parcela)
                    .SingleOrDefault();
                listaDeDebitosSelecionados.Add(debito);
            }

            foreach (string deb in listaDeDebitosSelecionados)
            {
                Console.WriteLine(deb);
            }
                
        }

        static int findMax(int a, int b, int c)
        {
            var max = a;
            if(b > max)    
                max = b;
            if(c > max)
                max = c;
            return max;
        }
    }
}
