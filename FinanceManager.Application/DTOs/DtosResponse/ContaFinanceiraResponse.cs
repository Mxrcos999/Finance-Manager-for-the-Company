using FinanceManager.Domain;

namespace FinanceManager.Application.DTOs.DtosResponse;

public class ContaFinanceiraResponse
{
    public List<Entrada> Entrada { get; set;}
    public List<Saida> Saida { get; set;}

}
