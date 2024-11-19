using MediatR;

namespace Application.Questions.Create;

public record CreateQuestionCommand(string Content, int Score, Guid LessonId) : IRequest;