using Application.Meta;
using Domain.Courses;
using MediatR;

namespace Application.Courses.CreateCourse;

public class CreateCourseCommandHandler: IRequestHandler<CreateCourseCommand>
{
    private readonly ICourseRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCourseCommandHandler(ICourseRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public Task Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        var course = new Course(request.Name, request.Description);;
        if (request.RequiredCourseId != "")
        { 
            var requiredCourse = _repository.GetById(Guid.Parse(request.RequiredCourseId)).Result;
            if (requiredCourse is null)
                throw new Exception("Required course not foud");
            course.AddRequiredCourse(requiredCourse.Id);
        }
   
        _repository.Add(course);
        return _unitOfWork.SaveChanges(cancellationToken);
    }
}