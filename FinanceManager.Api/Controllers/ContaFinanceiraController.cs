using FinanceManager.Application.DTOs.DtosResponse;
using FinanceManager.Application.Interfaces;
using FinanceManager.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class ContaFinanceiraController : Controller
    {
        private readonly IContaFinanceiraService _contaFinanceiraService;
        public ContaFinanceiraController(IContaFinanceiraService contaFinanceiraService)
        {
            _contaFinanceiraService = contaFinanceiraService;
        }

        [Authorize]
        [HttpGet]
        [Route("contaFinanceira")]
        public async Task<IEnumerable<ContaFinanceiraResponse>> GetContaFinanceirasASync()
        {
            return await _contaFinanceiraService.ObterContasFinanceiras();
        }
    }
}
