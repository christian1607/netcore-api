using Application.Meta;
using Domain.Lessons;
using MediatR;

namespace Application.Lessons.Create;

public class CreateLessonCommandHandler : IRequestHandler<CreateLessonCommand>
{
    private readonly ILessonRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateLessonCommandHandler(ILessonRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    
    public Task Handle(CreateLessonCommand request, CancellationToken cancellationToken)
    {
        var lesson = new Lesson(request.Name, request.Description,request.CourseId);
        if (request.RequiredLessonId != Guid.Empty)
            lesson.AddRequiredLesson(request.RequiredLessonId);
        _repository.Add(lesson);
        return _unitOfWork.SaveChanges(cancellationToken);
    }
}