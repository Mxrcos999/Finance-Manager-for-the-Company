﻿namespace FinanceManager.Application.DTOs.DtosCadastro;

public class UserPessoaFisicaCadastroRequest
{
    public PessoaFisicaCadastroRequest PessoaFisica { get; set; }



    public enum TipoUsuarioEnum
    {
        PessoaFisica,
        PessoaJuridica
    }
}
