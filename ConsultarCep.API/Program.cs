using ConsultarCep.API.Handlers;
using ConsultarCep.API.Https;
using ConsultarCep.API.Persistence;
using ConsultarCep.API.Repositories;
using ConsultarCep.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ConsultaCepDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConsultaCep"))
);

builder.Services.AddHttpClient<IViaCepIntegrationService, ViaCepIntegrationService>(); 

builder.Services.AddScoped<ICepService, CepService>(); 
builder.Services.AddScoped<IConsultarCepRepository, ConsultarCepRepository>();

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
