using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop.api.Dto;
using shop.data.DomainServices;
using shop.domain;

namespace shop.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController(ITransactionDomainService transactionService, IMapper mapper): ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionDto>>> GetTransactions()
        {
            var transactions = await transactionService.GetAsync();
            return Ok(mapper.Map<IEnumerable<TransactionDto>>(transactions));
        }

        [HttpPut]
        [ProducesResponseType(204)]
        public async Task<IActionResult> PutTransaction([FromBody] TransactionDto transactionDto)
        {

            var transaction = mapper.Map<Transaction>(transactionDto);
            int rowsChanged = await transactionService.UpdateAsync(transaction);

            if (rowsChanged == 0) return BadRequest("Database error");

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<TransactionDto>> PostTransaction(TransactionDto transactionDto)
        {
            var transaction = await transactionService.InsertAsync(mapper.Map<Transaction>(transactionDto));
            return Ok(mapper.Map<TransactionDto>(transaction));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteTransaction(Guid id)
        {
            var rowsChanged = await transactionService.DeleteAsync(id);

            if (rowsChanged == 0) return BadRequest("Entry not found");

            return NoContent();
        }

    }
}
