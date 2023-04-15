﻿using FinanceManager.Domain.Entidades;

namespace FinanceManager.Application.DTOs.DtosCadastro;

public class PessoaFisicaCadastroRequest : PessoaCadastroRequest
{
    public string Cpf { get; set; }
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public ContaFinanceira ContaFinanceira { get; set; }
    public ICollection<EmpregadorCadastroRequest> Empregador { get; set; }
}
