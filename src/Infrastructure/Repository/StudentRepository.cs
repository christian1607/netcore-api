using Domain.Courses;
using Domain.Students;
using Infrastructure.Db;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class StudentRepository : IStudentRepository
{
    private readonly ApplicationDbContext _dbContext;

    public StudentRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void Add(Student student)
    {
        _dbContext.Students.Add(student);
    }

    public void Update(Student student)
    {
        throw new NotImplementedException();
    }

    public void Delete(Student student)
    {
        throw new NotImplementedException();
    }

    public async Task<Student> GetById(Guid id)
    {
        return await _dbContext.Students.FindAsync(id);
    }

    public async Task<IEnumerable<Student>> ListStudents()
    {
        return await _dbContext.Students.ToListAsync();
    }

    public Student GetByUsername(string username)
    {
        throw new NotImplementedException();
    }

    public Student GetByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public void AddStudentCourse(StudentCourse studentCourse)
    {
        _dbContext.StudentCourses.Add(studentCourse);
    }

    public async Task<StudentCourse> GetStudentCourse(Guid studentId, Guid courseId)
    {
        return await _dbContext.StudentCourses.FindAsync(studentId, courseId);
    }

    public async Task<IEnumerable<StudentCourse>> GetRegisteredCoursesByStudent(Guid studentId)
    {
        return await _dbContext.StudentCourses
            .Where(r=>r.StudentId == studentId)
            .ToListAsync();
    }

    public void AddStudentLesson(StudentLesson studentLesson)
    {
        _dbContext.StudentLessons.Add(studentLesson);
    }

    public async Task<StudentLesson> GetStudentLesson(Guid studentId, Guid lessonId)
    {
        return await _dbContext.StudentLessons.FindAsync(studentId, lessonId);
    }

    public async Task<IEnumerable<StudentLesson>> GetRegisteredLessonsByStudent(Guid studentId, Guid courseId)
    {
        return await _dbContext.StudentLessons
            .Where(r=>r.StudentId == studentId && r.CourseId == courseId)
            .ToListAsync();
    }
}