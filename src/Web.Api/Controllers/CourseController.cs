using Application.Courses.CreateCourse;
using Application.Courses.DeleteCourse;
using Application.Courses.GetCourse;
using Application.Courses.List;
using Application.Courses.UpdateCourse;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers;

[ApiController]
[Route("courses")]
public class CourseController : ControllerBase
{
    private readonly ILogger<CourseController> _logger;
    private readonly ISender _sender;

    public CourseController(ILogger<CourseController> logger, ISender sender)
    {
        _logger = logger;
        _sender = sender;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateCourse([FromBody] CreateCourseCommand command)
    { 
        await _sender.Send(command);
        return Ok();
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateCourse([FromBody] UpdateCourseCommand command)
    { 
        await _sender.Send(command);
        return Ok();
    }
    
    [HttpGet]
    public async Task<IActionResult> ListCourses()
    { 
        var query =  new ListCoursesQuery(); 
        
        var courses = await _sender.Send(query);
        return Ok(courses);
    }
    
    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetCourse(Guid id)
    { 
        var query = new GetCourseQuery(id);
        var lesson = await _sender.Send(query);
        return Ok(lesson);
    }
    
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteCourse(Guid id)
    { 
        var query = new DeleteCourseCommand(id);
        await _sender.Send(query);
        return Ok();
    }
}