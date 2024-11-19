using Domain.Questions;
using Infrastructure.Db;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class QuestionRepository : IQuestionRepository
{   
    private readonly ApplicationDbContext _dbContext;

    public QuestionRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public void Add(Question question)
    {
        _dbContext.Add(question);
    }

    public void Update(Question question)
    {
        _dbContext.Update(question);
    }

    public void Delete(Question product)
    {
        _dbContext.Remove(product);
    }

    public async Task<Question> GetById(Guid id)
    {
        var question =  await _dbContext.Questions.FirstAsync(q => q.Id == id);
        return question;
    }

    public async Task<IEnumerable<Question>> List()
    {
        return await _dbContext.Questions.ToListAsync();
    }

    public async Task<IEnumerable<Question>> ListByLesson(Guid lessonId)
    {
        return await _dbContext.Questions.Where(q=>q.LessonId == lessonId).ToListAsync();
    }
}