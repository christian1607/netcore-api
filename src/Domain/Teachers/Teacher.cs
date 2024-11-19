using Domain.Shared;

namespace Domain.Teachers;

public class Teacher : User
{
    private string FirstName { get; }
    private string LastName { get; }
    private string Email {get;}
    private string PhoneNumber {get;}
    

    private Teacher(
        string firstName, 
        string lastName,
        string email,
        string phoneNumber,
        string username,
        string password
    ) : base(username, password)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
    }

    public static Teacher CreateTeacher(
        string firstName, 
        string lastName,
        string email,
        string phoneNumber,
        string username,
        string password)
    {
        return new Teacher(firstName, lastName, email, phoneNumber, username, password);
    }
}