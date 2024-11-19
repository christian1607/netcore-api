using Application.Meta;
using Domain.Students;
using Domain.Students.Exceptions;
using MediatR;

namespace Application.Students.Create;

public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand>
{
    private readonly IStudentRepository _repository;
    
    private readonly IUnitOfWork _unitOfWork;

    
    public CreateStudentCommandHandler(IStudentRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        var student = Student.CreateStudent(
            request.FirstName,
            request.LastName,
            request.Email,
            request.PhoneNumber,
            request.Username,
            request.Password);
        
        _repository.Add(student);
        await _unitOfWork.SaveChanges(cancellationToken);
    }
}