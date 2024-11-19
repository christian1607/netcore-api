using MediatR;

namespace Application.Students.ListStudentCourses;

public record ListStudentCoursesQuery(Guid StudentId): IRequest<IEnumerable<StudentCourseDto>>;