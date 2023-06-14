using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Newtonsoft.Json;
using Npgsql;
using Lab_4.Context;



var builder = WebApplication.CreateBuilder(args);
Context context = new Context();

context.MakeDb();
// Add services to the container.
builder.Services.AddControllers();
//builder.AddNewtonsoftJson();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
