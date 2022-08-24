using KeysetPagination.Domain.Common;
using MediatR;

namespace KeysetPagination.Application.Students.v1.Queries.GetStudentsWithPagination;

public class GetStudentsWithPaginationQuery : IRequest<PagedEntity<StudentDto>>
{
    public long? SearchAfter { get; set; }
    public int Limit { get; set; }
}