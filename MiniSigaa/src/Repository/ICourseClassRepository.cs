namespace MiniSigaa.Models.Repository
{
    public interface ICourseClassRepository
    {
        IEnumerable<Student> GetAllStudentsInCourseClass();

        IEnumerable<CourseClass> GetAllCourseClasses();

        CourseClass GetCourseClassById(int id);

        void ResgisterStudentGrade(Student student, decimal grade, int gradeNumber);

        bool StudentFailed(Student student);

        void SaveGradesInMemory();

        decimal GetCourseClassAvarageGrade();
    }
}