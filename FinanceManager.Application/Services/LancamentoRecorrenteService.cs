using FinanceManager.Application.DTOs.DtosCadastro;
using FinanceManager.Application.DTOs.DtosResponse;
using FinanceManager.Application.Interfaces;
using FinanceManager.Application.Interfaces.Repositorios;
using FinanceManager.Domain.Factory;

namespace FinanceManager.Application.Services;

public class LancamentoRecorrenteService : ILancamentoRecorrenteService
{
    private readonly ILancamentoRecorrenteRep _lancamentoRecorrenteRep;
    private readonly ILancamentoRep _lancamentoRep;
    private readonly ICategoriaRep _categoriaRep;


    public LancamentoRecorrenteService(ILancamentoRecorrenteRep lancamentoRecorrenteRep, ILancamentoRep contaFinanceiraRepository, ICategoriaRep categoriaRep)
    {
        _lancamentoRecorrenteRep = lancamentoRecorrenteRep;
        _lancamentoRep = contaFinanceiraRepository;
        _categoriaRep = categoriaRep;
    }

    public async Task IncluirASync(LancamentoRecorrenteCadastroRequest lancamentoRecorrente)
    {
        var categoriaObtida = await _categoriaRep.ObterCategoriaByIdAsync(lancamentoRecorrente.CategoriaId);
        if (categoriaObtida is null)
            throw new Exception("Não foi encontrado nenhuma categoria com o id informado.", new Exception("Não foi encontrado nenhuma categoria com o id informado."));

        var lancamentoRecorrenteInserir = LancamentoRecorrenteFactory
             .Create
             (lancamentoRecorrente.ValorLancamento,
             lancamentoRecorrente.TituloLancamento,
             lancamentoRecorrente.DataPrevistaLancamento,
             lancamentoRecorrente.TipoLancamento,
             categoriaObtida);

        await _lancamentoRecorrenteRep.IncluirAsync(lancamentoRecorrenteInserir);
        if (lancamentoRecorrente.Verificado)
        {
            var lancamentoInseir = LancamentoFactory
                    .Create
                    (lancamentoRecorrenteInserir.ValorLancamento,
                    lancamentoRecorrenteInserir.TipoLancamento,
                    lancamentoRecorrenteInserir.Categoria,
                    lancamentoRecorrenteInserir.TituloLancamentoRecorrente);

            await _lancamentoRep.IncluirAsync(lancamentoInseir);
        }
    }

    public async Task<OlimpusResponseDefault> VerificaAgendamentoLancamento(string idUsuario) 
    {
        var lancamentosResponse = await _lancamentoRecorrenteRep.VerificaAgendamentoLancamentoAsync(idUsuario);
        var response = new OlimpusResponseDefault();

        if(lancamentosResponse is null)
           response.Status = false;

        response.Status = true;
        response.Dados = lancamentosResponse;

        return response;
    }

}
