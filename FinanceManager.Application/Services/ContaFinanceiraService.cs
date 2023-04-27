using FinanceManager.Application.DTOs.DtosCadastro;
using FinanceManager.Application.DTOs.DtosResponse;
using FinanceManager.Application.Interfaces;
using FinanceManager.Domain;
using FinanceManager.Domain.Entidades;
using System.Linq.Expressions;

namespace FinanceManager.Application.Services;

public class ContaFinanceiraService : IContaFinanceiraService
{
    private readonly IContaFinanceiraRepository _contaFinanceiraRepository;

    public ContaFinanceiraService(IContaFinanceiraRepository contaFinanceiraRepository)
    {
        _contaFinanceiraRepository = contaFinanceiraRepository;
    }
    public async Task<IEnumerable<ContaFinanceiraResponse>> ObterContasFinanceiras(string idUser)
    {
        return await _contaFinanceiraRepository.ObtemContaFinanceira(idUser);
    }

    public async Task IncluirContaFinanceira(ContaFinanceiraCadastroRequest contaFinanceira,string idConta)
    {
        var categoria = new Categoria(contaFinanceira.Categoria.Nome, contaFinanceira.Categoria.Descricao, contaFinanceira.Categoria.Tipo.ToString());
        var conta = new ContaFinanceira(0, contaFinanceira.ValorLancamento, contaFinanceira.TipoLancamento, categoria);
        conta.UsuarioId = idConta; 
        await _contaFinanceiraRepository.IncluirContaFinanceiraAsync(conta);
    }

    //private async Task<bool> VerificaCategoria(int idCategoria)
    //{

    //}
}
