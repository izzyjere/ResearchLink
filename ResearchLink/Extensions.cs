global using ResearchLink.Core.Models;
global using BlazorBootstrap;

using System;
using Hangfire;
using ResearchLink.Core.Misc;

public static class Extensions
{
    internal static IApplicationBuilder InitFileStoreCleaner(this IApplicationBuilder app)
    {
        var scope = app.ApplicationServices.CreateScope();
        var service = scope.ServiceProvider.GetService<IFileSystemHelper>();
        if (service == null)
        {
            throw new Exception("Some services are missing: Name{IFileSystemHelper}");
        }
        RecurringJob.AddOrUpdate("FileStore_Cleaner", () => service.RunFileStoreCleanUp(), "*/5 * * * *");
        return app;
    }
    public static Author CreateAuthorFromUser(this UserProxy user)
    {   if (user.Profile == null) throw new ArgumentNullException(nameof(user.Profile));
        return new Author
        {
           FirstName = user.Profile.FirstName, 
           LastName = user.Profile.LastName,
           Initials = string.Concat(user.Profile.FirstName.ToUpper().AsSpan(0,1), user.Profile.LastName.ToUpper().AsSpan(0,1)),
           EmailAddress = user.Email,
           DateJoined = DateTime.Now,
           UserId = Guid.Parse(user.Id)
        };
    }
    public static Guid GetUserId(this ClaimsPrincipal claimsPrincipal) => Guid.Parse(claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier));
}