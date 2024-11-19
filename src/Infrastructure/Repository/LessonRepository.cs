using Domain.Lessons;
using Infrastructure.Db;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class LessonRepository : ILessonRepository
{
    private readonly ApplicationDbContext _dbDbContext;

    public LessonRepository(ApplicationDbContext dbDbContext)
    {
        _dbDbContext = dbDbContext;
    }

    public void Add(Lesson lesson)
    {
        _dbDbContext.Lessons.Add(lesson);
    }

    public void Update(Lesson lesson)
    {
        _dbDbContext.Lessons.Update(lesson);
    }

    public void Delete(Lesson lesson)
    {
        _dbDbContext.Lessons.Remove(lesson);
    }

    public async Task<Lesson> GetById(Guid id)
    {
        return await _dbDbContext.Lessons.FindAsync(id);
    }

    public async Task<IEnumerable<Lesson>> List()
    {
        return await _dbDbContext.Lessons.ToListAsync();
    }

    public async Task<IEnumerable<Lesson>> ListByCourse(Guid courseId)
    {
        return await _dbDbContext.Lessons.Where(l => l.CourseId == courseId).ToListAsync();
    }
}