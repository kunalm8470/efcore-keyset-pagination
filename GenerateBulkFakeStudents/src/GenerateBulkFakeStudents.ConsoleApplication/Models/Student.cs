using GenerateBulkFakeStudents.ConsoleApplication.Enums;

namespace GenerateBulkFakeStudents.ConsoleApplication.Models;

public class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Gender Gender { get; set; }
    public long CreatedUtcTicks { get; set; }
    public long? UpdatedUtcTicks { get; set; }
    public long? DeletedUtcTicks { get; set; }
}