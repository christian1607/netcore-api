namespace Domain.Courses;

public class StudentCourse
{
    public Guid StudentId { get; set; }
    public Guid CourseId { get; set; }
    public string Status {get; set;}

    public StudentCourse()
    {
        
    }

    public static StudentCourse RegisterStudent(Guid studentId, Guid courseId)
    {
        var studentCourse = new StudentCourse
        {
            CourseId = courseId,
            StudentId = studentId,
            Status = "REGISTERED"
        };

        return studentCourse;
    }
}