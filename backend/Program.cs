using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors();

app.MapGet("/cats", async (HttpClient client) =>
{
    var response = await client.GetStringAsync("https://cataas.com/api/cats");
    var cats = JsonSerializer.Deserialize<object>(response);
    return Results.Json(cats);
});

app.Run();