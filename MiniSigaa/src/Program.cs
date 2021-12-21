using MiniSigaa.Models;
using MiniSigaa.Repository;
using MiniSigaa.Util;

namespace MiniSigaa
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            bool showMenu = true;

            CourseClassRepository courseClass = new();
            StudentClassRepository student = new();

            Menu menu = new(courseClass, student);
            try
            {
                Console.Clear();
                Console.WriteLine("Bem-vindo(a) ao Mini Sigaa: ");

                if(menu != null)
                {
                    while (showMenu)
                        showMenu = menu.MainMenu();
                }              
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}