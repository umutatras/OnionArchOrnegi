using OnionArchOrnegi.Application;
using OnionArchOrnegi.Infrastructure;
using OnionArchOrnegi.Persistence;
using OnionArchOrnegi.WebAPI;
using Serilog;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicaton();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddWebApi(builder.Configuration, builder.Environment);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Serilog konfigürasyonu
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug() // Log seviyesini ayarladýk
    .WriteTo.Console()    // Konsola logla
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day) // Dosyaya logla
    .CreateLogger();

// Serilog'u kullanmasý için builder.Host'u ayarla
builder.Host.UseSerilog();
var app = builder.Build();
app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
