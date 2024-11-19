using MediatR;

namespace Application.Students.TakeCourse;

public record TakeLessonCommand(Guid StudentId, Guid CourseId, Guid LessonId): IRequest;