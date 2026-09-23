using Microsoft.Extensions.ObjectPool;

namespace Ingressos.Api.Models;

public class Evento
{
    public int IdDaEmpresa { get; set; }

    public bool EstadoEvento { get; set;}    
    public int IngressosDisponiveis { get; private set; }

    public DateTime DataInicioUtc { get; set; } // Usar o horário universal e converter para o horário de brasília 

    public DateTime LimiteParaComprar { get; set;}

    public string LocalizacaoDoEvento { get; set;} = string.Empty;

    public string NomeEmpresaDoEvento { get; set;} = string.Empty;

    public bool PodeVender()
    {
        if (!EstadoEvento)
        {
            return false; // loja fechada: não vende
        }

        if (IngressosDisponiveis == 0)
        {
            return false;
        }

        return true;
    }


}

