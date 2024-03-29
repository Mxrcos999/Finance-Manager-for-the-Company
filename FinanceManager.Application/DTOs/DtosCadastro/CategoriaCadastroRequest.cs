﻿using System.ComponentModel.DataAnnotations;
using static FinanceManager.Domain.Entidades.Categoria;

namespace FinanceManager.Application.DTOs.DtosCadastro;

public sealed class CategoriaCadastroRequest
{
    [Required(ErrorMessage = "O nome da categoria deve ser informado!")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O descrição deve ser informado!")]
    public string Descricao { get; set; }  
    [Required(ErrorMessage = "O código de cor deve ser informado!")]
    public string ColorCode { get; set; }

    [Required(ErrorMessage = "O tipo de lançamento deve ser informado!")]
    public TipoCategoria Tipo { get; set; }
}
