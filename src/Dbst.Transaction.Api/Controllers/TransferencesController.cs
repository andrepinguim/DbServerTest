using System.Threading.Tasks;
using Dbst.Transaction.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Dbst.Transaction.Api.Models;
using System.Net;
using System;

namespace Dbst.Transaction.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferencesController : ControllerBase
    {
        private ITransactionService _transactionService;

        public TransferencesController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Transference transference)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var isSuccessful = await _transactionService.Create(transference.OriginAccountId, transference.DestinationAccountId, transference.Value);
                if (!isSuccessful)
                    return this.StatusCode((int)HttpStatusCode.BadRequest, new { message = "Ops! Tente novamente mais tarde." });

                return Ok();
            }
            catch (Exception)
            {
                ///TODO: logar erro (criar middleware que faça esse trabalho).
                ///     O ideal é não subir exception e sim retornar um obj com o erro. Exceptions custam processamento!

                return this.StatusCode((int)HttpStatusCode.BadRequest, new { message = "Ops! Tente novamente mais tarde." });
            }
        }
    }
}
