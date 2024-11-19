using Domain.Primitives;

namespace Domain.Questions;

public class Question : Entity
{
    public int Score { get; set; }
    public string Content { get; set; }
    
    public Guid LessonId { get; set; }
    
    public Question()
    {
        
    }

    public Question(int score, string content, Guid lessonId)
    {
        Score = score;
        Content = content;
        LessonId = lessonId;
    }
}