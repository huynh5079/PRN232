using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using DataLayer.Entities;
using NguyenManhTanHuynh_SE17D05_A01_BE.Services;

namespace NguyenManhTanHuynh_SE17D05_A01_BE.Controllers
{
    [Route("odata/Accounts")]
    [Authorize(Roles = "Admin")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            var accounts = await _accountService.GetAllAsync();
            return Ok(accounts);
        }

        [HttpGet("{id}")]
        [EnableQuery]
        public async Task<IActionResult> Get(string id)
        {
            var account = await _accountService.GetByIdAsync(id);
            if (account == null)
                return NotFound();
            return Ok(account);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SystemAccount account)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _accountService.CreateAsync(account);
            return CreatedAtAction(nameof(Get), new { id = account.Id }, account);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] SystemAccount account)
        {
            if (id != account.Id)
                return BadRequest("ID mismatch");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _accountService.UpdateAsync(account);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _accountService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}