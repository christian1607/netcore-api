namespace Domain.Courses;

public class StudentLesson
{
    public Guid StudentId { get; set; }
    public Guid LessonId { get; set; }
    public Guid CourseId { get; set; }
    public string Status {get; set;}

    public StudentLesson()
    {
    }

    public static StudentLesson RegisterStudentLesson(Guid studentId, Guid courseId, Guid lessonId)
    {
        var studentCourse = new StudentLesson
        {
            LessonId = lessonId,
            CourseId = courseId,
            StudentId = studentId,
            Status = "REGISTERED"
        };

        return studentCourse;
    }
}