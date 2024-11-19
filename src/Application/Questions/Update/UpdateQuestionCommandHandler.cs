using Application.Meta;
using Domain.Questions;
using MediatR;

namespace Application.Questions.Update;

public class UpdateQuestionCommandHandler : IRequestHandler<UpdateQuestionCommand>
{
    
    private readonly IQuestionRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateQuestionCommandHandler(IQuestionRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
    {
        var question = await _repository.GetById(request.Id);

        if (question is null)
            throw new Exception("Question not found");
        
        question.Score = request.Score;
        question.Content = request.Content;
        
        _repository.Update(question);
        await _unitOfWork.SaveChanges(cancellationToken);
    }
}