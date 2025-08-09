
using TroSmart.Infrastructure.Persistence.Context;
using TroSmart.WebAPI.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TroSmartDbContext>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAppDI();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
