using Application.Questions.Create;
using Application.Questions.GetQuestion;
using Application.Questions.ListQuestions;
using Application.Questions.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Controllers.Student;


namespace Web.Api.Controllers;

[ApiController]
[Route("question")]
public class QuestionController  : ControllerBase
{
    private readonly ILogger<StudentController> _logger;
    
    private readonly ISender _sender;

    public QuestionController(ILogger<StudentController> logger, ISender sender)
    {
        _logger = logger;
        _sender = sender;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateQuestion([FromBody] CreateQuestionCommand command)
    { 
        await _sender.Send(command);
        return Ok();
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateQuestion([FromBody] UpdateQuestionCommand command)
    { 
        await _sender.Send(command);
        return Ok();
    }
    
    [HttpGet]
    public async Task<IActionResult> ListQuestions()
    { 
        _logger.LogInformation("aad");

        var command = new ListQuestionQuery(); 
        var questions = await _sender.Send(command);
        return Ok(questions);
    }
    
    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetQuestion(Guid id)
    { 
        _logger.LogInformation("aad");

        var command = new GetQuestionQuery(QuestionId: id);
        var question = await _sender.Send(command);
        return Ok(question);
    }
}