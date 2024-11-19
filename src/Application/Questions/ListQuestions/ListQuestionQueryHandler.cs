using Application.Meta;
using Domain.Questions;
using MediatR;

namespace Application.Questions.ListQuestions;

public class ListQuestionQueryHandler : IRequestHandler<ListQuestionQuery,IEnumerable<Question>>
{
    private readonly IQuestionRepository _repository;
    
    private readonly IUnitOfWork _unitOfWork;

    public ListQuestionQueryHandler(IQuestionRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Question>> Handle(ListQuestionQuery request, CancellationToken cancellationToken)
    {
        return await _repository.List();
    }
}