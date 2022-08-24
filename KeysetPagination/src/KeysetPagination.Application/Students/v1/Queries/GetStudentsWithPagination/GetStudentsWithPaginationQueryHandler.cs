using AutoMapper;
using KeysetPagination.Domain.Common;
using KeysetPagination.Domain.Interfaces.Repository;
using KeysetPagination.Domain.Interfaces.Services;
using KeysetPagination.Domain.Models;
using MediatR;

namespace KeysetPagination.Application.Students.v1.Queries.GetStudentsWithPagination;

public class GetStudentsWithPaginationQueryHandler : IRequestHandler<GetStudentsWithPaginationQuery, PagedEntity<StudentDto>>
{
    private readonly IStudentRepository _studentRepository;

    private readonly IUriService _uriService;

    private readonly IMapper _mapper;

    public GetStudentsWithPaginationQueryHandler(
        IStudentRepository studentRepository, 
        IUriService uriService,
        IMapper mapper
    )
    {
        _studentRepository = studentRepository;

        _uriService = uriService;

        _mapper = mapper;
    }

    public async Task<PagedEntity<StudentDto>> Handle(GetStudentsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        IReadOnlyList<Student> students = await _studentRepository.ListStudentsAsync(request.SearchAfter, request.Limit, cancellationToken);

        string currentRoute = _uriService.GetCurrentPath();

        Dictionary<string, string> selfUrlQueryParams = new()
        {
            ["searchAfter"] = request.SearchAfter?.ToString(),
            ["limit"] = request.Limit.ToString()
        };

        string selfUrl = _uriService.AddQueryParamsToPath(currentRoute, selfUrlQueryParams).AbsoluteUri;

        Dictionary<string, string> nextUrlQueryParams = new()
        {
            ["searchAfter"] = students[^1].CreatedUtcTicks.ToString(),
            ["limit"] = request.Limit.ToString()
        };

        string nextUrl = _uriService.AddQueryParamsToPath(currentRoute, nextUrlQueryParams).AbsoluteUri;

        IEnumerable<StudentDto> mappedStudents = students.Select(_mapper.Map<StudentDto>);

        return new PagedEntity<StudentDto>(mappedStudents, selfUrl, nextUrl);
    }
}
