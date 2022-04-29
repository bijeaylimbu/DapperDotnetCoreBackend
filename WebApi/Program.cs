using TaxSlabCalculator.Application.Interfaces;
using TaxSlabCalculator.Extension;
using TaxSlabCalculator.Infrastructure.Persistance;
using TaxSlabCalculator.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<TaxSlabDbContext>();
builder.Services.AddScoped<ITaxRepository, TaxRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
app.UseAuthorization();
app.MapControllers(); 
app.MigrateDatabase();
app.Run();
