namespace MiniSigaa.Models  
{
    public class CourseClass
    {
        public int Id {get; init; }

        IEnumerable<Student>? StudentsInCourseClass {get; set; }

        public int QuantityStudents {get; set; }

        public decimal CourseClassAvarageGrade {get; set; }
    }
}