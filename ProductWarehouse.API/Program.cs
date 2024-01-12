using ProductWarehouse.Infrastructure;
using ProductWarehouse.Application;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            // Add other Serilog configuration as needed
            .CreateLogger();


builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(setupAction =>
{
    var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);

    setupAction.IncludeXmlComments(xmlCommentsFullPath);
});


builder.Host.UseSerilog();

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
