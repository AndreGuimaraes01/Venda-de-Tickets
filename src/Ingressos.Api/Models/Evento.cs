using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Ingressos.Api.Models;

public class Evento
{
    public int IdDaEmpresa { get; set;}
    public int IdDoEvento { get; set;}

    public string NomeDoEvento { get; set;} = string.Empty;

    public bool EventoAtivo { get; private set;}    
    public int IngressosDisponiveis { get; private set; }

    public DateTime DataInicioUtc { get; set; } // Usar o horário universal e converter para o horário de brasília 

    public DateTime LimiteParaComprar { get; set;}

    public string LocalizacaoDoEvento { get; set;} = string.Empty;

    public bool EventoAcabou { get; set;}

    public bool EventoCancelado { get; private set;}

    public Evento(int QuantidadeInicial) // As quantiades iniciais de ingressos, recebe o numero que chega do new
    {                                    //isso é um construtor(Evento)   
        IngressosDisponiveis = QuantidadeInicial;
        EventoAtivo = true;
    }
    
    public bool VenderIngresso(DateTime agora)
    {
        if (PodeVender (agora))
        {
            IngressosDisponiveis = IngressosDisponiveis - 1;

            return true;
        }

        else
        {
            return false;
        }
    }


    public bool PodeVender(DateTime agora)
    {

        if (!EventoAtivo)
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

    public void CancelarEvento()
    {
        EventoAtivo = false;
        EventoCancelado = true;
    }

}

