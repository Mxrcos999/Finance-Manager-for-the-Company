﻿using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Application.DTOs.DtosCadastro;

public class PessoaCadastroRequest 
{
    public List<EnderecoCadastroRequest> Enderecos { get; set; }
    public List<TelefoneCadastroRequest> Telefones { get; set; }
    public string[] Emails { get; set; }
    [Required(ErrorMessage = "O campo email é obrigatório.")]
    [EmailAddress(ErrorMessage = "Informe um email válido.")]
    public string Email { get; set; }
    [Required(ErrorMessage = "O campo senha é obrigatório.")]
    public string Senha { get; set; }
    [Required(ErrorMessage = "O campo confirmar senha é obrigatório.")]
    [Compare("Senha", ErrorMessage = "As senhas não são iguais.")]
    public string ConfirmaSenha { get; set; }
}
