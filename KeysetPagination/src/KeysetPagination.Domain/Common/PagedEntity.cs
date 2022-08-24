namespace KeysetPagination.Domain.Common;

public record PagedEntity<T> where T : class
{
    public IEnumerable<T> Data { get; }

    public Paging Paging { get; }

    public PagedEntity(IEnumerable<T> data, string self, string next)
    {
        Data = data;

        Paging = new(self, next);
    }
}

public record Paging
{
    public string Self { get; }
    public string Next { get; }

    public Paging(string self, string next)
    {
        Self = self;

        Next = next;
    }
}