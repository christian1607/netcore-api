using MediatR;

namespace Application.Students.Create;

public record CreateStudentCommand(
    string FirstName, 
    string LastName,
    string Email,
    string PhoneNumber,
    string Username,
    string Password) : IRequest;
