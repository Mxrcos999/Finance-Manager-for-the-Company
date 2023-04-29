using FinanceManager.Application.DTOs.DtosCadastro;
using FinanceManager.Application.DTOs.DtosResponse;
using FinanceManager.Application.Interfaces;
using FinanceManager.Domain.Entidades;

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

    public async Task IncluirContaFinanceira(ContaFinanceiraCadastroRequest contaFinanceira, ApplicationUser user)
    {
        var categoria = new Categoria(contaFinanceira.Categoria.Nome, contaFinanceira.Categoria.Descricao, contaFinanceira.Categoria.Tipo.ToString());

        var conta = new ContaFinanceira(contaFinanceira.ValorLancamento, contaFinanceira.TipoLancamento, categoria);
        var userAtualizado = await AtualizaSaldoUsuario(user, conta);
        conta.UsuarioId = user.Id;

        await _contaFinanceiraRepository.IncluirContaFinanceiraAsync(conta, userAtualizado);
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
