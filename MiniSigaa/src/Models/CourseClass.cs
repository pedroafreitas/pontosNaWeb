namespace MiniSigaa.Models  
{
    public class CourseClass
    {
        public int Id {get; init; }

        public List<Student>? StudentsInCourseClass {get; set; }

        public int QuantityStudents {get; set; }

        public decimal CourseClassAvarageGrade {get; set; }
    }
}