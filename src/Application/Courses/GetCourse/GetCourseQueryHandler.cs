using Domain.Courses;
using Domain.Lessons;
using MediatR;

namespace Application.Courses.GetCourse;

public class GetCourseQueryHandler:IRequestHandler<GetCourseQuery,Course>
{
    private readonly ICourseRepository _courseRepository;
    private readonly ILessonRepository _lessonRepository;

    public GetCourseQueryHandler(ICourseRepository courseRepository, ILessonRepository lessonRepository)
    {
        _courseRepository = courseRepository;
        _lessonRepository = lessonRepository;
    }

    public async Task<Course> Handle(GetCourseQuery request, CancellationToken cancellationToken)
    {   
        var course =  await _courseRepository.GetById(request.CourseId);
        var lessons = await _lessonRepository.ListByCourse(request.CourseId);
        
        course.Lessons = lessons;
        return course;
    }
}