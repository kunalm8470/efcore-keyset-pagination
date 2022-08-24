namespace KeysetPagination.Domain.Common;

public abstract class BaseEntity<T> where T : struct
{
    public T Id { get; set; }
    public long CreatedUtcTicks { get; set; }
    public long? UpdatedUtcTicks { get; set; }
    public long? DeletedUtcTicks { get; set; }
}
