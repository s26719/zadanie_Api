var builder = WebApplication.CreateBuilder(args);

// Dodajemy usługi dla kontrolerów
builder.Services.AddControllers();

// Konfiguracja Swagger/OpenAPI do automatycznego generowania dokumentacji API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Konfiguracja pipelina HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Mapowanie kontrolerów do tras
app.MapControllers();

app.Run();