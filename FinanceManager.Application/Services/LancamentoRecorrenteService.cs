using FinanceManager.Application.DTOs.DtosCadastro;
using FinanceManager.Application.Interfaces;
using FinanceManager.Domain.Factory;

namespace FinanceManager.Application.Services;

public class LancamentoRecorrenteService : ILancamentoRecorrenteService
{
    private readonly ILancamentoRecorrenteRep _lancamentoRecorrenteRep;
    private readonly IContaFinanceiraRepository _contaFinanceiraRepository;

    public LancamentoRecorrenteService(ILancamentoRecorrenteRep lancamentoRecorrenteRep, IContaFinanceiraRepository contaFinanceiraRepository)
    {
        _lancamentoRecorrenteRep = lancamentoRecorrenteRep;
        _contaFinanceiraRepository = contaFinanceiraRepository;
    }

    public async Task IncluirASync(LancamentoRecorrenteCadastroRequest lancamento)
    {
        var categoriaObtida = await _contaFinanceiraRepository.ObterCategoriaByIdAsync(lancamento.CategoriaId);
        if (categoriaObtida is null)
            throw new Exception("Não foi encontrado nenhuma categoria com o id informado.", new Exception("Não foi encontrado nenhuma categoria com o id informado."));

        var lancamentoRecorrente = LancamentoRecorrenteFactory
             .Create
             (lancamento.ValorLancamento,
             lancamento.DataPrevistaLancamento,
             lancamento.TipoLancamento,
             categoriaObtida);

        var contaFinanceira = ContaFinanceiraFactory
            .Create
            (lancamentoRecorrente.ValorLancamento,
            lancamentoRecorrente.TipoLancamento,
            lancamentoRecorrente.Categoria);

        await _lancamentoRecorrenteRep.IncluirAsync(lancamentoRecorrente);
        await _contaFinanceiraRepository.IncluirContaFinanceiraAsync(contaFinanceira);
    }
}
