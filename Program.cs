using Microsoft.EntityFrameworkCore;
using Actors_RestAPI.Data;
using Actors_RestAPI.Helpers;
using DotNetEnv;
Env.Load();

var builder = WebApplication.CreateBuilder(args);

// Process connection string
var rawConnectionString = builder.Configuration.GetConnectionString("TheaterDB")
                            ?? throw new InvalidOperationException(Messages.Database.NoConnectionString);
var connectionString = ReplaceConnectionString.BuildConnectionString(rawConnectionString);

// Configuration of EFC with SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString)
);

builder.Services.AddControllers();
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
app.MapControllers();

app.Run();

