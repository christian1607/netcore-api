using Domain.Courses;
using Domain.Primitives;
using Domain.Shared;

namespace Domain.Students;

public class Student : Entity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email {get; set;}
    public string PhoneNumber { get; set; }

    public virtual IEnumerable<Course> Courses { get; set; }

    public Student()
    {
        
    }
    private Student(string firstName, string lastName, string email, string phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
    }

    public static Student CreateStudent(
        string firstName, 
        string lastName,
        string email,
        string phoneNumber,
        string username,
        string password)
    {
        return new Student(firstName, lastName, email, phoneNumber);
    }

    public void UpdatePhoneNumber(string phoneNumber)
    {
        PhoneNumber = phoneNumber;
    }
    
    public void UpdateEmail(string email)
    {
        Email = email;
    }
    
    
    
}