using KeysetPagination.Domain.Common;
using KeysetPagination.Domain.Enums;

namespace KeysetPagination.Domain.Models;

public class Student : BaseEntity<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Gender Gender { get; set; }
}