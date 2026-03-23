using MSEBDGWebsite.Components;
using QRCoder;
using Shared;
using Shared.CampsClient.Master;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddScoped<ServiceClient>();
builder.Services.AddScoped<CampaignVolunteerService>();
builder.Services.AddScoped<CampaignVolunteerProfileService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapGet("/qr/volunteers/{volunteerToken}", (HttpContext httpContext, IConfiguration configuration, string volunteerToken) =>
{
    if (string.IsNullOrWhiteSpace(volunteerToken))
    {
        return Results.BadRequest();
    }

    var publicBaseAddress = configuration["PublicUrls:VolunteerWebsiteBaseAddress"]?.TrimEnd('/');
    var detailsUrl = string.IsNullOrWhiteSpace(publicBaseAddress)
        ? $"{httpContext.Request.Scheme}://{httpContext.Request.Host}/volunteers/{Uri.EscapeDataString(volunteerToken)}"
        : $"{publicBaseAddress}/volunteers/{Uri.EscapeDataString(volunteerToken)}";

    using var generator = new QRCodeGenerator();
    using var data = generator.CreateQrCode(detailsUrl, QRCodeGenerator.ECCLevel.Q);
    var qrCode = new PngByteQRCode(data);
    var bytes = qrCode.GetGraphic(20);

    return Results.File(bytes, "image/png");
});

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
