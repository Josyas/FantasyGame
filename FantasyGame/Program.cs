using FantasyGame.Data;
using FantasyGame.DTO;
using FantasyGame.Repositories;
using FantasyGame.Repositories.Interfaces;
using FantasyGame.Services;
using FantasyGame.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ITimeService, TimeService>();
builder.Services.AddScoped<ITimeRepositorio, TimeRepositorio>();
builder.Services.AddScoped<ICampeonatoService, CampeonatoService>();
builder.Services.AddScoped<ICampeonatoRepositorio, CampeonatoRepositorio>();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddAutoMapper(typeof(EntitiesToDTOProfile));

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
