using KSProject.Models;
using KSProject.Patterns;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(new StorageConfig("", ""));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.MapGet("/{id}", async (Guid id) => 
{
    var config = app.Services.GetService<StorageConfig>();
    IRepository storage = Factory.Create(config);
    return await storage.Get<Person>(id); //TODO ¿eby przesta³o siê œwieciæ
});

app.Run();
