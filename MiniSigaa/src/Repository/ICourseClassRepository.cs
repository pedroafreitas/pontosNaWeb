namespace MiniSigaa.Models.Repository
{
    public interface ICourseClassRepository
    {
        Task<IEnumerable<CourseClass>> GetAllCourseClasses();

        Task<CourseClass> GetCourseClassById(int id);

        Task RegisterStudent(int courseId, string name);

        Task<List<Student>> GetClassStudents(int courseId);

        Task<bool> StudentPassed(Student student, int numberOfGrades, decimal minimum);
    }
}