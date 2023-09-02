using Microsoft.Extensions.DependencyInjection;

using ResearchLink.Core.Services.Impl;

namespace ResearchLink.Core.Extensions;

public static class HelperExtensions
{
    public static void PrintStackTrace(this Exception exception) => Console.WriteLine(exception.Message + exception.StackTrace);
    public static IServiceCollection AddResearchLinkCore(this IServiceCollection services, string? connectionString)
    {
        if(connectionString == null) throw new ArgumentNullException(nameof(connectionString));
        services.AddDbContext<DatabaseContext>(options => {
            options.UseSqlServer(connectionString, o =>
            {
                o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                o.MigrationsAssembly(typeof(DatabaseContext).Assembly.FullName);
            });
        }, ServiceLifetime.Transient);
        services.AddDomainServices();
        return services;
    }
    private static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        var service = typeof(ServiceAttribute);
        var types = typeof(ServiceAttribute).Assembly.GetTypes()
                           .Where(s => s.IsDefined(service, true)  && !s.IsInterface).Select(s => new
                           {
                               Service = s.GetInterface($"I{s.Name}"),
                               Implementation = s
                           });
        foreach (var type in types)
        {
            if (type.Service == null)
            {
                throw new ArgumentException($"No Interface of type: I{type.Implementation.Name} was found.");
            }
            services.AddScoped(type.Service, type.Implementation);
        }
        return services;
    }
}
