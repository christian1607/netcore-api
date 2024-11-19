namespace Domain.Students.Exceptions;

public class StudentAlreadyExistException : Exception
{

    public StudentAlreadyExistException(string message) : base(message)
    {
        
    }
}