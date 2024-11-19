using MediatR;

namespace Application.Students.TakeCourse;

public record TakeCourseCommand(Guid StudentId, Guid CourseId): IRequest;