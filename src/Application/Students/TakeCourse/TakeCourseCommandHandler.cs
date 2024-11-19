using Application.Meta;
using Domain.Courses;
using Domain.Students;
using MediatR;

namespace Application.Students.TakeCourse;

public class TakeCourseCommandHandler: IRequestHandler<TakeCourseCommand>
{
    private readonly ICourseRepository _courseRepository;
    private readonly IStudentRepository _studentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public TakeCourseCommandHandler(ICourseRepository courseRepository, IStudentRepository studentRepository, IUnitOfWork unitOfWork)
    {
        _courseRepository = courseRepository;
        _studentRepository = studentRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task Handle(TakeCourseCommand request, CancellationToken cancellationToken)
    {
        var course = await _courseRepository.GetById(request.CourseId);
        var student = await _studentRepository.GetById(request.StudentId);
        
        if (course is null || student is null)
            throw new Exception("Invalid course or student");
        
        if (course.HasRequiredCourse())
        {   
            var requiredCourse = await _courseRepository.GetById(course.RequiredCourseId);
            var studentCourse = await _studentRepository.GetStudentCourse(request.StudentId, course.RequiredCourseId);
            
            if (studentCourse.Status != "APPROVED")
                throw new Exception($"Required course {requiredCourse.Name} has to be approved in order to take this course.");
        }
        
        _studentRepository.AddStudentCourse(StudentCourse.RegisterStudent(request.StudentId, request.CourseId));
        await _unitOfWork.SaveChanges(cancellationToken);
    }
}