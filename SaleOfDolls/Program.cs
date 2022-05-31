using Microsoft.EntityFrameworkCore;
using SaleOfDolls.Data;
using SaleOfDolls.RepositoryUow;
using SaleOfDolls.Uow.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<DataContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<DataContext, DataContext>();
builder.Services.AddAutoMapper(typeof(Program));

//Repository
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IDollRepository, DollRepository>();
builder.Services.AddScoped<ISolicitationRepository, SolicitationRepository>();


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

