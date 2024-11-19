using Domain.Courses;

namespace Domain.Students;

public interface IStudentRepository
{
    void Add(Student student);
    
    void Update(Student student);
    
    void Delete(Student student);
    
    Task<Student> GetById(Guid id);
    
    Task<IEnumerable<Student>> ListStudents();
    
    Student GetByUsername(string username);
    
    Student GetByEmail(string email);
    
    void AddStudentCourse(StudentCourse studentCourse);
    
    Task<StudentCourse> GetStudentCourse(Guid studentId, Guid courseId);
    
    Task<IEnumerable<StudentCourse>> GetRegisteredCoursesByStudent(Guid sudentId);
    
    void AddStudentLesson(StudentLesson studentCourse);
    
    Task<StudentLesson> GetStudentLesson(Guid studentId, Guid lessonId);
    
    Task<IEnumerable<StudentLesson>> GetRegisteredLessonsByStudent(Guid studentId, Guid lessonId);
}