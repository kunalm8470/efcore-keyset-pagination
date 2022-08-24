using KeysetPagination.Domain.Interfaces.Services;
using Microsoft.AspNetCore.WebUtilities;

namespace KeysetPagination.Application.Common.Services;

public class UriService : IUriService
{
	private readonly string _baseUri;

    private readonly string _requestPath;

    public UriService(string baseUri, string requestPath)
	{
		_baseUri = baseUri;

        _requestPath = requestPath;
	}

    public Uri AddQueryParamsToPath(string route, string name, string value)
    {
        string modifiedUri = QueryHelpers.AddQueryString(string.Concat(_baseUri, route), name, value);

        return new Uri(modifiedUri);
    }

    public Uri AddQueryParamsToPath(string route, IDictionary<string, string> queryParams)
    {
        string modifiedUri = QueryHelpers.AddQueryString(string.Concat(_baseUri, route), queryParams);

        return new Uri (modifiedUri);
    }

    public string GetCurrentPath() => _requestPath;
}
