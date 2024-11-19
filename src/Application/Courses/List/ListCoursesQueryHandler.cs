using Domain.Courses;
using MediatR;

namespace Application.Courses.List;

public class ListCoursesQueryHandler:IRequestHandler<ListCoursesQuery, IEnumerable<Course>>
{
    private readonly ICourseRepository _repository;

    public ListCoursesQueryHandler(ICourseRepository repository)
    {
        _repository = repository;
    }
    public async Task<IEnumerable<Course>> Handle(ListCoursesQuery request, CancellationToken cancellationToken)
    {
        return await _repository.List();
    }
}