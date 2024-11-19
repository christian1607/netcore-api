using Application.Lessons.Create;
using Application.Lessons.GetLesson;
using Application.Lessons.ListLessons;
using Application.Lessons.Update;
using Application.Questions.Create;
using Application.Questions.GetQuestion;
using Application.Questions.ListQuestions;
using Application.Questions.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Controllers.Student;


namespace Web.Api.Controllers;

[ApiController]
[Route("lessons")]
public class LessonController  : ControllerBase
{
    private readonly ILogger<StudentController> _logger;
    private readonly ISender _sender;

    public LessonController(ILogger<StudentController> logger, ISender sender)
    {
        _logger = logger;
        _sender = sender;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateLesson([FromBody] CreateLessonCommand command)
    { 
        await _sender.Send(command);
        return Ok();
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateLesson([FromBody] UpdateLessonCommand command)
    { 
        await _sender.Send(command);
        return Ok();
    }
    
    [HttpGet]
    public async Task<IActionResult> ListLessonsByCourse([FromQuery(Name = "courseId")] Guid courseId)
    { 
        var query =  courseId != Guid.Empty ?  new ListLessonsQuery(CourseId:courseId): new ListLessonsQuery(Guid.Empty); 
        
        var lessons = await _sender.Send(query);
        return Ok(lessons);
    }
    
    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetLesson(Guid id)
    { 
        var query = new GetLessonQuery(LessonId: id);
        var lesson = await _sender.Send(query);
        return Ok(lesson);
    }
}
