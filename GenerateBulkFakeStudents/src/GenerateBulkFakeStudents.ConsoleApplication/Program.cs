using CsvHelper;
using GenerateBulkFakeStudents.ConsoleApplication;
using System.Globalization;

static async Task WriteToCsv(int fakeDataCount)
{
    // Write the file in bin > debug > net6.0 folder
    using (StreamWriter writer = new("students.csv"))
    using (CsvWriter csv = new(writer, CultureInfo.InvariantCulture))
    {
        var fakeStudents = FakeStudentGenerator.GetFakes(fakeDataCount)
        .Select((s) => new
        {
            Id = s.Id,
            FirstName = s.FirstName,
            LastName = s.LastName,
            DateOfBirth = s.DateOfBirth.ToShortDateString(),
            Gender = (int)s.Gender,
            CreatedUtcTicks = s.CreatedUtcTicks,
            UpdatedUtcTicks = s.UpdatedUtcTicks,
            DeletedUtcTicks = s.DeletedUtcTicks
        });

        await csv.WriteRecordsAsync(fakeStudents);
    }
}

int fakeDataCount = 1000;

await WriteToCsv(fakeDataCount);

Console.WriteLine("Done");
