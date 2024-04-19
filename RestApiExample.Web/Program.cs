using Microsoft.EntityFrameworkCore;
using RestApiExample.Web.EfCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EfDataContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("Ef_Postgres_Db")));
var app = builder.Build();

app.MapControllers();
app.Run();
