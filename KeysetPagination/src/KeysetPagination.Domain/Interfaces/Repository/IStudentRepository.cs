using KeysetPagination.Domain.Models;

namespace KeysetPagination.Domain.Interfaces.Repository;

public interface IStudentRepository
{
    Task<IReadOnlyList<Student>> ListStudentsAsync(long? searchAfter, int limit, CancellationToken token = default);
}
