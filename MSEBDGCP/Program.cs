using MSEBDGCP.Components;
using MSEBDGCP.Services;
using Radzen;
using Shared;
using Shared.CampsClient.CommonForms;
using Shared.CampsClient.Master;
using Shared.CampsClient.Transactions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddControllers();

builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();
builder.Services.AddScoped<ThemeService>();
builder.Services.AddScoped<ServiceClient>();
builder.Services.AddScoped<AddressService>();
builder.Services.AddScoped<BloodGroupService>();
builder.Services.AddScoped<CampTypeService>();
builder.Services.AddScoped<CampaignVolunteerService>();
builder.Services.AddScoped<VolunteerProfileService>();
builder.Services.AddScoped<CountryService>();
builder.Services.AddScoped<FemaleQuestionService>();
builder.Services.AddScoped<GenderService>();
builder.Services.AddScoped<GneralHealthQuestionService>();
builder.Services.AddScoped<MedicalConditionService>();
builder.Services.AddScoped<RiskFactorService>();
builder.Services.AddScoped<SeCommitteeService>();
builder.Services.AddScoped<CampDetailsService>();
builder.Services.AddScoped<QuestionMasterService>();
builder.Services.AddScoped<BeneficiaryService>();
builder.Services.AddScoped<DashboardService>();
//builder.Services.AddSingleton<GrpReg>();

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

app.MapControllers();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
