using MiniSigaa.Models;

namespace MiniSigaa.Repository
{
    public class StudentClassRepository : IStudentRepository
    {
        private readonly List<CourseClass> courseClasses = new();
        
        public bool StudentPassed(Student student, int numberOfGrades = 3, decimal minimum = 7.0m)
        {
            if((student.Grade1 + student.Grade2 + student.Grade3)/numberOfGrades < minimum)
                return true;
            return false;
        }
    }
}