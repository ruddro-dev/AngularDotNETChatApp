var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

builder.Services.AddCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.UseCors(options =>
    options.WithOrigins(
        new string[]
        {
            "http://localhost:3000", "http://localhost:4200"
        })
            .AllowAnyHeader()
            .AllowAnyMethod()
    );
app.UseAuthorization();

app.MapControllers();

app.Run();
