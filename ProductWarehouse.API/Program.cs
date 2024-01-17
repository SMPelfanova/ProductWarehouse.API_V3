using ProductWarehouse.Application.Extensions;
using Serilog;
using System.Reflection;
using ProductWarehouse.Infrastructure.Extensions;
using ProductWarehouse.API.Mapping;
using ProductWarehouse.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.DependencyRegistration();
builder.Services.DependencyRegistration(builder.Configuration);
builder.Services.DependencyRegistrationPersistence();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(setupAction =>
{
    var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);

    setupAction.IncludeXmlComments(xmlCommentsFullPath);
});


builder.Host.UseSerilog((context, loggerConfiguration) =>
{
    loggerConfiguration
        .ReadFrom.Configuration(context.Configuration)
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day); // Specify the file path
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(C=>C.EnableFilter());
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
