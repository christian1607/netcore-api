using MediatR;

namespace Application.Courses.DeleteCourse;

public record DeleteCourseCommand(Guid CourseId):IRequest;