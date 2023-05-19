using FinanceManager.Application.DTOs.DtosCadastro;
using FinanceManager.Application.Interfaces;
using FinanceManager.Application.Interfaces.Repositorios;
using FinanceManager.Domain.Factory;

namespace FinanceManager.Application.Services;

public class LancamentoRecorrenteService : ILancamentoRecorrenteService
{
    private readonly ILancamentoRecorrenteRep _lancamentoRecorrenteRep;
    private readonly ILancamentoRep _contaFinanceiraRepository;
    private readonly ICategoriaRep _categoriaRep;


    public LancamentoRecorrenteService(ILancamentoRecorrenteRep lancamentoRecorrenteRep, ILancamentoRep contaFinanceiraRepository, ICategoriaRep categoriaRep)
    {
        _lancamentoRecorrenteRep = lancamentoRecorrenteRep;
        _contaFinanceiraRepository = contaFinanceiraRepository;
        _categoriaRep = categoriaRep;
    }

    public async Task IncluirASync(LancamentoRecorrenteCadastroRequest lancamento)
    {
        var categoriaObtida = await _categoriaRep.ObterCategoriaByIdAsync(lancamento.CategoriaId);
        if (categoriaObtida is null)
            throw new Exception("Não foi encontrado nenhuma categoria com o id informado.", new Exception("Não foi encontrado nenhuma categoria com o id informado."));

        var lancamentoRecorrente = LancamentoRecorrenteFactory
             .Create
             (lancamento.ValorLancamento,
             lancamento.DataPrevistaLancamento,
             lancamento.TipoLancamento,
             categoriaObtida);

        var contaFinanceira = LancamentoFactory
            .Create
            (lancamentoRecorrente.ValorLancamento,
            lancamentoRecorrente.TipoLancamento,
            lancamentoRecorrente.Categoria,
            lancamentoRecorrente.TituloLancamentoRecorrente);

        await _lancamentoRecorrenteRep.IncluirAsync(lancamentoRecorrente);
        await _contaFinanceiraRepository.IncluirAsync(contaFinanceira);
    }
}
