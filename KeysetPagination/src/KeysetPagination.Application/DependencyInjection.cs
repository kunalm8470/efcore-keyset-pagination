using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using KeysetPagination.Application.Common.Services;
using KeysetPagination.Application.Students.v1.Queries.GetStudentsWithPagination;
using KeysetPagination.Domain.Interfaces.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KeysetPagination.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        // Register HttpContextAccessor
        services.AddHttpContextAccessor();

        services.AddSingleton<IUriService>((serviceProvider) =>
        {
            IHttpContextAccessor accessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();

            HttpRequest request = accessor.HttpContext.Request;

            string baseUri = $"{request.Scheme}://{request.Host.ToUriComponent()}";

            string requestPath = request.Path.Value;

            return new UriService(baseUri, requestPath);
        });

        // Register MediatR
        services.AddMediatR(typeof(GetStudentsWithPaginationQuery).Assembly);

        // Register AutoMapper
        services.AddAutoMapper(typeof(GetStudentsWithPaginationQueryProfile));

        services.AddTransient(provider => new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new GetStudentsWithPaginationQueryProfile());
        }).CreateMapper());

        // Register FluentValidation
        services
        .AddValidatorsFromAssemblyContaining<GetStudentsWithPaginationQueryValidator>()
        .AddFluentValidationAutoValidation((FluentValidationAutoValidationConfiguration configuration) =>
        {
            configuration.DisableDataAnnotationsValidation = true;
        });

        return services;
    }
}
