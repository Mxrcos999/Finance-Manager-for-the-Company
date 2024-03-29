﻿using FinanceManager.Domain.Entidades;
using FinanceManager.Domain.Utils;

namespace FinanceManager.Application.DTOs.DtosResponse;

public sealed class PessoaFisicaResponse
{
    public string Email { get; set; }
    public TipoUsuario TipoUsuario { get; set; }
    public string Nome { get; set; }
    public string? Cpf { get; set; }
    public DateTime DataCriacaoConta { get; set; }
    public decimal Saldo { get; set; }
    public DateTime DataNascimento { get; set; }
}
