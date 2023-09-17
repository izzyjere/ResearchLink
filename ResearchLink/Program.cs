using Hangfire;

using ResearchLink;

using System.Drawing.Imaging;
using System.Drawing;
using System.Drawing.Drawing2D;
using CollegeApp.UI.RaveBindings;

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
builder.Services.AddPaymentServices(options =>
{
    options.AddPaymentOptions(PaymentOptions.MobileMoneyZambia); // can add multiple payment methods
    options.Title = "Research Link Payment";
   // options.LogoLocation = "assets/img/logo.png";
    options.Description = "Pay to access this resource";
    options.PublicKey = "FLWPUBK-da7f6e682771263e77ae9e8e6b0638c7-X";
});
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
app.MapFallbackToPage("/_Host");
app.MapBlazorHub();
app.MapGet("/generateAvatar/{initials}/{height}/{width}/{padding}", (string initials, int height, int width, int padding) =>
{

    // Calculate the actual size of the content area within the padded space
    int contentWidth = width - 2 * padding;
    int contentHeight = height - 2 * padding;

    using var bitmap = new Bitmap(width, height);
    using var graphics = Graphics.FromImage(bitmap);
    // Create a circular clipping path
    GraphicsPath path = new GraphicsPath();
    path.AddEllipse(0, 0, width, height);
    graphics.SetClip(path);

    // Background color
    var bgColor = ColorTranslator.FromHtml("#ECF0F1"); // You can change the color as needed
    graphics.FillRectangle(new SolidBrush(bgColor), 0, 0, width, height);

    // Text settings
    var font = new Font("Arial", Math.Min(contentWidth, contentHeight) / 2);
    var textColor = Color.Black; // Text color

    // Measure the size of the initials text
    var textSize = graphics.MeasureString(initials, font);

    // Calculate the position to center the initials within the padded area
    float x = padding + (contentWidth - textSize.Width) / 2;
    float y = padding + (contentHeight - textSize.Height) / 2;

    // Draw initials
    graphics.DrawString(initials, font, new SolidBrush(textColor), x, y);

    // Convert to MemoryStream
    using var memoryStream = new MemoryStream();
    bitmap.Save(memoryStream, ImageFormat.Png);

    // Return as a file stream result
    return Results.File(memoryStream.ToArray(), "image/png", $"{initials}_avatar.png");
});
app.UseHangfireDashboard();
app.InitFileStoreCleaner();
app.SeedDistricts();
app.Run();
