using Domain.Questions;
using MediatR;

namespace Application.Questions.GetQuestion;

public record GetQuestionQuery(Guid QuestionId):IRequest<Question>;