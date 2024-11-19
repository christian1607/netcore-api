using Domain.Lessons;
using MediatR;

namespace Application.Lessons.GetLesson;

public record GetLessonQuery(Guid LessonId):IRequest<Lesson>;