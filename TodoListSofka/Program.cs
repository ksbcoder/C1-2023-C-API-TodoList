using Microsoft.EntityFrameworkCore;
using TodoListSofka.Data;
using AutoMapper;
using TodoListSofka.DTO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var stringConnection = builder.Configuration.GetConnectionString("ToDoListApiConnectionString");
builder.Services.AddDbContext<DatabaseFirstBloggingContext>(options => options.UseSqlServer(stringConnection));

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
