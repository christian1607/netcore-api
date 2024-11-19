using Domain.Students;
using MediatR;

namespace Application.Students.ListStudents;

public class ListStudentsQueryHandler:IRequestHandler<ListStudentsQuery,IEnumerable<Student>>
{
    private readonly IStudentRepository _repository;

    public ListStudentsQueryHandler(IStudentRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<IEnumerable<Student>> Handle(ListStudentsQuery request, CancellationToken cancellationToken)
    {
        return await _repository.ListStudents();
    }
}