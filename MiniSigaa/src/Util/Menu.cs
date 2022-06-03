using MiniSigaa.Repository;
using MiniSigaa.Models;

namespace MiniSigaa.Util
{
    public class Menu : IMenu
    {

        private readonly ICourseClassRepository _course;
        private readonly IStudentRepository _student;

        public Menu(ICourseClassRepository courseClass, IStudentRepository student)
        {
            _course = courseClass;
            _student = student;
        }

        public bool MainMenu()
        {
            Console.WriteLine("\n1 - Listar Notas das Classes Existentes");
            Console.WriteLine("2 - Cadastrar Notas");
            Console.WriteLine("0 - Sair");
            
            Console.Write("Opção: ");
            Thread.Sleep(3000);

            switch (Console.ReadLine())
            {
                case "0":
                    Console.WriteLine("\nTerminando programa...");
                    return false;
                case "1":
                    PrintCourseClasses();
                    return true;
                case "2":
                    RegisterStudentsGrades();
                    return true;
                default:
                    Console.WriteLine("\nOpção inválida");
                    return true;
            }
        }

        private void PrintCourseClasses()
        {
            if(_course.GetAllCourseClasses().Any())
            {
                Console.WriteLine("\nTurmas: ");
                foreach(var courseClass in _course.GetAllCourseClasses())
                {
                    PrintCourseClass(courseClass.Id);
                }
            }
            else
            {
                Console.WriteLine("\nNão existem classes com notas, cadastre notas para criar uma");
            }
        }

        private void PrintCourseClass(int classId)
        {
            var courseClass = _course.GetCourseClassById(classId);
            Console.WriteLine($"Id: {courseClass.Id} " +
                                $" | Quantidade de Alunos {courseClass.QuantityStudents}" +
                                $" | Média da turma {courseClass.CourseClassAvarageGrade}");

            var students = courseClass.StudentsInCourseClass;
            for(int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"\tId(aluno): {students[i].Id} | " +
                                    $"Nota 1: {students[i].Grade1} | " +
                                    $"Nota 2: {students[i].Grade2} | " +
                                    $"Nota 3: {students[i].Grade3} | " +
                                    $"Aprovado: {students[i].Aproved} | " +
                                    $"Nota 4: {students[i].Grade4} ");
            }
        }

        private void RegisterGradesMenu(int classId)
        {            
            Console.Write("\nInsira o número de alunos para registrar notas: ");
            int numberOfStudents = Convert.ToInt32(Console.ReadLine());

            for(int i = 0; i < numberOfStudents; i++)
            {
                Console.Write("Insira as três notas (separas por espaço e usando \".\" para casas decimais): ");
                string[] gradesStr = Console.ReadLine().Split(" ");        

                if((gradesStr == null || gradesStr.Length == 0)) throw new ArgumentNullException(Constants.ErrorNullValue);        

                List<decimal> grades = gradesStr.Select(s => decimal.Parse(s)).ToList();
                
                int studentId = _course.AddStudent(classId);

                _course.RegisterGrades(classId, studentId, grades);
            }
        }

        private void RegisterStudentsGrades()
        {
            if(_course.GetAllCourseClasses().Any())
            {
                Console.Write("\nSelecione a classe(-1 para nova classe): ");
                var classId = Convert.ToInt32(Console.ReadLine());
                if(classId != -1)
                {
                    var existingClass = _course.GetCourseClassById(classId);
                    PrintCourseClass(existingClass.Id);

                    RegisterGradesMenu(existingClass.Id);
                }
                else
                {
                    var  newCourseClass = _course.CreateCourseClass();
                
                    RegisterGradesMenu(newCourseClass.Id);
                }
                
            }
            else 
            {
                var  newCourseClass = _course.CreateCourseClass();
                
                RegisterGradesMenu(newCourseClass.Id);
            }            
        }

        
    }
}