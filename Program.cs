using DotNetCRUD.Database;
using DotNetCRUD.IRepositories;
using DotNetCRUD.IServices;
using DotNetCRUD.Repositories;
using DotNetCRUD.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ABCDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("SampleCS")));
builder.Services.AddScoped<IStudent_Services, Student_Services>();
builder.Services.AddScoped<IStudent_Repo, StudentRepo>();

var app = builder.Build();

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
