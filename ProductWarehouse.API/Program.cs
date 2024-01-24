using ProductWarehouse.Application.Extensions;
using Serilog;
using System.Reflection;
using ProductWarehouse.Infrastructure.Extensions;
using ProductWarehouse.API.Mapping;
using ProductWarehouse.Persistence.Extensions;
using ProductWarehouse.API.Infrastructure;
using ProductWarehouse.Persistence.EF.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddPersistence();
builder.Services.AddPersistenceEF(builder.Configuration);
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

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
    app.UseSwaggerUI(C => C.EnableFilter());
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseExceptionHandler();

app.UseAuthorization();

app.MapControllers();

app.Run();
