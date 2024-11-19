using Application.Students.ListStudentCourses;
using MediatR;

namespace Application.Students.ListStudentCourseLessons;

public record ListStudentCourseLessonsQuery(Guid StudentId, Guid CourseId): IRequest<IEnumerable<StudentCourseLessonDto>>;