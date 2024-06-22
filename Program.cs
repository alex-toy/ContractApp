using Apollo.Models;
using RecrutementNet.DAL.Clients;
using RecrutementNet.DAL.Contracts;
using RecrutementNet.DAL.Generics;
using RecrutementNet.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IContractService, ContractService>();

builder.Services.AddScoped<IGenericDal<Contract>, ContractDal>();
builder.Services.AddScoped<IGenericDal<Client>, ClientDal>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
