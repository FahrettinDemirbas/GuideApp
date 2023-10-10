using Guide.Service.Services;
using Guide.Service.Settings;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IUserProfileService, UserProfileService>();
builder.Services.AddScoped<IUserContactService, UserContactService>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
builder.Services.AddSingleton<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Guide.Service", Version = "v1" });
});
builder.Services.AddControllers();
var app = builder.Build();

//Test Insert

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    var keyValueService = serviceProvider.GetRequiredService<IUserProfileService>();
    if (!keyValueService.GetAllAsync().Result.Any())
    {
        keyValueService.CreateAsync(new Guide.Service.Dtos.UserProfileCreateDto() { Company = "Demirbaþ", FirstName = "F", LastName = "D" });
    }
}


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(o =>
    {
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Guide.Service v1"));
    });
}

app.Run();
