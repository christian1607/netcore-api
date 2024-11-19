using Application.Students.ListStudentCourseLessons;
using Domain.Courses;
using Domain.Lessons;
using Domain.Students;
using MediatR;

namespace Application.Students.ListStudentCourses;

public class ListStudentCourseLessonsQueryHandler: IRequestHandler<ListStudentCourseLessonsQuery,IEnumerable<StudentCourseLessonDto>>
{
    private readonly IStudentRepository _studentRepository;
    private readonly ICourseRepository _courseRepository;
    private readonly ILessonRepository _lessonRepository;

    public ListStudentCourseLessonsQueryHandler(IStudentRepository studentRepository, ICourseRepository courseRepository, ILessonRepository lessonRepository)
    {
        _studentRepository = studentRepository;
        _courseRepository = courseRepository;
        _lessonRepository = lessonRepository;
    }

    public async Task<IEnumerable<StudentCourseLessonDto>> Handle(ListStudentCourseLessonsQuery request, CancellationToken cancellationToken)
    {
        var lessons = await _lessonRepository.ListByCourse(request.CourseId);
        var lessonsTaken = await _studentRepository.GetRegisteredLessonsByStudent(request.StudentId,request.CourseId);

        var studentLessons = new List<StudentCourseLessonDto>();

        foreach (var lesson in lessons)
        {
            if (lessonsTaken.FirstOrDefault(rc => rc.CourseId == lesson.Id, null) != null)
            {
                studentLessons.Add(new StudentCourseLessonDto(lesson.Id,lesson.Name, lesson.Description,true));
            }
            else
            {
                if (lesson.RequiredLessonId == Guid.Empty)
                {
                    studentLessons.Add(new StudentCourseLessonDto(lesson.Id, lesson.Name, lesson.Description,true));
                }
                else
                {
                    var registeredCourse = await _studentRepository.GetStudentLesson(request.StudentId, lesson.RequiredLessonId);

                    studentLessons.Add(registeredCourse is { Status: "APPROVED" }
                        ? new StudentCourseLessonDto(lesson.Id, lesson.Name, lesson.Description, true)
                        : new StudentCourseLessonDto(lesson.Id, lesson.Name, lesson.Description, false));
                }
            }
        }

        return studentLessons;
    }
}