global using ResearchLink.Core.Models;
using Hangfire;
using ResearchLink.Core.Misc;
using System.ComponentModel;
using Microsoft.JSInterop;
using ResearchLink.Core.Services;
using System.Text.Json;

public static class Extensions
{
    public static ValueTask RefreshWindow(this IJSRuntime jSRuntime) => jSRuntime.InvokeVoidAsync("window.location.reload");
    public static DateOnly DateOnly(this DateTime dateTime) => new DateOnly(dateTime.Year, dateTime.Month, dateTime.Day);
    internal static IApplicationBuilder InitFileStoreCleaner(this IApplicationBuilder app)
    {
        var scope = app.ApplicationServices.CreateScope();
        var service = scope.ServiceProvider.GetService<IFileSystemHelper>();
        if (service == null)
        {
            throw new Exception("Some services are missing: Name{IFileSystemHelper}");
        }
        RecurringJob.AddOrUpdate("FileStore_Cleaner", () => service.RunFileStoreCleanUp(), "0 * * * *");
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
    public static string GetFullName(this ClaimsPrincipal claimsPrincipal) => claimsPrincipal.FindFirstValue("FullName");
    //Read Abstract attribute from enum
    public static string GetDescription(this Enum value)
    {
        var fi = value.GetType().GetField(value.ToString());
        var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
        return attributes.Length > 0 ? attributes[0].Description : value.ToString();
    } 
    public static void SeedDistricts(this IApplicationBuilder app)
    {
        var scope = app.ApplicationServices.CreateScope();
        var service = scope.ServiceProvider.GetService<IDistrictService>();
        if (service == null)
        {
            throw new Exception("Some services are missing: Name{IDistrictService}");
        }
        if(service.Table.Any()) return;
        var filePath = Path.Combine(Environment.CurrentDirectory,"Files","Data", "districts.json");
        var json = File.ReadAllText(filePath);
        var districts = JsonSerializer.Deserialize<List<District>>(json);
        if (districts == null || !districts.Any()) return;
        service.Save(districts);
    }
}