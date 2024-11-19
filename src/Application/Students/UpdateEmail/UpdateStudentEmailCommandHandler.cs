using Application.Meta;
using Domain.Students;
using Domain.Students.Exceptions;
using MediatR;

namespace Application.Students.UpdateEmail;

public class UpdateStudentEmailCommandHandler : IRequestHandler<UpdateStudentEmailCommand>
{
    
    private readonly IStudentRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateStudentEmailCommandHandler(IStudentRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateStudentEmailCommand request, CancellationToken cancellationToken)
    {
        var student =  _repository.GetByEmail(request.OldEmail);
        
        if (student is null)
            throw new StudentNotFoundException("Student not found with the given email.");
        
        student.UpdateEmail(request.NewEmail);
        
        _repository.Update(student);
        await _unitOfWork.SaveChanges(cancellationToken);
    }
}

