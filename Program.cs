using CoreStudentWebAPI.DataAccessLayer.DBContextModels;
using CoreStudentWebAPI.DataAccessLayer.Services;
using CoreStudentWebAPI.Filters;
using CoreStudentWebAPI.HttpClient;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using static CoreStudentWebAPI.Controllers.StudentController;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<StudentDbContext>(options =>
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        options.UseSqlServer(connectionString);
    });
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddControllers(options => {
    options.OutputFormatters.Add(new XmlSerializerOutputFormatter());
    options.InputFormatters.Add(new XmlSerializerInputFormatter(new Microsoft.AspNetCore.Mvc.MvcOptions()));
    options.Filters.Add(new LogFilterAttribute());
});
builder.Services.AddSingleton<IHttpClientService, HttpClientService>();
builder.Services.AddScoped<LogFilterAttribute>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
