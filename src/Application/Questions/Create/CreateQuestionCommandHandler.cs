using Application.Meta;
using Domain.Questions;
using MediatR;

namespace Application.Questions.Create;

public class CreateQuestionCommandHandler: IRequestHandler<CreateQuestionCommand>
{
    private readonly IQuestionRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateQuestionCommandHandler(IQuestionRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public Task Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
    {
        var question = new Question(request.Score,request.Content,request.LessonId);
        _repository.Add(question);
        return _unitOfWork.SaveChanges(cancellationToken);
    }
}