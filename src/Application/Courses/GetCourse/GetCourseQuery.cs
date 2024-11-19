using Domain.Courses;
using MediatR;

namespace Application.Courses.GetCourse;

public record GetCourseQuery(Guid CourseId):IRequest<Course>;