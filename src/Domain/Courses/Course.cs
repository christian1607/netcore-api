using Domain.Lessons;
using Domain.Primitives;
using Domain.Students;

namespace Domain.Courses;

public class Course : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid RequiredCourseId { get; set; }
    public IEnumerable<Lesson> Lessons { get; set;}

    public IEnumerable<Student> Students { get; set; }
    
    public Course()
    {
    }

    public Course(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void AssignLesson(Lesson lesson)
    {
        _ = Lessons.Append(lesson);
    }

    public void AddRequiredCourse(Guid requiredCourseId )
    {
        RequiredCourseId = requiredCourseId;
    }

    public bool HasRequiredCourse()
    {
        return RequiredCourseId != Guid.Empty;
    }
}