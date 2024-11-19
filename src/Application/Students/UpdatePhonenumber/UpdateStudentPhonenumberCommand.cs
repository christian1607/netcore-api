using MediatR;

namespace Application.Students.UpdatePhonenumber;

public record UpdateStudentPhonenumberCommand(
    Guid StudentId,
    string NewPhoneNumber) : IRequest;