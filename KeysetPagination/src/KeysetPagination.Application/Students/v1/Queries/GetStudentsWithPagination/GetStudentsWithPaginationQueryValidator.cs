using FluentValidation;

namespace KeysetPagination.Application.Students.v1.Queries.GetStudentsWithPagination;

public class GetStudentsWithPaginationQueryValidator : AbstractValidator<GetStudentsWithPaginationQuery>
{
    public GetStudentsWithPaginationQueryValidator()
    {
        RuleFor(x => x.SearchAfter)
        .LessThanOrEqualTo(long.MaxValue)
        .WithMessage("Search after cannot be greater than long.MaxValue");

        RuleFor(x => x.Limit)
        .NotNull()
        .WithMessage("Limit cannot be empty.")
        .GreaterThanOrEqualTo(0)
        .WithMessage("Limit cannot be negative.")
        .LessThanOrEqualTo(10000)
        .WithMessage("Cannot request for more than 10000 items.");
    }
}
