using FinanceManager.Application.DTOs.DtosCadastro;
using FinanceManager.Application.DTOs.DtosResponse;
using FinanceManager.Application.Interfaces;
using FinanceManager.Domain.Entidades;
using System.Data;

namespace FinanceManager.Application.Services;

public class ContaFinanceiraService : IContaFinanceiraService
{
    private readonly IContaFinanceiraRepository _contaFinanceiraRepository;
    private readonly IContaFinanceiraFactory _contaFinanceiraFactory;

    public ContaFinanceiraService(IContaFinanceiraRepository contaFinanceiraRepository, IContaFinanceiraFactory contaFinanceiraFactory)
    {
        _contaFinanceiraRepository = contaFinanceiraRepository;
        _contaFinanceiraFactory = contaFinanceiraFactory;
    }
    public async Task<IEnumerable<ContaFinanceiraResponse>> ObterContasFinanceiras(string idUser)
    {
        return await _contaFinanceiraRepository.ObtemContaFinanceira(idUser);
    }

    public async Task IncluirContaFinanceira(ContaFinanceiraCadastroRequest contaFinanceira, ApplicationUser user)
    {
        var categoriaObtida = await _contaFinanceiraRepository.ObterCategoriaByNomeAsync(contaFinanceira.CategoriaId);
        if (categoriaObtida is null)
            throw new DataException("Não foi encontrada nenhuma categoria com o id informado", new Exception("Não foi encontrada nenhuma categoria com o id informado"));
        var contaFinanceriaInserir = _contaFinanceiraFactory.Create(contaFinanceira, categoriaObtida);
        contaFinanceriaInserir.UsuarioId = user.Id;
        var userAtualizado = await AtualizaSaldoUsuario(user, contaFinanceriaInserir);
        await _contaFinanceiraRepository.IncluirContaFinanceiraAsync(contaFinanceriaInserir, userAtualizado);
    }

    private async Task<ApplicationUser> AtualizaSaldoUsuario(ApplicationUser user, ContaFinanceira contaFinanceira)
    {
        if (contaFinanceira.TipoLancamento == ContaFinanceira.TiposLancamento.Credito)
        {
            user.Saldo += contaFinanceira.ValorLancamento;
            return user;
        }
        else
        {
            user.Saldo -= contaFinanceira.ValorLancamento;
            return user;
        }
    }
}



