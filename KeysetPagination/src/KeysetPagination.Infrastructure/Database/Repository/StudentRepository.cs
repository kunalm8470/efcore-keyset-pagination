using KeysetPagination.Domain.Interfaces.Repository;
using KeysetPagination.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace KeysetPagination.Infrastructure.Database.Repository;

public class StudentRepository : IStudentRepository
{
    private readonly SchoolDbContext _context;

    public StudentRepository(SchoolDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<Student>> ListStudentsAsync(long? searchAfter, int limit, CancellationToken token = default)
    {
        IQueryable<Student> query = _context.Students.AsQueryable();

        // Add search after to the query if provided
        if (searchAfter is not null)
        {
            query = query.Where(s => s.CreatedUtcTicks > searchAfter.Value);
        }

        return await query
                .OrderBy(s => s.CreatedUtcTicks)
                .Take(limit)
                .ToListAsync(token);
    }
}
