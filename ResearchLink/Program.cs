using Hangfire;

using ResearchLink;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Default");
// Add services to the container.
builder.Services.AddResearchLinkCore(connectionString);
builder.Services.AddSimpleAuthentication(options =>
{
    options.UseSqlServer(connectionString);
});
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazorBootstrap();
builder.Services.AddHangfire(t =>
{
    t.UseSqlServerStorage(connectionString);
});
builder.Services.AddHangfireServer();
builder.Services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();
builder.Services.AddScoped<IUserClaimsPrincipalFactory<User>, ClaimsPrincipalFactory>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSimpleAuthentication();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.UseHangfireDashboard();
app.InitFileStoreCleaner();
app.SeedDistricts();
app.Run();
