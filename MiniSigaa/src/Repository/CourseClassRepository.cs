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

        public CourseClass CreateCourseClass()
        {
            CourseClass newCourseClass = new();

            newCourseClass.StudentsInCourseClass = new List<Student>();

            courseClasses.Add(newCourseClass);
            
            return newCourseClass;
        }

        public int AddStudent(int courseId)
        {
            var courseClass = GetCourseClassById(courseId);

            courseClass.StudentsInCourseClass.Add(new Student());

            return courseClass.StudentsInCourseClass.Last().Id;     
        }

        public List<Student> GetClassStudents(int courseId)
        {
            var courseClass = GetCourseClassById(courseId);
            
            var students = courseClass.StudentsInCourseClass ?? throw new ArgumentNullException(Constants.ErrorNullValue);;

            return students;
        }

        public void RegisterGrades(int courseId, int studentId, List<decimal> grades)
        {
            var courseClass = GetCourseClassById(courseId);
            var student = courseClass.StudentsInCourseClass[studentId];

            student.Grade1 = grades[0];
            student.Grade2 = grades[1];
            student.Grade3 = grades[2];
        }
    }
}