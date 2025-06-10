using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Formatter;
using DataLayer.Entities;
using BusinessLayer.Services;
using DataLayer.DTOs;

namespace NguyenManhTanHuynh_SE17D05_A01_BE.Controllers
{
    [Route("odata/[controller]")]
    //[Authorize(Roles = "Admin")]
    public class AccountsController : ODataController
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            var accounts = await _accountService.GetAllAsync();
            return Ok(accounts);
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromODataUri] string key)
        {
            var account = await _accountService.GetByIdAsync(key);
            if (account == null)
                return NotFound();
            return Ok(account);
        }

        public async Task<IActionResult> Post([FromBody] SystemAccount account)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _accountService.CreateAsync(account);
            return Created(account);
        }

        public async Task<IActionResult> Put([FromODataUri] string key, [FromBody] UpdateAccountDto accountDto) // <--- NHẬN DTO MỚI
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _accountService.UpdateAsync(key, accountDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public async Task<IActionResult> Delete([FromODataUri] string key)
        {
            try
            {
                await _accountService.DeleteAsync(key);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
