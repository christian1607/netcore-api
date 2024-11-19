using MediatR;

namespace Application.Lessons.Create;

public record CreateLessonCommand(string Name, string Description, Guid CourseId, Guid RequiredLessonId) : IRequest;