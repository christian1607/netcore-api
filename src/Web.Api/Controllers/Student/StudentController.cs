using Application.Students.Create;
using Application.Students.ListStudentCourseLessons;
using Application.Students.ListStudentCourses;
using Application.Students.ListStudents;
using Application.Students.TakeCourse;
using Application.Students.UpdateEmail;
using Application.Students.UpdatePhonenumber;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers.Student;

[ApiController]
[Route("student")]
public class StudentController : ControllerBase
{
    private readonly ILogger<StudentController> _logger;
    
    private readonly ISender _sender;

    public StudentController(ILogger<StudentController> logger, ISender sender)
    {
        _logger = logger;
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> CreateStudent([FromBody] CreateStudentCommand command)
    { 
        await _sender.Send(command); 
        return Ok();
    }
    
    [HttpPost]
    [Route("register-course")]
    public async Task<IActionResult> RegisterCourse([FromBody] TakeCourseCommand command)
    { 
        await _sender.Send(command); 
        return Ok();
    }
    
    [HttpPost]
    [Route("register-lesson")]
    public async Task<IActionResult> RegisterCourse([FromBody] TakeLessonCommand command)
    { 
        await _sender.Send(command); 
        return Ok();
    }


    [HttpPut]
    public async Task<IActionResult> UpdateStudentEmail([FromBody] UpdateStudentEmailCommand command)
    { 
        await _sender.Send(command); 
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> ListStudents()
    { 
        var students = await _sender.Send(new ListStudentsQuery()); 
        return Ok(students);
    }
 
    [HttpGet]
    [Route("{studentId}/courses")]
    public async Task<IActionResult> ListAvailableCourseByStudent(Guid studentId)
    {
        var query = new ListStudentCoursesQuery(studentId);
        var courses = await _sender.Send(query); 
        return Ok(courses);
    }

    [HttpGet]
    [Route("{studentId}/course/{courseId}/lessons")]
    public async Task<IActionResult> ListAvailableCourseLessonsByStudent(Guid studentId, Guid courseId)
    {
        var query = new ListStudentCourseLessonsQuery(studentId, courseId);
        var lessons = await _sender.Send(query); 
        return Ok(lessons);
    }
    
    
}