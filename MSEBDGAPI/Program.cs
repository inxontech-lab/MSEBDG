using MSEBDGAPI.Services.Camps.Common;
using MSEBDGAPI.Services.Camps.Master;
using MSEBDGAPI.Services.Camps.Transactions;
using DataAccess.CampsRepo;
using Domain.CampsModels.DBModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<MsebdgcampsContext>();
builder.Services.AddScoped<IGroupingCampContextDataRepo, GroupingCampContextDataRepo>();
builder.Services.AddScoped<IGroupingCampDataRepo, GroupingCampDataRepo>();
builder.Services.AddScoped<CountryService>();
builder.Services.AddScoped<SeCommitteeService>();
builder.Services.AddScoped<GenderService>();
builder.Services.AddScoped<BloodGroupService>();
builder.Services.AddScoped<CampTypeService>();
builder.Services.AddScoped<AddressService>();
builder.Services.AddScoped<CampDetailsService>();
builder.Services.AddScoped<GeneralHealthQuestService>();
builder.Services.AddScoped<MedicalConditionService>();
builder.Services.AddScoped<RiskFactorService>();
builder.Services.AddScoped<FemaleDonorQuestService>();
builder.Services.AddScoped<QuestionMasterService>();
builder.Services.AddScoped<BeneficiaryService>();
builder.Services.AddScoped<GroupingDashboardService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});
builder.Services.AddControllers();

var app = builder.Build();

// Use CORS
app.UseCors("AllowAll");
app.MapControllers();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
