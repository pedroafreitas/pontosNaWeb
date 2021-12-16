namespace MiniSigaa.Models.Repository
{
    public class CourseClassRepository : ICourseClassRepository
    {
        public CourseClassRepository()
        {
        }

        IEnumerable<CourseClass> ICourseClassRepository.GetAllCourseClasses()
        {
            throw new NotImplementedException();
        }

        IEnumerable<Student> ICourseClassRepository.GetAllStudentsInCourseClass()
        {
            throw new NotImplementedException();
        }

        decimal ICourseClassRepository.GetCourseClassAvarageGrade()
        {
            throw new NotImplementedException();
        }

        CourseClass ICourseClassRepository.GetCourseClassById(int id)
        {
            throw new NotImplementedException();
        }

        void ICourseClassRepository.ResgisterStudentGrade(Student student, decimal grade, int gradeNumber)
        {
            throw new NotImplementedException();
        }

        void ICourseClassRepository.SaveGradesInMemory()
        {
            throw new NotImplementedException();
        }

        bool ICourseClassRepository.StudentFailed(Student student)
        {
            throw new NotImplementedException();
        }
    }
}