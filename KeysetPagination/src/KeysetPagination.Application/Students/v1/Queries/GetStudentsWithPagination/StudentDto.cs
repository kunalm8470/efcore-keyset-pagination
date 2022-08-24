namespace KeysetPagination.Application.Students.v1.Queries.GetStudentsWithPagination;

public record StudentDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DateOfBirth { get; set; }
    public string Gender { get; set; }
    public long CreatedAt { get; set; }
    public long? UpdatedAt { get; set; }
    public long? DeletedAt { get; set; }
}
