namespace MiniSigaa.Models.Repository
{
    public class CourseClassRepository : ICourseClassRepository
    {
        private readonly List<CourseClass> courseClasses = new();

        public async Task<IEnumerable<CourseClass>> GetAllCourseClasses()
        {
            return await Task.FromResult(courseClasses);
        }

        public async Task<CourseClass> GetCourseClassById(int courseId)
        {
            var courseClass = courseClasses.Where(existingClass => existingClass.Id == courseId).SingleOrDefault()
                                ?? throw new ArgumentNullException(Constants.ErrorNullValue);
            return await Task.FromResult(courseClass);
        }

        public async Task RegisterStudent(int courseId, string name)
        {
            Student student = new();
            student.Name = name;
            var students = await GetClassStudents(courseId);
            students.Add(student);
        }

        public async Task<List<Student>> GetClassStudents(int courseId)
        {
            var courseClass = await GetCourseClassById(courseId);
            var students = courseClass.StudentsInCourseClass ?? throw new ArgumentNullException(Constants.ErrorNullValue);

            return await Task.FromResult(students);
        }

        public async Task<bool> StudentPassed(Student student, int numberOfGrades = 3, decimal minimum = 7.0m)
        {
            if((student.Grade1 + student.Grade2 + student.Grade3)/numberOfGrades < minimum)
                return await Task.FromResult(true);
            return await Task.FromResult(false);
        }
    }
}