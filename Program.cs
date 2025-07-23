using Microsoft.EntityFrameworkCore;
using Actors_RestAPI.Data;
using Actors_RestAPI.Helpers;
using DotNetEnv;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://0.0.0.0:" + (Environment.GetEnvironmentVariable("PORT") ?? "10000"));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Process connection string
var rawConnectionString = builder.Configuration.GetConnectionString("TheaterDB")
                            ?? throw new InvalidOperationException(Messages.Database.NoConnectionString);
var connectionString = ReplaceConnectionString.BuildConnectionString(rawConnectionString);

// Configuration of EFC with MySQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(10, 5, 0)))
);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.MapControllers();

app.UseCors("AllowAll");

app.Run();

