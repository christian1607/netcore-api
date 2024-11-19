using Domain.Lessons;
using MediatR;

namespace Application.Lessons.ListLessons;

public record ListLessonsQuery(Guid CourseId): IRequest<IEnumerable<Lesson>>;