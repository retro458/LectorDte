using LectorDte.API.Configuration;
using Microsoft.OpenApi.Models;
using LectorDte.API.Data;
using DotNetEnv;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

// cargador env 
var rutaEnv = CargadorEnv.Cargar();
var builder = WebApplication.CreateBuilder(args);
Env.Load();
// conexion a sql server
var connectionString = $"Server={Env.GetString("DB_HOST")},{Env.GetString("DB_PORT")};" +
                       $"Database={Env.GetString("DB_NAME")};" +
                       $"User Id={Env.GetString("DB_USER")};" +
                       $"Password={Env.GetString("DB_PASSWORD")};" +
                       $"TrustServerCertificate=True;";

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(connectionString));

/*
aca ira el cors
*/
// configuracion de jwt via cookies
var jwtKey = Env.GetString("JWT_KEY");
var securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtKey));

builder.Services.AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
