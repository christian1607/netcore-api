namespace Application.Students.ListStudentCourses;

public class StudentCourseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Available { get; set; }

    public StudentCourseDto(Guid id, string name, string description, bool available)
    {
        Id = id;
        Name = name;
        Description = description;
        Available = available;
    }
}