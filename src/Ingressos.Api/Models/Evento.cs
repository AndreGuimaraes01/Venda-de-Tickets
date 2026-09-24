namespace Ingressos.Api.Models;

public class Evento
{
    public int IdDaEmpresa { get; set;}
    public int IdDoEvento { get; set;}

    public string NomeDoEvento { get; set;} = string.Empty;

    public bool EstadoEvento { get; set;}    
    public int IngressosDisponiveis { get; private set; }

    public DateTime DataInicioUtc { get; set; } // Usar o horário universal e converter para o horário de brasília 

    public DateTime LimiteParaComprar { get; set;}

    public string LocalizacaoDoEvento { get; set;} = string.Empty;

    public bool PodeVender(DateTime agora)
    {

        if (!EstadoEvento)
        {
            return false; // evento fechado não vende
        }

        if (IngressosDisponiveis == 0)
        {
            return false;
        }

        if (agora > LimiteParaComprar)
        {
            return false;
        }

        return true;
    }


}

