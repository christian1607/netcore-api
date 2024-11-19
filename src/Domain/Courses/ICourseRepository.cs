namespace Domain.Courses;

public interface ICourseRepository
{
    void Add(Course question);
    
    void Update(Course question);

    void Delete(Course product);

    Task<Course> GetById(Guid id);
    
    Task<IEnumerable<Course>> List();
    

}