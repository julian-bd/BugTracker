using Domain.DataStorage;
using Domain.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(o =>
{
    o.AddDefaultPolicy(p =>
    {
        p.AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod();
    });
}); 

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddSingleton<IRepository<Bug>, InMemoryRepository<Bug>>();
    builder.Services.AddSingleton<IRepository<User>, InMemoryRepository<User>>();
}
else
{
    builder.Services.AddSingleton<IRepository<Bug>, MongoRepository<Bug>>();
    builder.Services.AddSingleton<IRepository<User>, MongoRepository<User>>();
}


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();


app.MapControllers();

app.UseCors();

app.Run();