namespace Domain.Lessons;

public interface ILessonRepository
{
    void Add(Lesson lesson);
    
    void Update(Lesson lesson);

    void Delete(Lesson lesson);

    Task<Lesson> GetById(Guid id);
    
    Task<IEnumerable<Lesson>> List();
    
    Task<IEnumerable<Lesson>> ListByCourse(Guid courseId);
}