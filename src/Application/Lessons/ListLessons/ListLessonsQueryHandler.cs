using Domain.Lessons;
using MediatR;

namespace Application.Lessons.ListLessons;

public class ListLessonsQueryHandler: IRequestHandler<ListLessonsQuery,IEnumerable<Lesson>>
{
    private readonly ILessonRepository _repository;

    public ListLessonsQueryHandler(ILessonRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Lesson>> Handle(ListLessonsQuery request, CancellationToken cancellationToken)
    {
        if (request.CourseId == Guid.Empty)
            return await _repository.List();
        
        return  await _repository.ListByCourse(request.CourseId);
    }
}