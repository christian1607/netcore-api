using Domain.Primitives;
using Domain.Questions;

namespace Domain.Lessons;

public class Lesson : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
    
    public int ApprovalThreshold { get; set; }
    
    public Guid RequiredLessonId { get; set; }
    public Guid CourseId { get; set; }

    public IEnumerable<Question> Questions { get; set; }

    public Lesson()
    {
        
    }

    public Lesson(string name, string description, Guid courseId)
    {
        Name = name;
        Description = description;
        CourseId = courseId;
    }

    public void AddQuestion(IEnumerable<Question> question)
    {
        Questions=Questions.Union(question);
    }

    public bool HasRequiredLesson()
    {
        return RequiredLessonId != Guid.Empty;
    }

    public void AddRequiredLesson(Guid requiredLessonId)
    {
        RequiredLessonId = requiredLessonId;
    }
    
}