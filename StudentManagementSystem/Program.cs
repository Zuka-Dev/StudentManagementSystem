using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Services.Data;
using StudentManagementSystem.Services.Interfaces;
using StudentManagementSystem.Services.Repositories;

var builder = WebApplication.CreateBuilder(args);
var MyAllowAllOrigins = "_myAllowAllOrigins";
// Add services to the container.
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();

//Allow All Cors Origins
builder.Services.AddCors(option =>
{
    option.AddPolicy(name: MyAllowAllOrigins, policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
//Setting DB  Context
builder.Services.AddDbContext<StudentManagementDbContext>
    (option => option.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
        )
    );
//Setting Up Controllers
builder.Services.AddControllers();
//Dependency Injection
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

app.UseHttpsRedirection();

app.UseCors(MyAllowAllOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
