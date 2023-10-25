using Shamsheer.Service.Mappers;
using Shamsheer.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using Shamsheer.Messenger.Api.Extensions;
using Shamsheer.Messenger.Api.Middlewares;
using Shamsheer.Service.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ShamsheerDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCustomServices();
builder.Services.AddAutoMapper(typeof(MapperProfile));

var app = builder.Build();

// Getting full path of wwwroot
WebHostEnviroment.WebRootPath = Path.GetFullPath("wwwroot");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
