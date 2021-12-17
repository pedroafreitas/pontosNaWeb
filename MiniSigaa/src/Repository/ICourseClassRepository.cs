using MiniSigaa.Models;

namespace MiniSigaa.Repository
{
    public interface ICourseClassRepository
    {
        IEnumerable<CourseClass> GetAllCourseClasses();

        CourseClass GetCourseClassById(int id);

        List<Student> GetClassStudents(int courseId);

        void CreateCourseClass(CourseClass courseClass);
    }
}