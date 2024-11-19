using Application.Meta;
using Domain.Students;
using Domain.Students.Exceptions;
using MediatR;

namespace Application.Students.UpdatePhonenumber;

public class UpdateStudentPhonenumberCommandHandler : IRequestHandler<UpdateStudentPhonenumberCommand>
{
    private readonly IStudentRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateStudentPhonenumberCommandHandler(IStudentRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateStudentPhonenumberCommand request, CancellationToken cancellationToken)
    {
        var student = await _repository.GetById(request.StudentId);
        
        if (student is null)
            throw new StudentNotFoundException("Student not found");
        
        student.UpdatePhoneNumber(request.NewPhoneNumber);
        
        await _unitOfWork.SaveChanges(cancellationToken);
    }
}