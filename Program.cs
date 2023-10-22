using GameStoreBeGNorbi.Context;
using GameStoreBeGNorbi.Contracts;
using GameStoreBeGNorbi.Models;
using GameStoreBeGNorbi.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<GameStoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection")));
builder.Services.AddTransient<IRepository<VideoGame>, GenericRepository<VideoGame>>();
builder.Services.AddTransient<IRepository<User>, UserRepository>();
builder.Services.AddTransient<IRepository<UserVideoGame>, UserVideoGameRepository>();

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
