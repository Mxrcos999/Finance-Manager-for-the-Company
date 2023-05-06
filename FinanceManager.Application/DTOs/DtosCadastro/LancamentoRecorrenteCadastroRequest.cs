﻿using static FinanceManager.Domain.Entidades.ContaFinanceira;

namespace FinanceManager.Application.DTOs.DtosCadastro;

public sealed class LancamentoRecorrenteCadastroRequest
{
    public decimal ValorLancamento { get; set; }
    public DateTime DataPrevistaLancamento { get; set; }
    public TiposLancamento TipoLancamento { get; set; }
    public int CategoriaId { get; set; }
}