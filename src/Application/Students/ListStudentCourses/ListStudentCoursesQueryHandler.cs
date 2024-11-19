using Domain.Courses;
using Domain.Students;
using MediatR;

namespace Application.Students.ListStudentCourses;

public class ListStudentCoursesQueryHandler: IRequestHandler<ListStudentCoursesQuery,IEnumerable<StudentCourseDto>>
{
    private readonly IStudentRepository _studentRepository;
    private readonly ICourseRepository _courseRepository;

    public ListStudentCoursesQueryHandler(IStudentRepository studentRepository, ICourseRepository courseRepository)
    {
        _studentRepository = studentRepository;
        _courseRepository = courseRepository;
    }

    public async Task<IEnumerable<StudentCourseDto>> Handle(ListStudentCoursesQuery request, CancellationToken cancellationToken)
    {
        var availableCourses = _courseRepository.List().Result;
        var registeredCourses =  _studentRepository.GetRegisteredCoursesByStudent(request.StudentId).Result;

        var studentCourses = new List<StudentCourseDto>();

        foreach (var course in availableCourses)
        {
            if (registeredCourses.FirstOrDefault(rc => rc.CourseId == course.Id, null) != null)
            {
                studentCourses.Add(new StudentCourseDto(course.Id,course.Name, course.Description,true));
            }
            else
            {
                if (course.RequiredCourseId == Guid.Empty)
                {
                    studentCourses.Add(new StudentCourseDto(course.Id, course.Name, course.Description,true));
                }
                else
                {
                    var registeredCourse = _studentRepository.GetStudentCourse(request.StudentId, course.RequiredCourseId).Result;

                    studentCourses.Add(registeredCourse is { Status: "APPROVED" }
                        ? new StudentCourseDto(course.Id, course.Name, course.Description, true)
                        : new StudentCourseDto(course.Id, course.Name, course.Description, false));
                }
            }
        }

        return studentCourses;
    }
}