using MiniSigaa.Models;

namespace MiniSigaa.Repository
{
    public interface IStudentRepository
    {
        bool StudentPassed(Student student, int numberOfGrades, decimal minimum);
    }
}