using MiniSigaa.Util;
using MiniSigaa.Models;
namespace MiniSigaa.Repository
{
    public class CourseClassRepository : ICourseClassRepository
    {
        private readonly List<CourseClass> courseClasses = new();

        public IEnumerable<CourseClass> GetAllCourseClasses()
        {
            return courseClasses;
        }

        public CourseClass GetCourseClassById(int courseId)
        {
            var courseClass = courseClasses.Where(existingClass => existingClass.Id == courseId).SingleOrDefault()
                                ?? throw new ArgumentNullException(Constants.ErrorNullValue);
            return courseClass;
        }

        public void CreateCourseClass(CourseClass courseClass)
        {
            courseClasses.Add(courseClass);
        }

        public List<Student> GetClassStudents(int courseId)
        {
            var courseClass = GetCourseClassById(courseId);
            var students = courseClass.StudentsInCourseClass ?? throw new ArgumentNullException(Constants.ErrorNullValue);

            return students;
        }
    }
}