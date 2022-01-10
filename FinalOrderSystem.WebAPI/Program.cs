using FinalOrderSystem.Adapter;
using FinalOrderSystem.WebAPI.Core.Menu;
using System.Data;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Configuration.AddJsonFile("appsettings.json", false, true);


builder.Services.AddScoped<IDbConnection, SqlConnection>(serviceProvider => {
    SqlConnection conn = new SqlConnection();
    conn.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    return conn;
});

string dbConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddScoped<IMenuRepository, MenuRepository>(/*x => new MenuRepository(dbConnectionString)*/);
builder.Services.AddScoped<IMenuModule, MenuModule>();

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