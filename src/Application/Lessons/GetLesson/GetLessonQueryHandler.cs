using Domain.Lessons;
using Domain.Questions;
using MediatR;

namespace Application.Lessons.GetLesson;

public class GetLessonQueryHandler:IRequestHandler<GetLessonQuery,Lesson>
{
    private readonly ILessonRepository _repository;
    private readonly IQuestionRepository _questionRepository;

    public GetLessonQueryHandler(ILessonRepository repository, IQuestionRepository questionRepository)
    {
        _repository = repository;
        _questionRepository = questionRepository;
    }

    public async Task<Lesson> Handle(GetLessonQuery request, CancellationToken cancellationToken)
    {
        var lesson =  _repository.GetById(request.LessonId).Result;
        var questions =  await _questionRepository.ListByLesson(request.LessonId);
        lesson.AddQuestion(questions);
        return lesson;

    }
}