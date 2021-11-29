using System.Text;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> cidades = new List<string>();

            cidades.Add("São Luís");
            cidades.Add("Paço do Lumiar");
            cidades.Add("São José de Ribamar");
            cidades.Add("Bacabal");
            cidades.Add("Imperatriz");

            BuscarListaLinqLambda(cidades, "Sã").ForEach(x => Console.WriteLine(x));
        }

        public static string BuscarPrimeiroForeach(List<string> lista, string termo)

        {
            foreach(string item in lista)
            {
                if (item.Equals(termo))
                    return item;
            }
            return null;
        }
    
        public static string BuscarPrimeiroLinq(List<string> lista, string termo)
        {
            return (from item in lista where item.Equals(termo) select item).First();
        }
 
        public static string BuscarPrimeiroLinqLambda(List<string> lista, string termo)
        {
            return lista.First(x => x.Equals(termo));
        }
 

        public static List<string> BuscarListaLinq(List<string> lista, string termo)
        {
            return (from item in lista where item.Contains(termo) select item).ToList();
        }

        public static List<string> BuscarListaLinqLambda(List<string> lista, string termo)
        {
            return lista.Where(x => x.Contains(termo)).ToList();    
        }
    }    
}