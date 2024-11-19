namespace Domain.Questions;

public interface IQuestionRepository
{
    void Add(Question question);
    
    void Update(Question question);

    void Delete(Question product);

    Task<Question> GetById(Guid id);
    
    Task<IEnumerable<Question>> List();
    
    Task<IEnumerable<Question>> ListByLesson(Guid lessonId);

}