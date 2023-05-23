using FinanceManager.Application.DTOs.DtoQuery;
using FinanceManager.Application.DTOs.DtosCadastro;
using FinanceManager.Application.DTOs.DtosResponse;
using FinanceManager.Application.DTOs.DtosUpdate;
using FinanceManager.Application.Interfaces;
using FinanceManager.Application.Interfaces.Repositorios;
using FinanceManager.Domain.Entidades;
using FinanceManager.Domain.Factory;
using System.Data;

namespace FinanceManager.Application.Services;

public class LancamentoService : ILancamentoService
{
    private readonly ILancamentoRep _lancamentoRep;
    private readonly ICategoriaRep _categoriaRep;

    public LancamentoService(ILancamentoRep contaFinanceiraRepository, ICategoriaRep categoriaRep)
    {
        _lancamentoRep = contaFinanceiraRepository;
        _categoriaRep = categoriaRep;
    }
    public async Task<IEnumerable<LancamentoResponse>> ObterAsync(HistoricoQuery historicoQuery)
    {
        return await _lancamentoRep.ObterAsync(historicoQuery);
    }

    public async Task<IEnumerable<LancamentoResponse>> IncluirAsync(LancamentoCadastroRequest lancamento)
    {
        var categoriaObtida = await _categoriaRep.ObterCategoriaByIdAsync(lancamento.CategoriaId);

        if (categoriaObtida is null)
            throw new DataException("Não foi encontrada nenhuma categoria com o id informado", new Exception("Não foi encontrada nenhuma categoria com o id informado"));

        var lancamentoInserir = LancamentoFactory.Create
            (lancamento.ValorLancamento, 
            lancamento.TipoLancamento,
            categoriaObtida,
            lancamento.TituloLancamento,
            lancamento.DataLancamento);

        var historicoAtualizado = await _lancamentoRep.IncluirAsync(lancamentoInserir);

        if (historicoAtualizado is null)
            return null;

        return historicoAtualizado;
    }

    public async Task<IEnumerable<LancamentoResponse>> AlterarAsync(LancamentoUpdateRequest lancamento)
    {
        var lancamentoAlterar = await _lancamentoRep.ObterLancamentoByIdAsync(lancamento.Id);
        var categoriaObtida = await _categoriaRep.ObterCategoriaByIdAsync(lancamento.CategoriaId);

        var userLogado = await _lancamentoRep.ObterUserLogado();

        await  _lancamentoRep.AtualizaSaldoUsuario(userLogado, lancamentoAlterar, true);
        lancamentoAlterar.Alterar(lancamento.ValorLancamento, lancamento.TipoLancamento, categoriaObtida, lancamento.TituloLancamento);

        return await _lancamentoRep.AlterarAsync(lancamentoAlterar);
    }

    public async Task<IEnumerable<LancamentoResponse>> DeletarAsync(int[] ids)
    {
        if(!ids.Any())
            throw new DataException("Deve ser informado um Id", new Exception("Deve ser informado um Id"));

        foreach (int idAtual in ids)
        {
            await _lancamentoRep.DeletarLancamento(idAtual);
        }

        var lancamentos = await _lancamentoRep.ObterAsync(new HistoricoQuery());
        return lancamentos;
    }
}



