using CryptoValiza.Exchanges.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCryptoValiza();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.Run();

public partial class Program { }