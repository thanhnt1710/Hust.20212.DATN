using Hust.Datn.Service.Entity;
using Hust.Datn.Service.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hust.Datn.Controller.Controllers
{
    [Authorize]
    public class AuthController : BaseController<User>
    {
        #region Declare
        protected readonly IAuthService _authService;
        #endregion

        #region Constructor
        public AuthController(IAuthService authService) : base(authService)
        {
            _authService = authService;
        }
        #endregion

        #region Methods
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(User user)
        {
            try
            {
                var result = await _authService.Login(user.UserName, user.Password);

                return Ok(result);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(User user)
        {
            try
            {
                var result = await _authService.Register(user);

                return Ok(result);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }
        #endregion
    }
}
