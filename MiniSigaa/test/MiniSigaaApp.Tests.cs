using Xunit;

namespace test;

public class UnitTest1
{
    [Fact]
    public void Add_More_Than_Five_Students()
    {
        //Arrange
        var class = project.classes new();
        var student1 = new Student();
        var student2 = new Student();
        var student3 = new Student();
        var student4 = new Student();
        var student5 = new Student();
        var student6 = new Student();

        //Act

        project.RegisterGradesMenu(class, student1);
        project.RegisterGradesMenu(class, student1);
        project.RegisterGradesMenu(class, student1);
        project.RegisterGradesMenu(class, student1);
        project.RegisterGradesMenu(class, student1);
        project.RegisterGradesMenu(class, student1);

        //Assert
        Assert.Equals(class.size(), 5);
                
    }

    [Fact]
    public void Add_Four_Grades_To_Student()
    {
        //Arrange
        var class = project.classes new();
        var student1 = new Student();
        

        //Act
        project.Class(student1, 4, 6, 3, 6);


        //Assert
        Assert.Equals(class.student1.grades.size(), 3);
                
    }

    [Fact]
    public void Verify_Student_Has_Failed()
    {
        //Arrange
        var class = project.classes new();
        var student1 = new Student();

        //Act
        project.Class(student1, 4, 6, 3);


        //Assert
        Assert.Equals(class.student1.Aproved, false);
                
    }

}