using MediatR;

namespace Application.Questions.Update;

public record UpdateQuestionCommand(
    Guid Id,
    string Content,
    int Score): IRequest;