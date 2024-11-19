using MediatR;

namespace Application.Questions.Delete;

public class DeleteQuestionCommandHandler : IRequestHandler<DeleteQuestionCommand>
{
    public Task Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}