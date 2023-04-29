using AutoMapper;
using FinanceManager.Application.DTOs.DtosCadastro;
using FinanceManager.Domain.Entidades;

namespace FinanceManager.Api.Profiles;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<UserCadastroRequest, ApplicationUser>()
        .ForMember(dest => dest.PessoaFisica, opt =>
        {
            opt.PreCondition(src => src.TipoUsuario.ToString() == "PessoaFisica");
            opt.MapFrom(src => src.PessoaFisica);
        })
        .ForMember(dest => dest.PessoaJuridica, opt =>
        {
            opt.PreCondition(src => src.TipoUsuario.ToString() == "PessoaJuridica");
            opt.MapFrom(src => src.PessoaJuridica);
        });

        CreateMap<EnderecoCadastroRequest, Endereco>();
        CreateMap<TelefoneCadastroRequest, Telefone>();

        CreateMap<PessoaFisicaCadastroRequest, PessoaFisica>()
            .ForMember(desc => desc.Cpf, opt => opt.MapFrom(src => src.Cpf))
            .ForMember(desc => desc.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(desc => desc.Enderecos, opt => opt.MapFrom(src => src.Enderecos))
            .ForMember(desc => desc.Telefones, opt => opt.MapFrom(src => src.Telefones))
            .ForMember(desc => desc.Empregador, opt => opt.MapFrom(src => src.Empregador))
            .ForMember(desc => desc.Nome, opt => opt.MapFrom(src => src.Nome));

        CreateMap<PessoaJuridicaCadastroRequest, PessoaJuridica>()
           .ForMember(desc => desc.RazaoSocial, opt => opt.MapFrom(src => src.RazaoSocial))
            .ForMember(desc => desc.FaturamentoMensal, opt => opt.MapFrom(src => src.FaturamentoMensal))
            .ForMember(desc => desc.FaturamentoAnual, opt => opt.MapFrom(src => src.FaturamentoAnual))
            .ForMember(desc => desc.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(desc => desc.Enderecos, opt => opt.MapFrom(src => src.Enderecos))
            .ForMember(desc => desc.Telefones, opt => opt.MapFrom(src => src.Telefones))
            .ForMember(desc => desc.Cnpj, opt => opt.MapFrom(src => src.Cnpj));

        CreateMap<EmpregadorCadastroRequest, Empregador>()
            .ForMember(desc => desc.Cnpj, opt => opt.MapFrom(src => src.Cnpj))
            .ForMember(desc => desc.EmpresaAtual, opt => opt.MapFrom(src => src.EmpresaAtual))
            .ForMember(desc => desc.RazaoSocial, opt => opt.MapFrom(src => src.RazaoSocial))
            .ForMember(desc => desc.ValorPago, opt => opt.MapFrom(src => src.ValorPago));
     
            
    }
}
