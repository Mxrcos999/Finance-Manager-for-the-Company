using FinanceManager.Application.DTOs.DtosResponse;
using FinanceManager.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.Api.Controllers
{
    //CONTROLLER
    [Authorize]
    [ApiController]
    [Route("api/conta-financeira")]
    public class ContaFinanceiraController : Controller
    {
        private readonly IContaFinanceiraService _contaFinanceiraService;
        public ContaFinanceiraController(IContaFinanceiraService contaFinanceiraService)
        {
            _contaFinanceiraService = contaFinanceiraService;
        }
        //ENDPOINT
        [HttpGet]
        public async Task<IEnumerable<ContaFinanceiraResponse>> GetContaFinanceirasASync()
        {
            return await _contaFinanceiraService.ObterContasFinanceiras();
        }
    }
}
