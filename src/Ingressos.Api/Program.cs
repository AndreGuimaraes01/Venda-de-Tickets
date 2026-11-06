using Ingressos.Api.Models;

var builder = WebApplication.CreateBuilder(args);

var show = new Evento(100); // Isso manda a quantiade para o construtor, temporariamente
show.CancelarEvento();
show.LimiteParaComprar = DateTime.UtcNow.AddDays(30);
show.VenderIngresso(DateTime.UtcNow);
Console.WriteLine(show.IngressosDisponiveis); // Pega os dados da propriedade IngressosDisponiveis
Console.WriteLine(show.LimiteParaComprar);
Console.WriteLine(show.EventoAtivo);
Console.WriteLine(show.EventoCancelado);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

