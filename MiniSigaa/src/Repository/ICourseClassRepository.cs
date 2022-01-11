using MiniSigaa.Models;

namespace MiniSigaa.Repository
{
    public interface ICourseClassRepository
    {
        IEnumerable<CourseClass> GetAllCourseClasses();

        CourseClass GetCourseClassById(int id);

        List<Student> GetClassStudents(int courseId);

        CourseClass CreateCourseClass();

        int AddStudent(int courseId);

        void RegisterGrades(int courseId, int studentId, List<decimal> grades);
    }
}