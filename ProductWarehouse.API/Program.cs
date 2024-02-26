using Newtonsoft.Json.Serialization;
using ProductWarehouse.API.Infrastructure;
using ProductWarehouse.API.Mapping;
using ProductWarehouse.Application.Extensions;
using ProductWarehouse.Infrastructure.Extensions;
using ProductWarehouse.Persistence.PostgreSQL.Extensions;
using ProductWarehouse.Persistence.Extensions;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
	options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
	options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
});
builder.Services.AddHttpClient();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddPersistence();
builder.Services.AddPersistencePostgreSql(builder.Configuration);
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
}).AddSwaggerGenNewtonsoftSupport();

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