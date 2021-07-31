using CarStore.BusinessLogicLayer.Models.Account;
using CarStore.BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarStore.PresentationLayer.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LogIn(LoginModel model)
        {
            var result = await _accountService.LogInAsync(model);
            return Ok(result);
        }
    }
}
