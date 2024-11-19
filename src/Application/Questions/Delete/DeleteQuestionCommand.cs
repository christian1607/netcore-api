using MediatR;

namespace Application.Questions.Delete;

public record DeleteQuestionCommand(Guid QuestionId):IRequest;