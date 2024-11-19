using Domain.Questions;
using MediatR;

namespace Application.Questions.ListQuestions;

public record ListQuestionQuery(): IRequest<IEnumerable<Question>>;