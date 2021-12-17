using MiniSigaa.Repository;
using MiniSigaa.Models;

namespace MiniSigaa.Util
{
    public class Menu : IMenu
    {

        private readonly ICourseClassRepository _courseClass;

        public Menu(ICourseClassRepository courseClass)
        {
            _courseClass = courseClass;
        }

        public bool MainMenu()
        {
            Console.WriteLine("1 - Listar Notas das Classes Existentes");
            Console.WriteLine("2 - Cadastrar Notas de um Aluno");
            Console.WriteLine("0 - Sair\n");
            
            Console.Write("Opção: ");
            switch (Console.ReadLine())
            {
                case "0":
                    Console.WriteLine("Terminando programa...");
                    return false;
                case "1":
                
                    if(_courseClass.GetAllCourseClasses().Any())
                    {
                        Console.WriteLine("\nTurmas: ");
                        foreach(var courseClass in _courseClass.GetAllCourseClasses())
                        {
                            PrintCourseClass(courseClass.Id);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Não existem classes com notas, cadastre notas para criar uma\n");
                    }
                    return true;
                case "2":

                    int classId = 1;                    
                    if(_courseClass.GetAllCourseClasses().Any())
                    {
                        Console.Write("\nSelecione a classe: ");
                        classId = Convert.ToInt32(Console.ReadLine());
                        PrintCourseClass(classId);

                        RegisterGradesMenu(classId);
                    }
                    else 
                    {
                        
                        _courseClass.CreateCourseClass(courseClass);
                        RegisterGradesMenu(classId);
                    }

                    return true;
                default:
                    Console.WriteLine("Opção inválida");
                    return true;
            }
        }

        private void PrintCourseClass(int classId)
        {
            var courseClass = _courseClass.GetCourseClassById(classId);
            Console.WriteLine($"Id: {courseClass.Id} " +
                                $" | Quantidade de Alunos {courseClass.QuantityStudents}" +
                                $" | Média da turma {courseClass.CourseClassAvarageGrade}");

            var students = courseClass.StudentsInCourseClass;
            for(int i = 0; i < students.Count; i++)
            {
                
                Console.WriteLine($"\tId(aluno): {i + 1}" +
                                    $"Nota 1: {students[i].Grade1}" +
                                    $"Nota 1: {students[i].Grade2}" +
                                    $"Nota 1: {students[i].Grade3}" +
                                    $"Nota 1: {students[i].Aproved}" +
                                    $"Nota 1: {students[i].Grade4}");
            }
        }

        private void RegisterGradesMenu(int classId)
        {
            Console.WriteLine("\nInsira o número de alunos para registrar notas: ");
            int numberOfStudents = Convert.ToInt32(Console.ReadLine());

            for(int i = 0; i < numberOfStudents; i++)
            {
                Console.WriteLine("Insira as três notas (separas por espaço e usando \".\" para casas decimais): ");
                string[] gradesStr = Console.ReadLine().Split(" ");                        
                List<decimal> grades = gradesStr.Select(s => decimal.Parse(s)).ToList();
                
                var students = _courseClass.GetClassStudents(classId);
                foreach(var student in students)
                {
                    RegisterGrades(student, grades);
                    students.Add(student);
                }
            }
        }
        
        private void RegisterGrades(Student student, List<decimal> grades, int maxCapacity = 5)
        {
            student.Grade1 = grades[0];
            student.Grade2 = grades[1];
            student.Grade3 = grades[2];      
        }
    }
}