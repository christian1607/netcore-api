using Domain.Courses;
using Infrastructure.Db;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class CourseRepository : ICourseRepository
{
    private ApplicationDbContext _dbContext;

    public CourseRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void Add(Course course)
    {
        _dbContext.Add(course);
    }

    public void Update(Course course)
    {
        _dbContext.Update(course);
    }

    public void Delete(Course course)
    {
        _dbContext.Remove(course);
    }

    public async Task<Course> GetById(Guid id)
    {
        return await _dbContext.Courses.FindAsync(id);
    }

    public async Task<IEnumerable<Course>> List()
    {
        return await _dbContext.Courses.ToListAsync();

    }

    
}