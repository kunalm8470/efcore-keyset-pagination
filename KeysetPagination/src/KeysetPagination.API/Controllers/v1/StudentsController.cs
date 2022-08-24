using KeysetPagination.Application.Students.v1.Queries.GetStudentsWithPagination;
using KeysetPagination.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KeysetPagination.API.Controllers.v1;

[Route("api/v1/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<PagedEntity<StudentDto>>> GetStudentsWithPagination([FromQuery] GetStudentsWithPaginationQuery query, CancellationToken token = default)
    {
        PagedEntity<StudentDto> students = await _mediator.Send(query, token);

        return Ok(students);
    }
}
