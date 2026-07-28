using CourseRegistrationSystem.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Dependency Injection: ICourseService -> CourseService
builder.Services.AddScoped<ICourseService, CourseService>();

// Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "College Course Registration API",
        Version = "v1",
        Description = "A RESTful Web API for viewing, registering, updating and cancelling college courses."
    });
});

var app = builder.Build();

// Swagger UI is enabled in all environments so it's available whenever
// the project is run.
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "College Course Registration API v1");
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
