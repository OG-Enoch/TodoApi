using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TodoApi.Data;
using TodoApi.Models;
using TodoApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ToDoDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("ToDoListDB")));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(IRepository<>), typeof(ToDoItemRepository<>)); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

app.Run();
