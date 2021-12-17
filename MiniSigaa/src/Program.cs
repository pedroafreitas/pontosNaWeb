using MiniSigaa.Models;
using MiniSigaa.Models.Repository;

namespace MiniSigaa
{
    public class Program
    {
        private readonly ICourseClassRepository _courseClasses;
        public Program(ICourseClassRepository courseClass)
        {
            _courseClasses = courseClass;
        }

        public static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
                showMenu = MainMenu();
        }

        private static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Bem-vindo(a) ao Mini Sigaa");

            Console.WriteLine("1 - Listar Turmas Existentes");
            Console.WriteLine("2 - Cadastrar Notas de um Aluno");
            Console.WriteLine("Aperte 0 para sair");
            
            switch (Console.ReadLine())
            {
                case "0":
                    Console.WriteLine("Terminando programa...");
                    return false;
                case "1":
                    Console.WriteLine("\nTurmas existentes:");
                    ListCourseClasses();
                    return true;
                case "2":
                    RegisterGrades();
                    return true;
                default:
                    return true;
            }
        }

        private static void RegisterGrades()
        {
            throw new NotImplementedException();
        }

        private static void ListCourseClasses()
        {
            throw new NotImplementedException();            
        }
    }
}