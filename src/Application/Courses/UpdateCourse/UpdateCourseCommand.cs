using MediatR;

namespace Application.Courses.UpdateCourse;

public record UpdateCourseCommand(Guid CourseId, string Name, string Description, Guid? RequiredCourseId):IRequest;