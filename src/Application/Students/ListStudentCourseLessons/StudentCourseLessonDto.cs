namespace Application.Students.ListStudentCourses;

public class StudentCourseLessonDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Enable { get; set; }

    public StudentCourseLessonDto(Guid id, string name, string description, bool available)
    {
        Id = id;
        Name = name;
        Description = description;
        Enable = available;
    }
}