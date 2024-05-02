using Microsoft.EntityFrameworkCore;
using RestApiExample.Web.Contract;
using RestApiExample.Web.Data;
using RestApiExample.Web.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("Ef_Postgres_Db")));

builder.Services.AddScoped<IProductService, ProductEfCoreService>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
