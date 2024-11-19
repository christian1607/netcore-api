using Domain.Courses;
using MediatR;

namespace Application.Courses.List;

public record ListCoursesQuery():IRequest<IEnumerable<Course>>;