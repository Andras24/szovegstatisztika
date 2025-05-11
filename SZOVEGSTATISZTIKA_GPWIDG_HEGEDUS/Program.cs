using SZOVEGSTATISZTIKA_GPWIDG_HEGEDUS.BACKEND.Data;
using SZOVEGSTATISZTIKA_GPWIDG_HEGEDUS.Data;


var builder = WebApplication.CreateBuilder(args);

// Szolgáltatások regisztrálása
builder.Services.AddControllers();
builder.Services.AddTransient<ITextStatsService, TextStatsService>();

// CORS engedélyezése a frontend számára
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()         // vagy .WithOrigins("http://localhost:5500") ha csak ott fut a frontend
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors(); // CORS middleware

app.MapControllers(); // REST API végpontok engedélyezése

app.Run();
