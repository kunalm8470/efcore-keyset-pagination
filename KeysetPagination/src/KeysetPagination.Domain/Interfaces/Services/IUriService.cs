namespace KeysetPagination.Domain.Interfaces.Services;

public interface IUriService
{
    public string GetCurrentPath();

    public Uri AddQueryParamsToPath(string route, string name, string value);

    public Uri AddQueryParamsToPath(string route, IDictionary<string, string> queryParams);
}
