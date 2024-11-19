using Domain.Students;
using MediatR;

namespace Application.Students.ListStudents;

public record ListStudentsQuery():IRequest<IEnumerable<Student>>;