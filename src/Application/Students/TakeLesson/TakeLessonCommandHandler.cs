using Application.Meta;
using Application.Students.TakeCourse;
using Domain.Courses;
using Domain.Lessons;
using Domain.Students;
using MediatR;

namespace Application.Students.TakeLesson;

public class TakeLessonCommandHandler: IRequestHandler<TakeLessonCommand>
{
    private readonly ICourseRepository _courseRepository;
    private readonly ILessonRepository _lessonRepository;
    private readonly IStudentRepository _studentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public TakeLessonCommandHandler(ICourseRepository courseRepository, ILessonRepository lessonRepository, IStudentRepository studentRepository, IUnitOfWork unitOfWork)
    {
        _courseRepository = courseRepository;
        _lessonRepository = lessonRepository;
        _studentRepository = studentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(TakeLessonCommand request, CancellationToken cancellationToken)
    {
        var course = await _courseRepository.GetById(request.CourseId);
        var lesson = await _lessonRepository.GetById(request.LessonId);
        var student = await _studentRepository.GetById(request.StudentId);
        
        if (lesson is null || student is null)
            throw new Exception("Invalid course or student");
        
        if (lesson.HasRequiredLesson())
        {   
            var requiredLesson = await _lessonRepository.GetById(course.RequiredCourseId);
            var studentLesson = await _studentRepository.GetStudentLesson(request.StudentId, request.LessonId);
            
            if (studentLesson.Status != "APPROVED")
                throw new Exception($"Required course {requiredLesson.Name} has to be approved in order to take this course.");
        }
        
        _studentRepository.AddStudentLesson(StudentLesson.RegisterStudentLesson(request.StudentId, request.CourseId, request.LessonId));
        await _unitOfWork.SaveChanges(cancellationToken);
    }
}