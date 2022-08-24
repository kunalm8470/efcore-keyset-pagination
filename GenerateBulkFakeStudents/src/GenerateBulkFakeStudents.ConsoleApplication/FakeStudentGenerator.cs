using Bogus;
using GenerateBulkFakeStudents.ConsoleApplication.Enums;
using GenerateBulkFakeStudents.ConsoleApplication.Models;

namespace GenerateBulkFakeStudents.ConsoleApplication;

public static class FakeStudentGenerator
{
    public static IEnumerable<Student> GetFakes(int upperBound)
    {
        int studentId = 1;

        DateTime startRange = new(2000, 1, 1);
        DateTime endRange = new(2009, 12, 31);

        Faker<Student> students = new Faker<Student>()
        .RuleFor(s => s.Id, f => studentId++)
        .RuleFor(s => s.FirstName, f => f.Person.FirstName)
        .RuleFor(s => s.LastName, f => f.Person.LastName)
        .RuleFor(s => s.Gender, f => f.PickRandom<Gender>())
        .RuleFor(s => s.DateOfBirth, f => f.Date.Between(startRange, endRange).ToUniversalTime())
        .RuleFor(s => s.CreatedUtcTicks, f => DateTime.UtcNow.Ticks);

        return students.GenerateLazy(upperBound);
    }
}
