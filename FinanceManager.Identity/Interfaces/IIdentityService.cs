﻿using FinanceManager.Application.DTOs.DtosCadastro;
using FinanceManager.Application.DTOs.DtosResponse;

namespace FinanceManager.Identity.Interfaces;

public interface IIdentityService
{
    Task<UserLoginResponse> LoginAsync(UserLoginRequest userLogin);
    Task<bool> RegisterUserAsync(UserRegisterRequest userRegister);
}


