using MediatR;

namespace Application.Courses.CreateCourse;

public record CreateCourseCommand(string Name, string Description, string RequiredCourseId=""):IRequest;