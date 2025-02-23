using ConsultarCep.API.Aplication;
using ConsultarCep.API.Handlers;
using ConsultarCep.API.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("ConsultaCep") ?? throw new InvalidOperationException("Connection string 'ConsultaCep' not found.");
builder.Services.AddDbContext<ConsultaCepDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddAplication();

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ConsultaCepHandlerException>();
});

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
app.UseAuthorization();
app.MapControllers();
app.Run();
