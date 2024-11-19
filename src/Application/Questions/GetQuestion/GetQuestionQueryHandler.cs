using Application.Meta;
using Domain.Questions;
using MediatR;

namespace Application.Questions.GetQuestion;

public class GetQuestionQueryHandler : IRequestHandler<GetQuestionQuery,Question>
{
    private readonly IQuestionRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public GetQuestionQueryHandler(IQuestionRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Question> Handle(GetQuestionQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetById(request.QuestionId);
    }
}