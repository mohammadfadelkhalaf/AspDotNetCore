using Infrastructure.Context;
using Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(x
    => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

var Scopped = app.Services.CreateScope();
var services = Scopped.ServiceProvider;
var dbContext = services.GetRequiredService<DataContext>();
await StoreContextSeed.SeedAsync(dbContext);

//SeedDatabase();

//void SeedDatabase()
//{
//    using (var scope = app.Services.CreateScope())
//        try
//        {
//            var scopedContext = scope.ServiceProvider.GetRequiredService<DataContext>();
//            //   Seeder.Initialize(scopedContext);
//            StoreContextSeed.SeedAsync(scopedContext);
//        }
//        catch
//        {
//            throw;
//        }
//}

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
