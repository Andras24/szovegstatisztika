using SZOVEGSTATISZTIKA_GPWIDG_HEGEDUS.BACKEND.Data;
using SZOVEGSTATISZTIKA_GPWIDG_HEGEDUS.Data;


var builder = WebApplication.CreateBuilder(args);

// Szolg�ltat�sok regisztr�l�sa
builder.Services.AddControllers();
builder.Services.AddTransient<ITextStatsService, TextStatsService>();

// CORS enged�lyez�se a frontend sz�m�ra
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

app.MapControllers(); // REST API v�gpontok enged�lyez�se

app.Run();
