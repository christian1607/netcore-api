using Application.Meta;
using Domain.Courses;
using MediatR;

namespace Application.Courses.DeleteCourse;

public class DeleteCourseCommandHandler:IRequestHandler<DeleteCourseCommand>
{
    private readonly ICourseRepository _courseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCourseCommandHandler(ICourseRepository courseRepository, IUnitOfWork unitOfWork)
    {
        _courseRepository = courseRepository;
        _unitOfWork = unitOfWork;
    }

    
    public Task Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
    {
        var course = _courseRepository.GetById(request.CourseId);
        
        if (course.Result == null)
            throw new ArgumentException("Course not found");
        
        _courseRepository.Delete(course.Result);

        return _unitOfWork.SaveChanges(cancellationToken);
    }
}