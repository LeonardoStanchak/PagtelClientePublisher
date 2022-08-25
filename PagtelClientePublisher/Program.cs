using Microsoft.EntityFrameworkCore;
using Pagtel.Repositories.Class;
using Pagtel.Repositories.Interfaces;
using Pagtel.Services.Class;
using Pagtel.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IClienteMensagemService, ClienteMensagemService>();
builder.Services.AddTransient<IClienteRepository, ClienteMensagemRepository>();
builder.Services.AddTransient<IProdutoMensagemService, ProdutoMensagemService>();
builder.Services.AddTransient<IProdutosRepository, ProdutoMensagemRepository>();
builder.Services.AddTransient<IPedidoMensagemService, PedidoMensagemService>();
builder.Services.AddTransient<IPedidoRepository, PedidoMensagemRepository>();
builder.Services.AddTransient<IEntregaMensagemService, EntregaMensagemService>();
builder.Services.AddTransient<IEntregaRepository, EntregaMensagemRepository>();

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
