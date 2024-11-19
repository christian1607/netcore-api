using MediatR;

namespace Application.Students.UpdateEmail;

public record UpdateStudentEmailCommand(
    string OldEmail,
    string NewEmail) : IRequest;
